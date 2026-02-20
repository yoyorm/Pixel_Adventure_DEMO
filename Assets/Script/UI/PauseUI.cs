using UnityEngine;

public  class PauseUI : BaseUI<PauseUI>
{
    private void Start()
    {
        Off();
        EventBus<PauseUIEvent>.Subscribe(OnChange);
    }

    private void OnChange(PauseUIEvent e)
    {
        if(e.State)
            On();
        else
            Off();
    }

    public void BackToGame()
    {
        Off();
    }

    public void BackToMainMenu()
    {
        Off();
        GameManager.Instance.ChangeGameState(GameState.MainMenu);
    }

    public void Setting()
    {
        Off();
        EventBus<SettingUIEvent>.Publish(new SettingUIEvent(true));
    }

    public override void On()
    {
        SettingUI.instance.Off();
        base.On();
        Time.timeScale = 0;
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
        EventBus<PauseUIEvent>.Unsubscribe(OnChange);
    }
}
