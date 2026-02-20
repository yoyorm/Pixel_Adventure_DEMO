

using UnityEngine;

public static class DataManager
{
    private static readonly  LevelData[] Levels=new LevelData[10];
    public static MusicData MusicData = new();
    
    
    private static void UpdateLevelData(SaveLevelDataEvent data)
    {
        int index = data.Index;
        LevelData levelData = data.LevelData;
        
        if(Levels[index] == null)
            Levels[index]=new LevelData(levelData);
        else
        {
            //判断关卡得分和计时 是否更优
            if(Levels[index].Score<levelData.Score)
                Levels[index]=new LevelData(levelData);
            else if(Levels[index].Score==levelData.Score&&Levels[index].TimeCost>levelData.TimeCost||Levels[index].TimeCost==0)
                Levels[index]=new LevelData(levelData);
            EventBus<LoadAllLevelDataEvent>.Publish(new LoadAllLevelDataEvent(Levels));
        }
    }
    
    /// <summary>
    /// 保存到持久化文件夹
    /// </summary>
    public static void SaveIt()
    { 
        
        SaveData saveData = new SaveData()
        {
            levels = Levels,
            musicData = MusicData
        };
    
        JsonDataMgr.Save(saveData);
    }
    
    static DataManager()
    {
        EventBus<SaveLevelDataEvent>.Subscribe(UpdateLevelData);    //订阅：数据保存
        SaveData loadedData = JsonDataMgr.Load();
        for (int i = 0; i < Levels.Length; i++)
        {
            if (Levels[i] == null)
                Levels[i] = new LevelData(0, 0f); // 初始化默认值
        }
        if (loadedData != null && loadedData.levels != null)
        {
            // 复制有效数据
            for (int i = 0; i < loadedData.levels.Length && i < Levels.Length; i++)
            {
                Levels[i] = loadedData.levels[i];
            }
            Debug.Log("数据加载成功");
            EventBus<LoadAllLevelDataEvent>.Publish(new LoadAllLevelDataEvent(Levels));
        }
        
        if (loadedData != null)
        {
            MusicData = loadedData.musicData;
            if(MusicData==null)
                MusicData=new MusicData();
            EventBus<MusicData>.Publish(MusicData);
        }
        
    }
    
}
