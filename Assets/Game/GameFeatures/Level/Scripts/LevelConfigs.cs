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
}
