using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class ItemHolder
{
    // private properties ItemType, ItemData, AssetReferenceT<GameObject> itemPrefab
    [SerializeField] private ItemType itemType;
    [SerializeField] private ItemBaseData itemData;
    [SerializeField] private AssetReferenceT<GameObject> itemPrefab;

    // public getter properties ItemType, ItemData, AssetReferenceT<GameObject> itemPrefab
    public ItemType ItemType => itemType;
    public ItemBaseData ItemData => itemData;
    public AssetReferenceT<GameObject> ItemPrefab => itemPrefab;
}

[CreateAssetMenu(fileName = "ItemHolderData", menuName = "HunterTreasure/Item/ItemHolderData", order = 1)]
public class ItemHolderData : ScriptableObject
{
    // private properties List<ItemHolder> itemHolders
    [SerializeField] private List<ItemHolder> itemHolders;
}
