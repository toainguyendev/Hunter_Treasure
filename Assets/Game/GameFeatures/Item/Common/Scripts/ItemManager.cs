using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
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

public class ItemManager : MonoBehaviour
{
    [SerializeField] private List<ItemHolderData> itemHoldersData;
    [SerializeField] private ItemDataAsset itemDataAsset;

    private List<ItemHolder> currentlyOwnedItems;

	// getter for explorer holder data
	public List<ItemHolderData> ItemHolderData { get => itemHoldersData; }

	// public method upgrade item
	public void UpgradeItem(ItemType itemType)
    {
        // upgrade level item in ItemDataAsset
        itemDataAsset.UpgradeLevelItem(itemType);
    }
}
