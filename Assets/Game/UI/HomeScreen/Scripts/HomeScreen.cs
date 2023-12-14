using UnityEngine;

public class HomeScreen : MonoBehaviour
{
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;

    // Load SceneGame when click button
    public void OnClickPlay()
    {
        // Pass data


        // Load scene
        LoadSceneController.Instance.LoadHomeToGame();
    }
}
