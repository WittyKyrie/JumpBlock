using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;

public class LevelGenerator : Singleton<LevelGenerator>
{
    public AssetReferenceGameObject basicNode;
    private GameObject _activeBlock;
    private GameObject _sleepyBlock;
    private GameObject _targetPlace;
    public AssetReferenceT<TextAsset> levelConfig;

    private void Start()
    {
        var test = levelConfig.LoadAssetAsync<TextAsset>();
        var test1 = JsonUtility.FromJson<Level>(test.Task.Result.text);
        GenerateLevel(test1);
    }

    public void GenerateLevel(Level level)
    {
        var map = Instantiate(new GameObject("Map"));
        
        foreach (var vector2Int in level.basicNodeList)
        {
            var node = basicNode.InstantiateAsync(map.transform);
        }
    }
}
