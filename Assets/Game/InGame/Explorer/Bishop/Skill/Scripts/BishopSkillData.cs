using UnityEngine;


[CreateAssetMenu(fileName = "BishopSkillData", menuName = "HunterTreasure/Explorer/Bishop/Skill/BishopSkillData")]
public class BishopSkillData : SkillData
{
    [SerializeField] private float _damagePerSecond;
    [SerializeField] private float _damageRange;


    // public getter for above properties
    public float DamagePerSecond => _damagePerSecond;

    public float DamageRange => _damageRange;
}
