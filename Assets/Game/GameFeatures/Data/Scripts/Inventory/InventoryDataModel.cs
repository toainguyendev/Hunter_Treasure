
using System;

[Serializable]
public struct InventoryDataModel : IDataModel<InventoryDataModel>
{
    public int coin;

    public void SetDefaultData()
    {
        coin = 0;
    }
}
