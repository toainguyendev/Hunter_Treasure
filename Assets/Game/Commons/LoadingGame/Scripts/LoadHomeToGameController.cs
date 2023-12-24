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


    private AsyncOperationHandle<SceneInstance> loadHandle;

    protected override async UniTask OnBeforeLoad()
    {
        await base.OnBeforeLoad();

        loadHandle = Addressables.LoadSceneAsync(LoadSceneController.SCENE_LOADING, LoadSceneMode.Additive);
        loadHandle.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                SceneManager.UnloadSceneAsync(LoadSceneController.SCENE_HOME);
                isDoneLoadTempScene = true;
            }
        };
    }

    protected override async UniTask OnLoad()
    {
        await base.OnLoad();

        await UniTask.WaitUntil(() => isDoneLoadTempScene);

        await UniTask.Delay(1000);

        Messenger.Default.Publish(new LoadingProgressPayload() { progress = 1f });

        // Setup scene with RuntimeGlobalData
        ConsoleLog.Log($"Setup scene with RuntimeGlobalData");

    }

    protected override async UniTask OnAfterLoad()
    {
        await base.OnAfterLoad();

        AsyncOperationHandle<SceneInstance> loadSceneGameHandler = Addressables.LoadSceneAsync(LoadSceneController.SCENE_GAME, LoadSceneMode.Additive);

        loadSceneGameHandler.Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Addressables.UnloadSceneAsync(loadHandle);
            }
        };
    }


}
