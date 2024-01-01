using UnityEngine;


[CreateAssetMenu(fileName = "CommonMapData", menuName = "HunterTreasure/Level/CommonMapData")]
public class CommonMapData : ScriptableObject
{
    // position to spawn player
    [SerializeField] private Vector3 playerSpawnPosition;
    public Vector3 PlayerSpawnPosition => playerSpawnPosition;
}
