using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

public enum ExplorerType
{
    None,
    Bishop,
    Mystica,
    TheRock
}

[Serializable]
public struct ExplorerHolderData
{
    public ExplorerType explorer;
    public AssetReferenceT<GameObject> explorerPrefab;
    public AssetReferenceT<GameObject> explorerDisplayPrefab;
    public ExplorerBaseInfo explorerBaseInfo;
}


[CreateAssetMenu(fileName = "ExplorerManager", menuName = "HunterTreasure/Explorer/ExplorerManager", order = 1)]
public class ExplorerManager : ScriptableObject
{
    // List Explorer holder data
    [SerializeField] private ExplorerHolderData[] _explorerHolderDatas;

    // getter for explorer holder data
    public ExplorerHolderData[] ExplorerHolderDatas { get => _explorerHolderDatas; }


    // method to instantiate explorer with addressable, disable the instance and return that instance
    public AssetReferenceT<GameObject> GetExplorerModelRef(ExplorerType explorer)
    {
        // find explorer holder data with explorer type
        ExplorerHolderData explorerHolderData = Array.Find(_explorerHolderDatas, x => x.explorer == explorer);
        return explorerHolderData.explorerPrefab;
    }

    public ExplorerBaseInfo[] GetAllExplorerBaseInfo() { 
        return Array.ConvertAll(_explorerHolderDatas, x => x.explorerBaseInfo);
    }

    // method to instantiate explorer display with addressable, disable the instance and return that instance
    public AssetReferenceT<GameObject> GetExplorerDisplay(ExplorerType explorer)
    {
        // find explorer holder data with explorer type
        ExplorerHolderData explorerHolderData = Array.Find(_explorerHolderDatas, x => x.explorer == explorer);
        return explorerHolderData.explorerDisplayPrefab;
    }

    public ExplorerBaseInfo GetExplorerBaseInfo(ExplorerType explorerType)
    {
        // find explorer holder data with explorer type
        ExplorerHolderData explorerHolderData = Array.Find(_explorerHolderDatas, x => x.explorer == explorerType);
        return explorerHolderData.explorerBaseInfo;
    }
}
