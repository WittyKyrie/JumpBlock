using UnityEngine;

public class Node : MonoBehaviour
{
    private bool _isSleepyBlockHere;
    private bool _isObstacleHere;
    public bool IsEmpty => !_isObstacleHere && !_isSleepyBlockHere;
    
    public Vector2Int Pos => new Vector2Int((int) transform.position.x,(int) transform.position.z);
}