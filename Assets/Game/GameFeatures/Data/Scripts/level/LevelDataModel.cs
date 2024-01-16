using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public struct PlayerLevel
{
    public ExplorerType explorer;
    public int level;
}

[Serializable]
public struct LevelDataModel : IDataModel<LevelDataModel>
{
    public List<PlayerLevel> playerLevels;

    public void SetDefaultData()
    {
        playerLevels = new List<PlayerLevel>();
        Debug.Log("SetDefaultData");
        for (int i = 0; i < Enum.GetNames(typeof(ExplorerType)).Length; i++)
        {
            Debug.Log("SetDefaultData" + i);
            PlayerLevel playerLevel = new PlayerLevel();
            playerLevel.explorer = (ExplorerType)i;
            playerLevel.level = 1;
            playerLevels.Add(playerLevel);
        }
    }

    public void levelUp(ExplorerType explorer)
    {   
        for (int i = 0; i < playerLevels.Count; i++)
        {
            if (playerLevels[i].explorer == explorer)
            {
                PlayerLevel playerLevel = new PlayerLevel();
                playerLevel.explorer = explorer;
                playerLevel.level = playerLevels[i].level + 1;
                playerLevels[i] = playerLevel;
                break;
            }
        }
    }
}
