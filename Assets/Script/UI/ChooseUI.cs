
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseUI : BaseUI<ChooseUI>
{
    public Vector3 oldScale = new Vector3(1, 1, 1);
    public TextMeshProUGUI recordText1;
    public TextMeshProUGUI recordText2;

    private LevelData[] _levelData;

    private void InitLevelData()
    {
        LoadAllLevelDataEvent data = EventBus<LoadAllLevelDataEvent>.GetEvent();
        _levelData = new LevelData[data.LevelData.Length];
        for (int i = 0; i < _levelData.Length; i++)
        {
            _levelData[i] = new LevelData(data.LevelData[i]);
        }
    }

    private void ShowData()
    {
        if (_levelData[1] != null)
            recordText1.text = ($"Score: {_levelData[1].Score} Time: {(int)_levelData[1].TimeCost}");
        if (_levelData[2] != null)
            recordText2.text = ($"Score: {_levelData[2].Score} Time: {(int)_levelData[2].TimeCost}");
    }
    

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        InitLevelData();
        ShowData();
        EventBus<ChooseUIEvent>.Subscribe(Onchange);
        Off();
    }


    public void BackToGame()
    {
        Off();
    }

    public void StartLevelOne()
    {

        SceneManager.LoadScene(1);
        Off();
    }

    public void StartLevelTwo()
    {

        SceneManager.LoadScene(2);
        Off();
    }



    public override void On()
    {

        EventBus<SettingUIEvent>.Publish(new SettingUIEvent(false));
        //调整UI背景大小
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            transform.localScale = oldScale * 0.5f;
        }
        else
        {
            transform.localScale = oldScale;
        }

        base.On();
        InitLevelData();
        ShowData();
        Time.timeScale = 0;
    }

    public override void Off()
    {
        base.Off();
        Time.timeScale = 1;
    }

    private void Onchange(ChooseUIEvent e)
    {
        if (e.State)
            On();
        else
            Off();
    }

    private new void OnDestroy()
    {
        base.OnDestroy();
        EventBus<ChooseUIEvent>.Unsubscribe(Onchange);
    }
}


    
