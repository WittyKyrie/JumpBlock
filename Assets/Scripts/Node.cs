using UnityEngine;

public class Node : MonoBehaviour
{
    public Block block;
    private bool _isObstacleHere;
    
    public Vector2Int Pos => new Vector2Int((int) transform.position.x,(int) transform.position.z);

    public bool IsEmpty()
    {
        return !block && !_isObstacleHere;
    }
}