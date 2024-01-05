using UnityEngine;

public class EnemyStateManagement : MonoBehaviour
{
    private bool _isSeeingPlayer;
    private bool _isAttackingPlayer;

    public bool IsSeeingPlayer
    {
        get => _isSeeingPlayer;
        set
        {
            _isSeeingPlayer = value;
        }
    }
    public bool IsAttackingPlayer
    {
        get => _isAttackingPlayer;
        set
        {
            _isAttackingPlayer = value;
        }
    }
}
