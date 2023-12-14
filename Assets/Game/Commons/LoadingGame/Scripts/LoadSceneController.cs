using UnityEngine;

public class LoadSceneController : MonoSingleton<LoadSceneController>
{
    [SerializeField] private BaseLoadGameController loadingStartToHomeController;
    [SerializeField] private BaseLoadGameController loadingHomeToGameController;

    public static string SCENE_START = "Login";
    public static string SCENE_LOADING = "LoadingScene";
    public static string SCENE_HOME = "Home";
    public static string SCENE_GAME = "Game";
    public static string SCENE_REWARD = "Reward";

    protected override void Awake()
    {
        base.Awake();
        LoadStartToHome();
    }

    public async void LoadStartToHome()
    {
        await loadingStartToHomeController.LoadGame();
    }

    public async void LoadHomeToGame()
    {
        await loadingHomeToGameController.LoadGame();
    }

    public async void LoadGameToReward()
    {
        await loadingStartToHomeController.LoadGame();
    }

    public async void LoadRewardToHome()
    {
        await loadingStartToHomeController.LoadGame();
    }

    public async void LoadGameToHome()
    {
        await loadingStartToHomeController.LoadGame();
    }   
}
