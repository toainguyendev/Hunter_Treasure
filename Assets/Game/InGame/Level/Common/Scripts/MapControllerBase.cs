using UnityEngine;

public class MapControllerBase : MonoBehaviour
{
    [Header("Map Info")]
    [SerializeField] private Transform _spawnExplorerPos;

    [Space(10)]
    [SerializeField] private BaseCondition[] _conditionWins;

    [Header("Data")]
    [SerializeField] private CommonMapData commonMapData;

    private void Awake()
    {
        SetupGlobalMapData();
    }

    private void SetupGlobalMapData()
    {
        commonMapData.PlayerSpawnPosition = _spawnExplorerPos.position;

        commonMapData.IsDoneAssignData = true;
    }


    private bool CheckAllConditionWin()
    {
        foreach (var conditionWin in _conditionWins)
        {
            if (!conditionWin.IsPassCondition)
            {
                return false;
            }
        }

        return true;
    }
}
