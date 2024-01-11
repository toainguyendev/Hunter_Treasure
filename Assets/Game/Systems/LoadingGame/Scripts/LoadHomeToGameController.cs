using Cysharp.Threading.Tasks;
using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadHomeToGameController", menuName = "HunterTreasure/LoadGame/LoadHomeToGameController")]
public sealed class LoadHomeToGameController : BaseLoadGameController
{
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;
    [SerializeField] private ExplorerManager explorerManager;
    [SerializeField] private LevelConfigs levelConfig;
    [SerializeField] private CommonMapData commonMapData;

    protected override async UniTask OnBeforeLoad()
    {
        await base.OnBeforeLoad();

        LoadSceneController.loadingSceneHandler = Addressables.LoadSceneAsync(LoadSceneController.SCENE_LOADING, LoadSceneMode.Additive);
        await UniTask.WaitUntil(() => LoadSceneController.loadingSceneHandler.IsDone);
        if (LoadSceneController.loadingSceneHandler.Status == AsyncOperationStatus.Succeeded)
        {
            await Addressables.UnloadSceneAsync(LoadSceneController.homeHandler);
        }
    }

    protected override async UniTask OnLoad()
    {
        await base.OnLoad();

        await LoadSceneGame();
        Messenger.Default.Publish(new LoadingProgressPayload() { progress = 0.2f });
        ResetData();
        Messenger.Default.Publish(new LoadingProgressPayload() { progress = 0.4f });

        await CreateMap();
        Messenger.Default.Publish(new LoadingProgressPayload() { progress = 0.6f });
        await CreateExplorer();
        Messenger.Default.Publish(new LoadingProgressPayload() { progress = 0.8f });
        SetupUI();
        Messenger.Default.Publish(new LoadingProgressPayload() { progress = 1f });

        // unload loading scene
        if (LoadSceneController.loadGameHandle.Status == AsyncOperationStatus.Succeeded)
        {
            await Addressables.UnloadSceneAsync(LoadSceneController.loadingSceneHandler);
        }
    }

    protected override async UniTask OnAfterLoad()
    {
        await base.OnAfterLoad();
    }

    private async UniTask LoadSceneGame()
    {
        // Load scene game
        LoadSceneController.loadGameHandle = Addressables.LoadSceneAsync(LoadSceneController.SCENE_GAME, LoadSceneMode.Additive);
        await UniTask.WaitUntil(() => LoadSceneController.loadGameHandle.IsDone);
        if (LoadSceneController.loadGameHandle.Status == AsyncOperationStatus.Succeeded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(LoadSceneController.SCENE_GAME));
        }
    }

    private async UniTask CreateMap()
    {
        LevelData levelData = levelConfig.GetLevelData(runtimeGlobalData.DataStartGamePlay.LevelId);
        AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(levelData.mapPrefabRef);

        await UniTask.WaitUntil(() => handle.IsDone);
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject mapInstance = handle.Result;
            //mapInstance.transform.position = Vector3.zero;
        }
    }

    private async UniTask CreateExplorer()
    {
        await UniTask.WaitUntil(() => commonMapData.IsDoneSetupMap);
        AssetReferenceT<GameObject> explorerRef = explorerManager.GetExplorerModelRef(runtimeGlobalData.DataStartGamePlay.Explorer);

        // instantiate explorer with addressable
        AsyncOperationHandle<GameObject> loadHandle = Addressables.InstantiateAsync(explorerRef);

        await UniTask.WaitUntil(() => loadHandle.IsDone);
        if (loadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            var explorerInstance = loadHandle.Result;
            explorerInstance = loadHandle.Result;
            explorerInstance.SetActive(false);

            // setup position
            explorerInstance.transform.position = commonMapData.PlayerSpawnPosition;

            explorerInstance.SetActive(true);

            commonMapData.ExplorerTransform = explorerInstance.transform;

            // Set camera follow explorer
            CameraController.Instance.SetTarget(explorerInstance.transform);

            commonMapData.IsCompleteCreateExplorer = true;
        }
    }

    private void SetupUI()
    {
        InGameUI.Instance.SetupUI();
    }

    private void ResetData()
    {
        commonMapData.ResetData();
    }
}
