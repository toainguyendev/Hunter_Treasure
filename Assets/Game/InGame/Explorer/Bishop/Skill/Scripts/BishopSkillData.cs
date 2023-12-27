using UnityEngine;


[CreateAssetMenu(fileName = "BishopSkillData", menuName = "HunterTreasure/Explorer/Bishop/Skill/BishopSkillData")]
public class BishopSkillData : SkillData
{
    [SerializeField] private float _damagePerSecond;
    [SerializeField] private float _timeRemain;
    [SerializeField] private float _damageRage;


    // public getter for above properties
    public float DamagePerSecond => _damagePerSecond;
    public float TimeRemain => _timeRemain;

    public float DamageRange => _damageRage;
}
