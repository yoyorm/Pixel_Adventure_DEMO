using System;
using System.IO;
using UnityEngine;

public static class JsonDataMgr
{
    private static string Path => Application.persistentDataPath + "/JsonDataMgr.json";

    public static void Save(SaveData saveData)
    {
        try
        {
            // 确保目录存在
            string directory = System.IO.Path.GetDirectoryName(Path);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            
            string json = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(Path, json);
            Debug.Log("& Saved: " + Path);
        }
        catch (Exception e)
        {
            Debug.LogError($"保存失败: {e.Message}");
        }
    }

    public static SaveData Load()
    {
        try
        {
            // 检查文件是否存在
            if (!File.Exists(Path))
            {
                Debug.LogWarning("配置文件不存在，创建默认数据");
                return new SaveData(); // 返回默认数据
            }
            
            string json = File.ReadAllText(Path);
            var data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("& Loaded: " + Path);
            return data;
        }
        catch (Exception e)
        {
            Debug.LogError($"读取失败: {e.Message}");
            return new SaveData(); // 返回默认数据
        }
    }
}