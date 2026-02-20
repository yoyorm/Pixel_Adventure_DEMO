
public class EventArgs 
{
    
}

public class SaveLevelDataEvent:EventArgs
{
    public readonly int Index;
    public readonly LevelData LevelData;
    public SaveLevelDataEvent(){}
    
    public SaveLevelDataEvent(int index, LevelData levelData)
    {
        Index = index;
        LevelData = new LevelData(levelData);
    }
    
}

public class LoadAllLevelDataEvent:EventArgs
{
    public readonly LevelData[] LevelData;

    public LoadAllLevelDataEvent(LevelData[] levelData)
    {
        LevelData = new LevelData[levelData.Length];
        for (int i = 0; i < levelData.Length; i++)
        {
            LevelData[i] = new LevelData(levelData[i]);
        }
    }
}

#region UI事件

public class UIEvent
{
    public readonly bool State;

    protected UIEvent(bool state)
    {
        State = state;
    }
}
public class SettingUIEvent:UIEvent
{
    public SettingUIEvent(bool state):base(state){}
}

public class ChooseUIEvent : UIEvent
{
    public ChooseUIEvent(bool state):base(state){}
}

public class PauseUIEvent : UIEvent
{
    public PauseUIEvent(bool state):base(state){}
}

public class OverUIEvent : UIEvent
{
    public OverUIEvent(bool state):base(state){}
}
#endregion


