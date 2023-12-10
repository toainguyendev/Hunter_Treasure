using System;
using UnityEngine;
using UnityEngine.AddressableAssets;


public enum TreasureType
{
    Mine,
    Trap,
    Potion,
    Weapon,
    Armor,
    Accessory,
    Material,
    Quest,
    Other
}


[Serializable]
public struct TreasureData
{
    public TreasureType treasureType;
    public string treasureName;
    public string description;
    public AssetReferenceT<GameObject> prefabRef;
    public AssetReferenceT<Sprite> avatarRef;
}

[CreateAssetMenu(fileName = "TreasureHolderData", menuName = "HunterTreasure/Treasure/TreasureHolderData")]
public class TreasureHolderData : ScriptableObject
{
    // serialize field list treasure data
    [SerializeField] private TreasureData[] treasureDatas;

    public TreasureData GetTreasureData(TreasureType treasureType)
    {
        // loop through treasureDatas
        foreach (var treasureData in treasureDatas)
        {
            // if treasureData.treasureType == treasureType
            if (treasureData.treasureType == treasureType)
            {
                // return treasureData
                return treasureData;
            }
        }

        // return null
        return default;
    }
}
