using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "BarbarianSkillData", menuName = "HunterTreasure/Explorer/Barbarian/Skill/BarbarianSkillData")]
public class BarbarianSkillData : SkillData
{
    [SerializeField] private AssetReferenceT<GameObject> _skillPrefab;
    [SerializeField] private float range;
    [SerializeField] private float damagePerSecond;


    // public getter for above properties
    public AssetReferenceT<GameObject> SkillPrefab => _skillPrefab;
    public float DamagePerSecond => damagePerSecond;
    public float Range => range;
}
