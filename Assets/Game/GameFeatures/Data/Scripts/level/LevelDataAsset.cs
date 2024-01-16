using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelDataAsset", menuName = "HunterTreasure/Data/LevelDataAsset")]
public class LevelDataAsset : BaseDataAsset<LevelDataModel>
{
    // Start is called before the first frame update
    [SerializeReference] private List<LevelUpData> levelUpDatas;
    [SerializeReference] private ExplorerManager explorerManager;

    public List<PlayerLevel> PlayerLevels => dataModel.playerLevels;

    public void levelUp(ExplorerType explorer)
    {
        dataModel.levelUp(explorer);
        SaveData();
    }

    public int getCurrentLevel(ExplorerType explorer)
    {
        PlayerLevel playerLevel = PlayerLevels.Find(PlayerLevel => PlayerLevel.explorer == explorer);
        return playerLevel.level;
    }

    public ExplorerBaseInfo GetExplorerBaseInfoWithLevel(ExplorerType explorer, int level = 0)
    {
        ExplorerBaseInfo explorerBaseInfo = explorerManager.GetExplorerBaseInfo(explorer);

        PlayerLevel playerLevel = PlayerLevels.Find(PlayerLevel => PlayerLevel.explorer == explorer);

        // clone from explorerBaseInfo
        ExplorerBaseInfo result = explorerBaseInfo.Clone();
        int levelInfo = level == 0 ? playerLevel.level : level;

        if (levelInfo - 1 < levelUpDatas.Count )
        {
            result.HP += result.HP * levelUpDatas[levelInfo-1].HP / 100;
            result.Attack += result.Attack * levelUpDatas[levelInfo-1].Attack / 100;
            result.RateAttack += result.RateAttack * levelUpDatas[levelInfo - 1].RateAttack / 100;
            result.Defense += result.Defense * levelUpDatas[levelInfo - 1].Defense / 100;
            result.AttackRange += result.AttackRange * levelUpDatas[levelInfo - 1].AttackRange / 100;
            result.MoveSpeed += result.MoveSpeed * levelUpDatas[levelInfo - 1].MoveSpeed / 100;
            result.JumpVelocity += result.JumpVelocity * levelUpDatas[levelInfo - 1].JumpVelocity / 100;
        }

        return result;
    }

    public LevelUpData GetIncreateExplorerBaseInfoBetweenLevel(ExplorerType explorer)
    {
        ExplorerBaseInfo explorerBaseInfo = explorerManager.GetExplorerBaseInfo(explorer);

        PlayerLevel playerLevel = PlayerLevels.Find(PlayerLevel => PlayerLevel.explorer == explorer);

        LevelUpData result = new LevelUpData();

        if (playerLevel.level < levelUpDatas.Count)
        {
            result.HP = explorerBaseInfo.HP * (levelUpDatas[playerLevel.level].HP - levelUpDatas[playerLevel.level - 1].HP) / 100;
            result.Attack = explorerBaseInfo.Attack * (levelUpDatas[playerLevel.level].Attack - levelUpDatas[playerLevel.level - 1].Attack) / 100;
            result.RateAttack = explorerBaseInfo.RateAttack * (levelUpDatas[playerLevel.level].RateAttack - levelUpDatas[playerLevel.level - 1].RateAttack) / 100;
            result.Defense = explorerBaseInfo.Defense * (levelUpDatas[playerLevel.level ].Defense - levelUpDatas[playerLevel.level - 1].Defense) / 100;
            result.AttackRange = explorerBaseInfo.AttackRange * (levelUpDatas[playerLevel.level].AttackRange - levelUpDatas[playerLevel.level - 1].AttackRange) / 100;
            result.MoveSpeed = explorerBaseInfo.MoveSpeed * (levelUpDatas[playerLevel.level].MoveSpeed - levelUpDatas[playerLevel.level - 1].MoveSpeed) / 100;
            result.JumpVelocity = explorerBaseInfo.JumpVelocity * (levelUpDatas[playerLevel.level].JumpVelocity - levelUpDatas[playerLevel.level - 1].JumpVelocity) / 100;
            result.Price = levelUpDatas[playerLevel.level].Price;
        }
        return result;
    }

}
