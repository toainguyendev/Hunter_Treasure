using Cysharp.Threading.Tasks;
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

        // Setup scene with RuntimeGlobalData


    }

    protected override async UniTask OnAfterLoad()
    {
        await base.OnAfterLoad();
    }


}
