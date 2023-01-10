using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelGenerator : Singleton<LevelGenerator>
{
    public AssetReferenceGameObject basicNode;
    private GameObject _activeBlock;
    private GameObject _sleepyBlock;
    private GameObject _targetPlace;
    public TextAsset levelConfig;

    private void Start()
    {
        basicNode.LoadAssetAsync();
        var test1 = JsonUtility.FromJson<Level>(levelConfig.text);
        GenerateLevel(test1);
    }

    public void GenerateLevel(Level level)
    {
        var map = Instantiate(new GameObject("Map"));
        
        foreach (var vector2Int in level.basicNodeList)
        {
            if (basicNode.Asset != null)
            {
                var node = Instantiate(basicNode.Asset, map.transform) as GameObject;
                node.transform.position = new Vector3(vector2Int.x, 0.1f, vector2Int.y) * 2;
            }
        }
    }
}
