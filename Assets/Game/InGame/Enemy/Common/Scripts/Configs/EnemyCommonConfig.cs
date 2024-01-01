
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyCommonConfig", menuName = "HunterTreasure/Enemy/EnemyCommonConfig")]
public class EnemyCommonConfig : ScriptableObject
{
    // time to wait before checking for player again
    [SerializeField] private float _waitTimeCheckSight = 0.2f;
    [SerializeField] private float _speedRotate = 50f;
    [SerializeField] private float _timeForgotPlayer = 1.5f;


    // public getters
    public float WaitTimeCheckSight => _waitTimeCheckSight;
    public float SpeedRotate => _speedRotate;
    public float TimeForgotPlayer => _timeForgotPlayer;
}
