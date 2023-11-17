using UnityEngine;

public class LoadSceneController : MonoSingleton<LoadSceneController>
{
    [SerializeField] private BaseLoadGameController loadingStartToHomeController;

    public static string SCENE_START = "Login";
    public static string SCENE_HOME = "LoadingScene";

    protected override void Awake()
    {
        base.Awake();
        LoadStartToHome();
    }

    public async void LoadStartToHome()
    {
        await loadingStartToHomeController.LoadGame();
    }
}
