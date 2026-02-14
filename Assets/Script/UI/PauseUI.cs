using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PauseUI : BaseUI<PauseUI>
{
    public Camera mainCamera;
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
        //打开设置界面
    }

    public override void On()
    {
        transform.position=new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y,0);
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
}
