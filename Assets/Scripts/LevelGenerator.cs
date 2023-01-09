using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelGenerator
{
    private GameObject _basicNode;
    private GameObject _activeBlock;
    private GameObject _sleepyBlock;
    private GameObject _targetPlace;

    public static void LoadAsset()
    {
        
    }
    
    public static void GenerateLevel(List<Vector2Int> basicNode, List<Vector2Int> activeBlock, 
        List<Vector2Int> sleepyBlock, List<Vector2Int> targetPlace)
    {
        foreach (var vector2Int in basicNode)
        {
            
        }

        foreach (var vector2Int in activeBlock)
        {
            
        }

        foreach (var vector2Int in sleepyBlock)
        {
            
        }

        foreach (var vector2Int in targetPlace)
        {
            
        }
    }
}
