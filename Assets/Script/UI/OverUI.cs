using TMPro;
using UnityEngine;


public class OverUI : BaseUI<OverUI>
{
    public TextMeshProUGUI conclusionText;

    private void Start()
    {
        EventBus<OverUIEvent>.Subscribe(OnChange);
        Off();
    }

    private void OnChange(OverUIEvent e)
    {
        if(e.State)
            On();
        else
            Off();
    }
    public void OnChooseNextLevel()
    {
        Off();
        Time.timeScale = 0;
        EventBus<ChooseUIEvent>.Publish(new ChooseUIEvent(true));
    }

    public void BackToMainMenu()
    {
        Off();
        GameManager.Instance.ChangeGameState(GameState.MainMenu);
    }
    public override void On()
    {
        base.On();
        Time.timeScale = 0;
        conclusionText.text=$"Score: {LevelManager.Instance.GetScore()}\nTime: {(int)LevelManager.Instance.GetTimeCost()}";
    }

    public override void Off()
    {
        if (!gameObject.activeSelf)
            return;
        base.Off();
        
        Time.timeScale = 1;
        GameManager.Instance.ChangeGameState(GameState.InGame);
    }

    private new void OnDestroy()
    {
        base.OnDestroy();
        EventBus<OverUIEvent>.Unsubscribe(OnChange);
    }
}
