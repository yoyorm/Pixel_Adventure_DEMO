
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public bool finished;
    
    private readonly LevelData _levelData=new LevelData();
    [FormerlySerializedAs("_nowLevel")] [SerializeField]
    private int nowLevel;
    [SerializeField] private int score;
    [SerializeField] private float timeCost;
    
    public int GetScore()=>_levelData.Score;
    public float GetTimeCost()=>_levelData.TimeCost;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        string levelName = SceneManager.GetActiveScene().name;
        switch (levelName)//识别关卡
        {
            case "Level1":
            {
                nowLevel = 1;
                break;
            }
            case "Level2":
            {
                nowLevel = 2;
                break;
            }
        }

       

    }

    private void Update()
    {
        if(!finished)
        {
            if (GameManager.Instance.GetGameState() == GameState.InGame) //计时
                timeCost += Time.deltaTime;
            else if (GameManager.Instance.GetGameState() == GameState.GameOver) //保存数据
            {
                EventBus<SaveLevelDataEvent>.Publish(new SaveLevelDataEvent(nowLevel,_levelData));
                finished = true;
            }

            _levelData.Score = score;
            _levelData.TimeCost = timeCost;
        }
        
    }

    public void AddScore(int s)
    {
        score += s;
    }
}
