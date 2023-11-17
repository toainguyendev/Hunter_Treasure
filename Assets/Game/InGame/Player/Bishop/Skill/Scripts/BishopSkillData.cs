using UnityEngine;


[CreateAssetMenu(fileName = "BishopSkillData", menuName = "HunterTreasure/Explorer/Bishop/Skill/BishopSkillData")]
public class BishopSkillData : SkillData
{
    // private properties: Bonus Attack, Bonus HP, Bonus Rate Attack
    [SerializeField] private int _bonusAttack;
    [SerializeField] private int _bonusHP;
    [SerializeField] private float _bonusRateAttack;

    // public getters for private properties
    public int BonusAttack => _bonusAttack;
    public int BonusHP => _bonusHP;
    public float BonusRateAttack => _bonusRateAttack;
}
