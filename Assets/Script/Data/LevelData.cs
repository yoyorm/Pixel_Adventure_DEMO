
using System;

[Serializable]
public class LevelData
{
    //public bool Accomplished = false;
    public float TimeCost = 0;
    public int Score = 0;

    public LevelData(int score, float timeCost)
    {
        Score = score;
        TimeCost = timeCost;
    }
    public LevelData()
    {
        Score = 0;
        TimeCost = 0;
    }

    public LevelData(LevelData other)
    {
        Score = other.Score;
        TimeCost = other.TimeCost;
    }
}

