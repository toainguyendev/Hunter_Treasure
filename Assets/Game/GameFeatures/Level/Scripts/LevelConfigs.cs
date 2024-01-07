using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

[Serializable]
public struct TreasureData
{
    public string treasureName;
    public string description;
    public AssetReferenceT<GameObject> treasurePrefabRef;
    public AssetReferenceT<Sprite> avatarRef;
}

[Serializable]
public struct LevelData
{
    public string levelName;
    public string story;

    public AssetReferenceT<GameObject> mapPrefabRef;

    [Space(10)]
    public TreasureData treasureData;
}

[CreateAssetMenu(fileName = "LevelConfigs", menuName = "HunterTreasure/Level/LevelConfigs")]
public class LevelConfigs : ScriptableObject
{
    // List levelData
    [SerializeField] private LevelData[] levelDatas;

    public LevelData GetLevelData(int levelId)
    {
        try
        {
            return levelDatas[levelId - 1];
        }
        catch (Exception e)
        {
            ConsoleLog.LogError($"LevelConfigs.GetLevelData: {e.Message}");
            return levelDatas[0];
        }
    }
}
