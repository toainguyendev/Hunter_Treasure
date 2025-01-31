using UnityEngine;


[CreateAssetMenu(fileName = "CommonMapData", menuName = "HunterTreasure/Level/CommonMapData")]
public class CommonMapData : ScriptableObject
{
    private Vector3 playerSpawnPosition;
    private bool isDoneAssignData = false;
    private Transform explorerTransform;
    private bool isCompleteCreateExplorer = false;



    // getter and setter
    public Vector3 PlayerSpawnPosition
    {
        get => playerSpawnPosition;
        set => playerSpawnPosition = value;
    }
    public bool IsDoneSetupMap
    {
        get => isDoneAssignData;
        set => isDoneAssignData = value;
    }
    public Transform ExplorerTransform
    {
        get => explorerTransform;
        set => explorerTransform = value;
    }

    public bool IsCompleteCreateExplorer
    {
        get => isCompleteCreateExplorer;
        set => isCompleteCreateExplorer = value;
    }

    public void ResetData()
    {
        isDoneAssignData = false;
        isCompleteCreateExplorer = false;
    }
}
