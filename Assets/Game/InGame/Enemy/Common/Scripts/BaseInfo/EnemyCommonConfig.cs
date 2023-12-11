
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyCommonConfig", menuName = "HunterTreasure/Enemy/EnemyCommonConfig")]
public class EnemyCommonConfig : ScriptableObject
{
    // time to wait before checking for player again
    [SerializeField] private float _waitTimeCheckSight = 0.2f;


    // public getters
    public float WaitTimeCheckSight => _waitTimeCheckSight;
}
