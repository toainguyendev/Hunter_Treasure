using Cysharp.Threading.Tasks;
using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadGameToHomeController", menuName = "HunterTreasure/LoadGame/LoadGameToHomeController")]
public class LoadGameToHome : BaseLoadGameController
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

        Messenger.Default.Publish<LoadingProgressPayload>(new LoadingProgressPayload { progress = 0.6f });
        await LoadSceneHome();

        Messenger.Default.Publish<LoadingProgressPayload>(new LoadingProgressPayload { progress = 0.8f });
        SetupUI();
        Messenger.Default.Publish<LoadingProgressPayload>(new LoadingProgressPayload { progress = 1f });
    }

    protected override async UniTask OnAfterLoad()
    {
        await base.OnAfterLoad();

        await Addressables.UnloadSceneAsync(LoadSceneController.loadingSceneHandler);
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

    private void SetupUI()
    {
        UIManager.Instance.ShowModal(ModalType.HOME);
    }
}
