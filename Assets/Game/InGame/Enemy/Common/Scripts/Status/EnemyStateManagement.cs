using UnityEngine;

public class EnemyStateManagement : MonoBehaviour
{
    private bool _isSeeingPlayer;
    private bool _isAttackingPlayer;
    private bool _isDead;
    private bool _isAtractived;

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
    public bool IsDead
    {
        get => _isDead;
        set
        {
            _isDead = value;
        }
    }
	public bool IsAttractived
	{
		get => _isAtractived;
		set
		{
			_isAtractived = value;
		}
	}
}
