using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadGameToResultController", menuName = "HunterTreasure/LoadGame/LoadGameToResultController")]
public class LoadGameToResult : BaseLoadGameController
{
    protected override async UniTask OnBeforeLoad()
    {
        await base.OnBeforeLoad();

        LoadSceneController.loadingSceneHandler = Addressables.LoadSceneAsync(LoadSceneController.SCENE_LOADING, LoadSceneMode.Additive);
        await UniTask.WaitUntil(() => LoadSceneController.loadingSceneHandler.IsDone);
        if (LoadSceneController.loadingSceneHandler.Status == AsyncOperationStatus.Succeeded)
        {
            await Addressables.UnloadSceneAsync(LoadSceneController.loadGameHandle);
        }
    }

    protected override async UniTask OnLoad()
    {
        await base.OnLoad();

        await LoadSceneResult();
        
        await SetupUI();
    }

    private async UniTask LoadSceneResult()
    {
        // Load scene game
        LoadSceneController.rewardHandler = Addressables.LoadSceneAsync(LoadSceneController.SCENE_REWARD, LoadSceneMode.Additive);
        await UniTask.WaitUntil(() => LoadSceneController.rewardHandler.IsDone);
        if (LoadSceneController.rewardHandler.Status == AsyncOperationStatus.Succeeded)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(LoadSceneController.SCENE_REWARD));
        }
    }

    private async UniTask SetupUI()
    {
    }

    protected override async UniTask OnAfterLoad()
    {
        await base.OnAfterLoad();

        // unload loading scene
        if (LoadSceneController.rewardHandler.Status == AsyncOperationStatus.Succeeded)
        {
            await Addressables.UnloadSceneAsync(LoadSceneController.loadingSceneHandler);
        }
    }
}
