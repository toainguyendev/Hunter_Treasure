using SuperMaxim.Messaging;
using UnityEngine;

public struct EndGamePayload
{
    public bool isWin;
}

public class GameController : MonoBehaviour
{
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;

    private void Start()
    {
        Messenger.Default.Subscribe<EndGamePayload>(OnEndGame);
    }

    private void OnEndGame(EndGamePayload endgamePayload)
    {
        runtimeGlobalData.DataEndGame = new DataEndGame(true, runtimeGlobalData.DataStartGamePlay.LevelId, runtimeGlobalData.DataStartGamePlay.Explorer);
        InGameUI.Instance.Hide();
        UIManager.Instance.ShowModal(ModalType.RESULT);
    }

    private void OnDestroy()
    {
        Messenger.Default.Unsubscribe<EndGamePayload>(OnEndGame);
    }

#if UNITY_EDITOR
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            runtimeGlobalData.DataEndGame = new DataEndGame(false, runtimeGlobalData.DataStartGamePlay.LevelId, runtimeGlobalData.DataStartGamePlay.Explorer);
            InGameUI.Instance.Hide();
            UIManager.Instance.ShowModal(ModalType.RESULT);
        }
    }
#endif
}
