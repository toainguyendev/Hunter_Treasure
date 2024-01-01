using Cysharp.Threading.Tasks;
using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadHomeToGameController", menuName = "HunterTreasure/LoadGame/LoadHomeToGameController")]
public class LoadHomeToGameController : BaseLoadGameController
{
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;
    [SerializeField] private ExplorerManager explorerManager;


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

        // Load scene game
        loadSceneGameHandler = Addressables.LoadSceneAsync(LoadSceneController.SCENE_GAME, LoadSceneMode.Additive);
        await UniTask.WaitUntil(() => loadSceneGameHandler.IsDone);
        if(loadSceneGameHandler.Status == AsyncOperationStatus.Succeeded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(LoadSceneController.SCENE_GAME));
        }

        // instantiate explorer
        GameObject explorerInstance = await explorerManager.GetExplorer(runtimeGlobalData.DataStartGamePlay.Explorer);

        await UniTask.Delay(4000);

        Messenger.Default.Publish(new LoadingProgressPayload() { progress = 1f });

        // Setup scene with RuntimeGlobalData
        ConsoleLog.Log($"Setup scene with RuntimeGlobalData");
        if (loadSceneGameHandler.Status == AsyncOperationStatus.Succeeded)
        {
            await Addressables.UnloadSceneAsync(loadHandle);
        }
    }

    protected override async UniTask OnAfterLoad()
    {
        await base.OnAfterLoad();

        
    }


}
