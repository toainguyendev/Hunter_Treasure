using SuperMaxim.Messaging;
using UnityEngine;

public struct EndGamePayload
{
    public bool isWin;
}

public class GameController : MonoBehaviour
{
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;

    private bool _isEndGame = false;
    private void Start()
    {
        Messenger.Default.Subscribe<EndGamePayload>(OnEndGame);
        _isEndGame = false;
    }

    private void OnEndGame(EndGamePayload endgamePayload)
    {
        if(_isEndGame)
            return;
        InGameUI.Instance.Hide();
        UIManager.Instance.ShowModal(ModalType.RESULT);
        _isEndGame = true;
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
