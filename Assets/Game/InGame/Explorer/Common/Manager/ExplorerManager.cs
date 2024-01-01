using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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
    public async UniTask<GameObject> GetExplorer(ExplorerType explorer)
    {
        // find explorer holder data with explorer type
        ExplorerHolderData explorerHolderData = Array.Find(_explorerHolderDatas, x => x.explorer == explorer);

        // instantiate explorer with addressable
        AsyncOperationHandle<GameObject> loadHandle = Addressables.InstantiateAsync(explorerHolderData.explorerPrefab);

        await UniTask.WaitUntil(() => loadHandle.IsDone);
        GameObject explorerInstance = null;
        if (loadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            ConsoleLog.Log($"ExplorerManager: GetExplorer: explorerInstance: {loadHandle.Result}");
            explorerInstance = loadHandle.Result;
            explorerInstance.SetActive(false);
        }

        ConsoleLog.Log($"ExplorerManager: GetExplorer: explorerInstance: {explorerInstance}");


        return explorerInstance;
    }
}
