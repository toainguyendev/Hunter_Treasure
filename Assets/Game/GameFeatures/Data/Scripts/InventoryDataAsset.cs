using UnityEngine;


[CreateAssetMenu(fileName = "InventoryDataAsset", menuName = "Hunter Treaser/Data/InventoryDataAsset")]
public class InventoryDataAsset : AbstractDataAsset<InventoryDataModel>
{
    public int Coin => dataModel.coin;

    public void TryChangeCoin(int amountChange)
    {
        dataModel.coin = dataModel.coin + amountChange;
        if (dataModel.coin < 0)
            dataModel.coin = 0;

        SaveData();
    }
}
