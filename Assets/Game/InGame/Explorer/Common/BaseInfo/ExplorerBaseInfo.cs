using UnityEngine;

[CreateAssetMenu(fileName = "ExplorerBaseInfo", menuName = "HunterTreasure/Explorer/Player/ExplorerBaseInfo")]
public class ExplorerBaseInfo
    : ScriptableObject
{
    // private properties: Name, HP, Attack, Rate Attack, Defense, Attack Range, Move Speed
    [SerializeField] private string _name;
    [SerializeField] private int _hp;
    [SerializeField] private int _attack;
    [SerializeField] private float _rateAttack;
    [SerializeField] private int _defense;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private Sprite imageThumbnail;
    [SerializeField] private SkillData skillData;

    // public getters and setters for private properties
    public string Name { get => _name; set => _name = value; }
    public int HP { get => _hp; set => _hp = value; }
    public int Attack { get => _attack; set => _attack = value; }
    public float RateAttack { get => _rateAttack; set => _rateAttack = value; }
    public int Defense { get => _defense; set => _defense = value; }
    public float AttackRange { get => _attackRange; set => _attackRange = value; }
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public float JumpVelocity { get => jumpVelocity; set => jumpVelocity = value; }
    public Sprite ImageThumbnail { get => imageThumbnail; set => imageThumbnail = value; }
    public SkillData SkillData { get => skillData; set => skillData = value; }

    public ExplorerBaseInfo Clone()
    {
        ExplorerBaseInfo result = new ExplorerBaseInfo();
        result.Name = Name;
        result.HP = HP;
        result.Attack = Attack;
        result.RateAttack = RateAttack;
        result.Defense = Defense;
        result.AttackRange = AttackRange;
        result.MoveSpeed = MoveSpeed;
        result.JumpVelocity = JumpVelocity;
        result.ImageThumbnail = ImageThumbnail;
        result.SkillData = SkillData;
        return result;
    }
}
