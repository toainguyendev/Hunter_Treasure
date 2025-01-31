using UnityEngine;


[CreateAssetMenu(fileName = "EnemyBaseInfo", menuName = "HunterTreasure/Enemy/EnemyBaseInfo")]
public class EnemyBaseInfo : ScriptableObject
{
    // serialize field private properties for name, hp, attack, rate attack, defense, attack range, move speed
    [SerializeField] private string _name;
    [SerializeField] private int _hp;
    [SerializeField] private int _attack;
    [SerializeField] private float _rateAttack;
    [SerializeField] private int _defense;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _moveSpeed;
    [SerializeField, Range(0, 360)] private float _angleSight;
    [SerializeField] private float _distanceSight;

    // public getters and setters for private properties
    public string Name { get => _name; set => _name = value; }
    public int HP { get => _hp; set => _hp = value; }
    public int Attack { get => _attack; set => _attack = value; }
    public float RateAttack { get => _rateAttack; set => _rateAttack = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public float AttackRange { get => _attackRange; set => _attackRange = value; }
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float AngleSight { get => _angleSight; set => _angleSight = value; }
    public float DistanceSight { get => _distanceSight; set => _distanceSight = value; }
}
