using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LevelGenerator : Singleton<LevelGenerator>
{
    public AssetReferenceGameObject basicNode;
    public AssetReferenceGameObject block;
    private GameObject _targetPlace;
    public AssetReference levelConfig;

    private Dictionary<int, Level> _levels = new Dictionary<int, Level>();
    private int _assetLoadCount = 2;
    private bool _levelIsReady;

    public void PrepareLevelAsset()
    {
        basicNode.LoadAssetAsync().Completed += OnShapeLoaded;
        block.LoadAssetAsync().Completed += OnShapeLoaded;
        var levelJson = levelConfig.LoadAssetAsync<TextAsset>().WaitForCompletion();
        var level = JsonUtility.FromJson<Level>(levelJson.text);
        _levels.Add(level.key, level);
    }
    
    private void OnShapeLoaded(AsyncOperationHandle<GameObject> obj)
    {
        _assetLoadCount--;
        if (_assetLoadCount <= 0)
            GameManager.Instance.ChangeGameState(GameState.GenerateLevel);
    }

    public void GenerateLevel(int level)
    {
        var map = Instantiate(new GameObject("Map"));
        
        foreach (var vector2Int in _levels[level].basicNodeList)
        {
            var pos = new Vector3(vector2Int.y, 0.1f, vector2Int.x) * 2;
            Instantiate(basicNode.Asset, pos, Quaternion.identity, map.transform);
        }

        foreach (var vector2Int in _levels[level].activeBlockList)
        {
            var pos = new Vector3(vector2Int.y, 0.5f, vector2Int.x) * 2;
            Instantiate(block.Asset, pos, Quaternion.identity, map.transform);
        }
    }
}
