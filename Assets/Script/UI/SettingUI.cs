using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingUI : BaseUI<SettingUI>
{
    public Slider bgmSlider;
    public Slider seSlider;
    private readonly Vector3 _oldScale=new Vector3(1,1,1);
    private MusicData _musicData=new MusicData();
    private new void  Awake()
    {
        base.Awake();
        if(mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        EventBus<SettingUIEvent>.Subscribe(OnChanged);
        Off();
        _musicData = DataManager.MusicData;
        bgmSlider.value=_musicData.bgmVolume;
        seSlider.value=_musicData.seVolume;
        
    }

    

    #region UI初始化
    
    public void OnNewBgmVolume(float val)
    {
        _musicData.bgmVolume = val;
        EventBus<MusicData>.Publish(_musicData);
    }
    public void OnNewSeVolume(float val)
    {
        _musicData.seVolume = val;
        EventBus<MusicData>.Publish(_musicData);
    }
    #endregion

    private void OnChanged(SettingUIEvent newSettingUIEvent)
    {
        if (newSettingUIEvent.State)
            On();
        else
            Off();
    }
    
    
    public override void On()
    {
        EventBus<ChooseUIEvent>.Publish(new ChooseUIEvent(false));
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            transform.localScale = _oldScale * 0.5f;
        }
        else
        {
            transform.localScale = _oldScale;
        }
        Time.timeScale = 0;
        if (!mainCamera)
            mainCamera=Camera.main;
        base.On();
    }
    public override void Off()
    {
        Time.timeScale = 1;
        DataManager.SaveIt();
        base.Off();
    }
    
    private new void OnDestroy()
    {
        base.OnDestroy();
        EventBus<SettingUIEvent>.Unsubscribe(OnChanged);
    }
}
