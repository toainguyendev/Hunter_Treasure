using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct MineItemDataStruct
{
    // private properties range, damage
    [SerializeField] private int range;
    [SerializeField] private int damage;

    // public getter for range, damage
    public int Range => range;
    public int Damage => damage;
}

[CreateAssetMenu(fileName = "MineItemData", menuName = "HunterTreasure/Item/MineItemData")]
public class MineItemData : ItemBaseData
{
    // List MineItemDataStruct
    [SerializeField] private List<MineItemDataStruct> mineItemDataStructs;

    // public method getMineItemDataStructs at index with try catch
    public MineItemDataStruct GetMineItemDataStructs(int index)
    {
        try
        {
            return mineItemDataStructs[index];
        }
        catch
        {
            ConsoleLog.LogError($"MineItemDataStructs index {index} not found, returning index 0");
            return mineItemDataStructs[0];
        }
    }
}
