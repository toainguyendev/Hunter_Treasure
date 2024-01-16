using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.AI;

public class MapControllerBase : MonoBehaviour
{
    [Header("Map Info")]
    [SerializeField] private Transform _spawnExplorerPos;

    [Space(10)]
    [SerializeField] private BaseCondition[] _conditionWins;

    [Header("Data")]
    [SerializeField] private CommonMapData commonMapData;
    [SerializeField] private RuntimeGlobalData runtimeGlobalData;


    private void Awake()
    {
        SetupGlobalMapData();
    }

    private void SetupGlobalMapData()
    {
        this.transform.position = Vector3.zero;
        commonMapData.PlayerSpawnPosition = _spawnExplorerPos.position;

        commonMapData.IsDoneSetupMap = true;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            Messenger.Default.Publish<EndGamePayload>(new EndGamePayload() { isWin = true });
        }
#endif
        if (CheckAllConditionWin())
        {
            runtimeGlobalData.DataEndGame = new DataEndGame(true, runtimeGlobalData.DataStartGamePlay.LevelId, runtimeGlobalData.DataStartGamePlay.Explorer);
            Messenger.Default.Publish<EndGamePayload>(new EndGamePayload() { isWin = true });
        }
    }

    private bool _isEndGame = false;
    private bool CheckAllConditionWin()
    {
        if (_isEndGame)
            return false;

        foreach (var conditionWin in _conditionWins)
        {
            if (!conditionWin.IsPassCondition)
            {
                return false;
            }
        }

        _isEndGame = true;
        return true;
    }

}
