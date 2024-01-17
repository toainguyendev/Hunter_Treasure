using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

[Serializable]
public struct TreasureData
{
    public string treasureName;
    public string description;
    public GameObject treasurePrefabRef;
    public Sprite avatar;
}

[Serializable]
public struct LevelData
{
    public string levelName;
    public string story;
    public Sprite mapThumbnail;

    public AssetReferenceT<GameObject> mapPrefabRef;

    [Space(5), Header("Reward")]
    public int coinReward;

    [Space(5), Header("Treasure")]
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
            ConsoleLog.LogError($"LevelConfigs.GetLevelData: {e.Message}   {levelId}");
            return levelDatas[0];
        }
    }

    public LevelData[] getLevelDatas()
    {
        return levelDatas;
    }
}
