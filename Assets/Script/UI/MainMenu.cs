using UnityEngine;


public class MainMenu : BaseUI<MainMenu>
{
    
    
    public void StartGame()
    {
        
        EventBus<ChooseUIEvent>.Publish(new ChooseUIEvent(true));
    }

    public void Settings()
    {
        
        EventBus<SettingUIEvent>.Publish(new SettingUIEvent(true));
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
