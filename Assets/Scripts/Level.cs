using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public List<Vector2Int> basicNodeList = new List<Vector2Int>();
    public List<Vector2Int> activeBlockList = new List<Vector2Int>();
    public List<Vector2Int> sleepyBlockList = new List<Vector2Int>();
    public List<Vector2Int> targetPlaceList = new List<Vector2Int>();
}
