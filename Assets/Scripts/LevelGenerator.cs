using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LevelGenerator : Singleton<LevelGenerator>
{
    public AssetReferenceGameObject basicNode;
    public AssetReferenceGameObject block;
    private GameObject _targetPlace;
    public AssetReference levelConfig;

    private Dictionary<int, Level> _levels;
    private int _assetLoadCount = 2;
    private bool _levelIsReady;

    private List<Node> _nodes;
    public List<Block> blocks;

    public void PrepareLevelAsset()
    {
        _nodes = new List<Node>();
        blocks = new List<Block>();
        basicNode.LoadAssetAsync().Completed += OnShapeLoaded;
        block.LoadAssetAsync().Completed += OnShapeLoaded;
        var levelJson = levelConfig.LoadAssetAsync<TextAsset>().WaitForCompletion();
        var level = JsonUtility.FromJson<Level>(levelJson.text);
        _levels = new Dictionary<int, Level> {{level.key, level}};
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
            var pos = new Vector3(vector2Int.x, 0, vector2Int.y);
            var node = Instantiate(basicNode.Asset, pos, Quaternion.identity, map.transform).GetComponent<Node>();
            if(node != null) _nodes.Add(node);

        }

        foreach (var vector2Int in _levels[level].activeBlockList)
        {
            var pos = new Vector3(vector2Int.x, 0, vector2Int.y);
            var activeBlock = Instantiate(block.Asset, pos, Quaternion.identity).GetComponent<Block>();
            if (activeBlock == null) continue;
            activeBlock.IsActiveBlock = true;
            blocks.Add(activeBlock);
            GetNodeAtPosition(vector2Int).block = activeBlock;
        }
        
        foreach (var vector2Int in _levels[level].sleepyBlockList)
        {
            var pos = new Vector3(vector2Int.x, 0, vector2Int.y);
            var sleepyBlock = Instantiate(block.Asset, pos, Quaternion.identity).GetComponent<Block>();
            if (sleepyBlock == null) continue;
            blocks.Add(sleepyBlock);
            GetNodeAtPosition(vector2Int).block = sleepyBlock;
        }
        
        GameManager.Instance.ChangeGameState(GameState.WaitingInput);
    }

    public bool GetNodeIsEmptyAtPosition(Vector2Int pos)
    {
        var node = _nodes.FirstOrDefault(n => n.Pos == pos);
        return node && node.IsEmpty();
    }
    
    public Node GetNodeAtPosition(Vector2Int pos)
    {
        return _nodes.FirstOrDefault(n => n.Pos == pos);
    }
}
