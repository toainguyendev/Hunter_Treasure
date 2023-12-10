
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryDataAsset", menuName = "HunterTreasure/Data/ItemDataAsset")]
public class ItemDataAsset : BaseDataAsset<ItemDataModel>
{
    public int GetItemLevel(ItemType itemType)
    {
        foreach (ItemLevel itemLevel in dataModel.itemsOwnedLevel)
        {
            if (itemLevel.itemType == itemType)
                return itemLevel.level;
        }

        return 0;
    }

    public void UpgradeLevelItem(ItemType itemType)
    {
        for (int i = 0; i < dataModel.itemsOwnedLevel.Count; i++)
        {
            if (dataModel.itemsOwnedLevel[i].itemType == itemType)
            {
                // Get a reference to the item
                ItemLevel item = dataModel.itemsOwnedLevel[i];

                // Modify the item
                item.level++;

                // Assign the modified item back to the list
                dataModel.itemsOwnedLevel[i] = item;

                break;
            }
        }

        SaveData();
    }
}
