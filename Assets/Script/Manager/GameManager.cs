using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;

public enum GameState{MainMenu,StartGame,InGame,GameOver,Pause}
public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    [SerializeField]
    private GameState state;

    private delegate void OnGameStateChanged();
    private OnGameStateChanged _onGameStateChanged;
    private PauseUI pUI;
    GameManager()
    {
        Instance = this;
        state=GameState.MainMenu;
    }
    private void Awake()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        _onGameStateChanged = Do;
    }

    
    
    
    public void ChangeGameState(GameState newState)
    {
        state=newState;
        _onGameStateChanged?.Invoke();
        
    }
    public GameState GetGameState()=>state;

    private void Do()
    {
        switch (state)
        {
            case GameState.StartGame:
            {
                //加载人物角色和相机在出生点
                
                GameObject player =Instantiate(Resources.Load<GameObject>("Player"));
                player.transform.position = BirthPointMgr.instance.ReadBirthPoint();
                Camera playerCamera =Instantiate(Resources.Load<Camera>("PlayerCamera"));
                playerCamera.transform.position = BirthPointMgr.instance.ReadBirthPoint();
                playerCamera.transform.position=new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z-100);
                GameObject pauseUI =Instantiate(Resources.Load<GameObject>("PauseUIBag"));
                //绑定角色相机
                CameraControl pcc=playerCamera.GetComponent<CameraControl>();
                pcc.player = player.transform;
                //绑定UI相机
                pUI=pauseUI.GetComponent<PauseUI>();
                pUI.mainCamera = playerCamera;

                state = GameState.InGame;
                break;
            }
            case GameState.GameOver:
            {
                //唤起结束UI
                break;
            }
            case GameState.InGame:
            {
                pUI.Off();
                break;
            }
            case GameState.Pause:
            {
                pUI.On();
                break;
            }
            case GameState.MainMenu:
            {
                SceneManager.LoadScene("MainMenu");
                //保存人物数据
                break;
            }
                
        }
    }
}
