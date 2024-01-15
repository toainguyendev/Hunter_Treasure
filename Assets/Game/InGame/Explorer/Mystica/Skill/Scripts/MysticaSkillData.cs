using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "MysticaSkillData", menuName = "HunterTreasure/Explorer/Mystica/Skill/MysticaSkillData")]
public class MysticaSkillData : SkillData
{
    [SerializeField] private float _damagePerSecond;
    [SerializeField] private float _rangeHeight;
    [SerializeField] private float _rangeWidth;
    [SerializeField] private AssetReferenceT<GameObject> _skillPrefab;

    // public getter for above properties
    public float DamagePerSecond => _damagePerSecond;
    public float RangeHeight => _rangeHeight;
    public float RangeWidth => _rangeWidth;
    public AssetReferenceT<GameObject> SkillPrefab => _skillPrefab;
}
