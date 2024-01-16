using System.Collections.Generic;
using UnityEngine;


public struct DataStartGamePlay
{
    private int levelId;
    private ExplorerType explorer;
    private List<KeyValuePair<ItemType, int>> itemsType;

    public DataStartGamePlay(int levelId, ExplorerType explorer, List<KeyValuePair<ItemType, int>> itemsType = null)
    {
        this.levelId = levelId;
        this.explorer = explorer;
        this.itemsType = itemsType;
    }

    // public getters and setters for private properties
    public int LevelId { get => levelId; set => levelId = value; }
    public ExplorerType Explorer { get => explorer; set => explorer = value; }
    public List<KeyValuePair<ItemType, int>> ItemsType { get => itemsType; set => itemsType = value; }
}

public struct DataEndGame
{
    private bool isWin;

    // info explorer
    private int levelId;
    private ExplorerType explorer;


    public DataEndGame(bool isWin, int levelId, ExplorerType explorer)
    {
        this.isWin = isWin;
        this.levelId = levelId;
        this.explorer = explorer;
    }

    // public getters and setters for private properties    
    public bool IsWin { get => isWin; set => isWin = value; }
    public int LevelId { get => levelId; set => levelId = value; }
    public ExplorerType Explorer { get => explorer; set => explorer = value; }
}

public struct DataInHome
{
    public ExplorerType explorer;

    DataInHome(ExplorerType explorer = ExplorerType.None)
    {
        this.explorer = explorer;
    }
}

[CreateAssetMenu(fileName = "RuntimeGlobalData", menuName = "HunterTreasure/Global/RuntimeGlobalData")]
public class RuntimeGlobalData : ScriptableObject
{
    private DataStartGamePlay dataStartGamePlay;
    private DataEndGame dataEndGame;
    private DataInHome dataInHome;

    // public getters and setters for private properties
    public DataStartGamePlay DataStartGamePlay { get => dataStartGamePlay; set => dataStartGamePlay = value; }
    public DataEndGame DataEndGame { get => dataEndGame; set => dataEndGame = value; }
    public DataInHome DataInHome { get => dataInHome; set => dataInHome = value; }

    private void OnEnable()
    {
        dataStartGamePlay = new DataStartGamePlay();
        dataEndGame = new DataEndGame();
        dataInHome = new DataInHome();
    }

    #region DataInHome
    public void SetChoseExplorer(ExplorerType explorer)
    {
        dataInHome.explorer = explorer;
    }
    #endregion
}
