using UnityEngine;


public enum CurrencyType
{
    Coin,
    Diamond,
}

[CreateAssetMenu(fileName = "InventoryDataAsset", menuName = "HunterTreasure/Data/InventoryDataAsset")]
public class InventoryDataAsset : BaseDataAsset<InventoryDataModel>
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
