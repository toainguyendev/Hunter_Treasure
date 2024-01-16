using Cysharp.Threading.Tasks;
using SuperMaxim.Messaging;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadStartToHomeController", menuName = "HunterTreasure/LoadGame/LoadStartToHomeController")]
public class LoadStartToHomeController : BaseLoadGameController
{
    [SerializeField] private List<BaseDataAsset> importantDatas;

    private float percentLoading = 0;
    protected override async UniTask OnBeforeLoad()
    {
        await base.OnBeforeLoad();
        percentLoading = 0f;

        // Load scene loading
        LoadSceneController.loadingSceneHandler = Addressables.LoadSceneAsync(LoadSceneController.SCENE_LOADING, LoadSceneMode.Additive);
        await UniTask.WaitUntil(() => LoadSceneController.loadingSceneHandler.IsDone);
        if (LoadSceneController.loadingSceneHandler.Status == AsyncOperationStatus.Succeeded)
        {
            await SceneManager.UnloadSceneAsync(LoadSceneController.SCENE_START);
        }
    }

    protected override async UniTask OnLoad()
    {
        await base.OnLoad();

        await LoadDataAsset();

        await LoadSceneHome();

        SetupUI();
    }


    protected override async UniTask OnAfterLoad()
    {
        await base.OnAfterLoad();

        await UnloadLoadingScene();
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
            await UniTask.Delay(500);
            ConsoleLog.Log($"Load data {data.name} done");
        }
    }

    private void SetupUI()
    {
        UIManager.Instance.ShowModal(ModalType.HOME);
    }

    private async UniTask LoadSceneHome()
    {
        LoadSceneController.homeHandler = Addressables.LoadSceneAsync(LoadSceneController.SCENE_HOME, LoadSceneMode.Additive);
        await UniTask.WaitUntil(() => LoadSceneController.homeHandler.IsDone);
        if (LoadSceneController.homeHandler.Status == AsyncOperationStatus.Succeeded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(LoadSceneController.SCENE_HOME));
        }
    }

    private async UniTask UnloadLoadingScene()
    {
        if (LoadSceneController.homeHandler.Status == AsyncOperationStatus.Succeeded)
        {
            await Addressables.UnloadSceneAsync(LoadSceneController.loadingSceneHandler);
        }
    }
}