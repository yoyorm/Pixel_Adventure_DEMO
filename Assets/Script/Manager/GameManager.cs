
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState{MainMenu,StartGame,InGame,GameOver,Pause}
public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    [SerializeField]
    private GameState state;

    private delegate void OnGameStateChanged();
    private OnGameStateChanged _onGameStateChanged;
    private GameObject _player;
    private Camera _playerCamera;
    public CloseMask mask;
    GameManager()
    {
        state=GameState.MainMenu;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void Start()
    {
        _onGameStateChanged = Do;
        InitChooseUI();
        InitSetting();
        InitMask();
    }

    


    public void ChangeGameState(GameState newState)
    {
        state=newState;
        _onGameStateChanged?.Invoke();
        
    }
    public GameState GetGameState()=>state;

    /// <summary>
    /// 根据游戏状态执行的对应操作
    /// </summary>
    private void Do()
    {
        switch (state)
        {
            case GameState.StartGame:
            {
                //加载人物角色和相机
                InitPlayer();
                InitPlayerCamera();
                //初始化UI
                InitMask();
                InitPlayerUI();
                InitPauseUI();
                InitOverUI();
                //初始化管理器
                Instantiate(Resources.Load<GameObject>("LevelManager"));
                state = GameState.InGame;
                break;
            }
            case GameState.GameOver:
            {
                
                //Debug.Log("GameOver:正在尝试保存数据");
                DataManager.SaveIt();
                break;
            }
            case GameState.InGame:
            {
                EventBus<PauseUIEvent>.Publish(new PauseUIEvent(false));
                break;
            }
            case GameState.Pause:
            {
                EventBus<PauseUIEvent>.Publish(new PauseUIEvent(true));
                break;
            }
            case GameState.MainMenu:
            {
               
                SceneManager.LoadScene(0);
                InitMask();
                break;
            }
                
        }
    }
    
    
    

   
    
    #region 初始化方法
    private void InitPlayer()
    {
        _player =Instantiate(Resources.Load<GameObject>("Player"));
        _player.transform.position = BirthPointMgr.instance.ReadBirthPoint();
    }

    private void InitPlayerCamera()
    {
        _playerCamera =Instantiate(Resources.Load<Camera>("PlayerCamera"));
        _playerCamera.transform.position=new Vector3(_player.transform.position.x,_player.transform.position.y,_player.transform.position.z-100);
        _playerCamera.GetComponent<CameraControl>().player=_player.transform;
    }

    private void InitPlayerUI()
    {
        StartCoroutine(AsyncLoadPlayerUI());
    }

    private IEnumerator AsyncLoadPlayerUI()
    {
        var rq = Resources.LoadAsync<GameObject>("PlayerUI");
        yield return rq;
        Instantiate(rq.asset as GameObject);
    }

    private void InitPauseUI()
    {
        StartCoroutine(AsyncLoadPauseUI());
    }

    private IEnumerator AsyncLoadPauseUI()
    {
        var rq = Resources.LoadAsync<GameObject>("PauseUIBag");
        yield return rq;
        Instantiate(rq.asset as GameObject);
    }
    
    
    private void InitChooseUI()
    {
       StartCoroutine(AsyncLoadChooseUI());
    }

    private IEnumerator AsyncLoadChooseUI()
    {
        var rq = Resources.LoadAsync<GameObject>("ChooseUIBag");
        yield return rq;
        Instantiate(rq.asset as GameObject);
    }
    

    private void InitOverUI()
    {
        StartCoroutine(AsyncLoadOverUI());
    }

    private IEnumerator AsyncLoadOverUI()
    {
        var rq = Resources.LoadAsync<GameObject>("OverUIBag");
        yield return rq;
        Instantiate(rq.asset as GameObject);
    }

    private void InitSetting()
    {
        StartCoroutine(AsyncLoadSettingUI());
    }

    private IEnumerator AsyncLoadSettingUI()
    {
        var rq = Resources.LoadAsync<GameObject>("SettingUIBag");
        yield return rq;
        Instantiate(rq.asset as GameObject);
    }

    private void InitMask()
    {
        StartCoroutine(AsyncLoadMask());
    }

    private IEnumerator AsyncLoadMask()
    {
        var rq = Resources.LoadAsync<GameObject>("Mask");
        yield return rq;
        mask=Instantiate(rq.asset as GameObject).GetComponentInChildren<CloseMask>();
        if (_player)
        {
            mask.fatherObject.transform.SetParent(_player.transform,false);
        }
        mask.On();
    }
    
    
    #endregion
}
