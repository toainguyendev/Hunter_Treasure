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
}


[CreateAssetMenu(fileName = "ExplorerManager", menuName = "HunterTreasure/Explorer/ExplorerManager", order = 1)]
public class ExplorerManager : ScriptableObject
{
    // List Explorer holder data
    [SerializeField] private ExplorerHolderData[] _explorerHolderDatas;


    // method to instantiate explorer with addressable, disable the instance and return that instance
    public GameObject GetExplorer(ExplorerType explorer)
    {
        // find explorer holder data with explorer type
        ExplorerHolderData explorerHolderData = Array.Find(_explorerHolderDatas, x => x.explorer == explorer);

        // instantiate explorer with addressable
        GameObject explorerInstance = Addressables.InstantiateAsync(explorerHolderData.explorerPrefab).Result;

        // disable explorer instance
        explorerInstance.SetActive(false);

        // return explorer instance
        return explorerInstance;
    }
}
