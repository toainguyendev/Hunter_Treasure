using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadStartToHomeController", menuName = "HunterTreasure/LoadGame/LoadStartToHomeController")]
public class LoadStartToHomeController : BaseLoadGameController
{
    [SerializeField] private List<BaseDataAsset> importantDatas;
    private AsyncOperationHandle<SceneInstance> loadHandle;

    protected override async UniTask OnBeforeLoad()
    {
        await base.OnBeforeLoad();
    }

    protected override async UniTask OnLoad()
    {
        await base.OnLoad();

        ConsoleLog.Log("Start load data");
        await LoadDataAsset();
        ConsoleLog.Log("Done load data");
    }


    protected override async UniTask OnAfterLoad()
    {
        await base.OnAfterLoad();
        loadHandle = Addressables.LoadSceneAsync(LoadSceneController.SCENE_HOME, LoadSceneMode.Additive);

        loadHandle.Completed += (handle) =>
        {
            if(handle.Status == AsyncOperationStatus.Succeeded)
            {
                SceneManager.UnloadSceneAsync(LoadSceneController.SCENE_START);
            }
        };
    }


    private async UniTask LoadDataAsset()
    {
        foreach (var data in importantDatas)
        {
            data.LoadData();
            await UniTask.WaitUntil(() => data.IsDoneLoadData);
        }
    }
}