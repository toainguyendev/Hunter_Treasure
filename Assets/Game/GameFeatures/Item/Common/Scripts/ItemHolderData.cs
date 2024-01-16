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
    [SerializeField] private ItemBase itemSkill;

	// public getter properties ItemType, ItemData, AssetReferenceT<GameObject> itemPrefab
	public ItemType ItemType => itemType;
    public ItemBaseData ItemData => itemData;
    public AssetReferenceT<GameObject> ItemPrefab => itemPrefab;
    public ItemBase ItemSkill => itemSkill;

}

[CreateAssetMenu(fileName = "ItemHolderData", menuName = "HunterTreasure/Item/ItemHolderData", order = 1)]
public class ItemHolderData : ScriptableObject
{
    [SerializeField] private List<ItemHolder> itemHolders;

    public List<ItemHolder> ItemHolders => itemHolders;

	// method find item holder with itemtype
	public ItemHolder GetItemHolder(ItemType itemType)
    {
        for (int i = 0; i < itemHolders.Count; i++)
        {
            if (itemHolders[i].ItemType == itemType)
                return itemHolders[i];
        }
        return null;
    }
}
