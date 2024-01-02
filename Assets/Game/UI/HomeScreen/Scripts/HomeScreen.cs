using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;

    private void Awake()
    {
        playButton.onClick.AddListener(OnClickPlay);
    }

    // Load SceneGame when click button
    public void OnClickPlay()
    {
        // Pass data
        runtimeGlobalData.DataStartGamePlay = new DataStartGamePlay(1, ExplorerType.Bishop);

        // Load scene
        LoadSceneController.Instance.LoadHomeToGame();
    }
}
