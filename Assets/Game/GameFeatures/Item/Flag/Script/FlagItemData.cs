using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct FlagItemDataStruct
{
    // private properties range, damage
    [SerializeField] private int range;
    [SerializeField] private int damage;

    // public getter for range, damage
    public int Range => range;
    public int Damage => damage;
}

[CreateAssetMenu(fileName = "FlagItemData", menuName = "HunterTreasure/Item/FlagItemData")]
public class FlagItemData : ItemBaseData
{
    // List MineItemDataStruct
    [SerializeField] private List<FlagItemDataStruct> flagItemDatas;

    // public method getMineItemDataStructs at index with try catch
    public FlagItemDataStruct GetFlagItemDataStructs(int index)
    {
        try
        {
            return flagItemDatas[index];
        }
        catch
        {
            ConsoleLog.LogError($"FlagItemDataStructs index {index} not found, returning index 0");
            return flagItemDatas[0];
        }
    }
}
