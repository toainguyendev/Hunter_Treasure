using UnityEngine;
using UnityEngine.AddressableAssets;
using System;


[Serializable]
public struct LevelData
{
    public string levelName;
    public string story;

    public AssetReferenceT<GameObject> prefabRef;
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

    public LevelData[] getLevelDatas()
    {
        return levelDatas;
    }
}
