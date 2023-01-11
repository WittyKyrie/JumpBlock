using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelGenerator : Singleton<LevelGenerator>
{
    public AssetReferenceGameObject basicNode;
    private GameObject _activeBlock;
    private GameObject _sleepyBlock;
    private GameObject _targetPlace;
    public AssetReference levelConfig;

    private Dictionary<int, Level> _levels = new Dictionary<int, Level>();

    private IEnumerator Start()
    {
        yield return basicNode.LoadAssetAsync().Task;
        var levelJson = levelConfig.LoadAssetAsync<TextAsset>().WaitForCompletion();

        var level = JsonUtility.FromJson<Level>(levelJson.text);
        _levels.Add(level.key, level);
        
        GenerateLevel(1);
    }

    public void GenerateLevel(int level)
    {
        var map = Instantiate(new GameObject("Map"));
        
        foreach (var vector2Int in _levels[level].basicNodeList)
        {
            var pos = new Vector3(vector2Int.y, 0.1f, vector2Int.x) * 2;
            var node = Instantiate(basicNode.Asset, pos, Quaternion.identity, map.transform) as GameObject;
        }
    }
}
