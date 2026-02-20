using System;
using UnityEngine.Serialization;


[Serializable]
public class SaveData
{
    public LevelData[] levels = Array.Empty<LevelData>();
     public MusicData musicData = new();
}
