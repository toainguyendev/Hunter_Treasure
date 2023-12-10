
using System;
using System.Collections.Generic;

public struct ItemLevel
{
    public ItemType itemType;
    public int level;
    public bool isUnlocked;
}

[Serializable]
public struct ItemDataModel : IDataModel<ItemDataModel>
{
    public List<ItemLevel> itemsOwnedLevel;

    public void SetDefaultData()
    {
        // loop all item type to set default data
        itemsOwnedLevel = new List<ItemLevel>();
        foreach (ItemType itemType in Enum.GetValues(typeof(ItemType)))
        {
            ItemLevel itemLevel = new ItemLevel();
            itemLevel.itemType = itemType;
            itemLevel.level = 1;
            itemLevel.isUnlocked = true;
            itemsOwnedLevel.Add(itemLevel);
        }
    }
}
