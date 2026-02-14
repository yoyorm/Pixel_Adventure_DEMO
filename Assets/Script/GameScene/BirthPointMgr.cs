
using UnityEngine;

public class BirthPointMgr
{
    public static BirthPointMgr instance { get; } = new BirthPointMgr();

    private Vector3 _lastPoint=Vector3.zero;

    public void NewBirthPoint(Vector3 point)
    {
        _lastPoint = point;
    }

    public Vector3 ReadBirthPoint()
    {
        return _lastPoint;
    }
    
}
