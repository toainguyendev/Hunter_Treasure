using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct BloodItemDataStruct
{
    // private properties range, damage
    [SerializeField] private int range;
    [SerializeField] private int damage;

    // public getter for range, damage
    public int Range => range;
    public int Damage => damage;
}

[CreateAssetMenu(fileName = "BloodItemData", menuName = "HunterTreasure/Item/BloodItemData")]
public class BloodItemData : ItemBaseData
{
    // List MineItemDataStruct
    [SerializeField] private List<BloodItemDataStruct> bloodItemDatas;

    // public method getMineItemDataStructs at index with try catch
    public BloodItemDataStruct GetBloodItemDataStructs(int index)
    {
        try
        {
            return bloodItemDatas[index];
        }
        catch
        {
            ConsoleLog.LogError($"BloodItemDataStructs index {index} not found, returning index 0");
            return bloodItemDatas[0];
        }
    }
}
