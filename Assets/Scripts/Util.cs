using UnityEngine;

public static class Util
{
    public static Vector2Int PositionToVector2Int(Transform target)
    {
        var position = target.position;
        var ve2 = new Vector2Int((int) position.x, (int) position.z);
        return ve2;
    }
    
    public static Vector3 Vector2IntToPosition(Vector2Int ve2)
    {
        var position = new Vector3(ve2.x, 0, ve2.y);
        return position;
    }
}
