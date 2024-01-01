using Cysharp.Threading.Tasks;
using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadHomeToGameController", menuName = "HunterTreasure/LoadGame/LoadHomeToGameController")]
public sealed class LoadHomeToGameController : BaseLoadGameController
{
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;
    [SerializeField] private ExplorerManager explorerManager;
    [SerializeField] private LevelConfigs levelConfig;
    [SerializeField] private CommonMapData commonMapData;


    private AsyncOperationHandle<SceneInstance> loadHandle;
    private AsyncOperationHandle<SceneInstance> loadSceneGameHandler;

    protected override async UniTask OnBeforeLoad()
    {
        await base.OnBeforeLoad();

        loadHandle = Addressables.LoadSceneAsync(LoadSceneController.SCENE_LOADING, LoadSceneMode.Additive);
        await UniTask.WaitUntil(() => loadHandle.IsDone);
        if (loadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            await SceneManager.UnloadSceneAsync(LoadSceneController.SCENE_HOME);
        }
    }

    protected override async UniTask OnLoad()
    {
        await base.OnLoad();

        await LoadSceneGame();

        // setup scene game
        await CreateMap();

        await CreateExplorer();

        await SetupUI();

        Messenger.Default.Publish(new LoadingProgressPayload() { progress = 1f });

        // unload loading scene
        if (loadSceneGameHandler.Status == AsyncOperationStatus.Succeeded)
        {
            await Addressables.UnloadSceneAsync(loadHandle);
        }
    }

    protected override async UniTask OnAfterLoad()
    {
        await base.OnAfterLoad();
    }

    private async UniTask LoadSceneGame()
    {
        // Load scene game
        loadSceneGameHandler = Addressables.LoadSceneAsync(LoadSceneController.SCENE_GAME, LoadSceneMode.Additive);
        await UniTask.WaitUntil(() => loadSceneGameHandler.IsDone);
        if (loadSceneGameHandler.Status == AsyncOperationStatus.Succeeded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(LoadSceneController.SCENE_GAME));
        }
    }

    private async UniTask CreateMap()
    {
        LevelData levelData = levelConfig.GetLevelData(runtimeGlobalData.DataStartGamePlay.LevelId);
        AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(levelData.prefabRef);

        await UniTask.WaitUntil(() => handle.IsDone);
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject mapInstance = handle.Result;
            mapInstance.transform.position = Vector3.zero;
        }
    }

    private async UniTask CreateExplorer()
    {
        await UniTask.WaitUntil(() => commonMapData.IsDoneAssignData);
        AssetReferenceT<GameObject> explorerRef = explorerManager.GetExplorer(runtimeGlobalData.DataStartGamePlay.Explorer);

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
            commonMapData.IsCompleteCreateExplorer = true;
        }
    }

    private async UniTask SetupMapData()
    {

    }


    private async UniTask SetupUI()
    {

    }
}
