using UnityEngine;


[CreateAssetMenu(fileName = "CommonUserDataAsset", menuName = "HunterTreasure/Data/CommonUserDataAsset")]
public class CommonUserDataAsset : BaseDataAsset<CommonUserDataModel>
{
    public int Level => dataModel.level;    

    public void UpdateLevel()
    {
        dataModel.level++;
        SaveData();
    }
}
