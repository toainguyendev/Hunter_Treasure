using UnityEngine;

public class MapControllerBase : MonoBehaviour
{
    [Header("Map Info")]
    [SerializeField] private Transform _spawnExplorerPos;

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
}
