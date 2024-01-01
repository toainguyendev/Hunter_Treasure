using Cysharp.Threading.Tasks;
using SuperMaxim.Messaging;
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

    private float percentLoading = 0;
    protected override async UniTask OnBeforeLoad()
    {
        await base.OnBeforeLoad();
        percentLoading = 0f;
        loadHandle = Addressables.LoadSceneAsync(LoadSceneController.SCENE_LOADING, LoadSceneMode.Additive);
        await UniTask.WaitUntil(() => loadHandle.IsDone);
        if (loadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            await SceneManager.UnloadSceneAsync(LoadSceneController.SCENE_START);
        }
    }

    protected override async UniTask OnLoad()
    {
        await base.OnLoad();

        await LoadDataAsset();
    }


    protected override async UniTask OnAfterLoad()
    {
        await base.OnAfterLoad();

        AsyncOperationHandle<SceneInstance> loadHomeHandle = Addressables.LoadSceneAsync(LoadSceneController.SCENE_HOME, LoadSceneMode.Additive);

        loadHomeHandle.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Addressables.UnloadSceneAsync(loadHandle);
            }
        };
    }


    private async UniTask LoadDataAsset()
    {
        float percentOneStep = 1f / importantDatas.Count;
        foreach (var data in importantDatas)
        {
            data.LoadData();

            percentLoading += percentOneStep;
            Messenger.Default.Publish<LoadingProgressPayload>(new LoadingProgressPayload {progress = percentLoading});

            await UniTask.WaitUntil(() => data.IsDoneLoadData);

            // TODO: remove this line
            await UniTask.Delay(2000);
            ConsoleLog.Log($"Load data {data.name} done");
        }
    }
}