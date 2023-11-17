
using UnityEngine;


[CreateAssetMenu(fileName = "SkillData", menuName = "HunterTreasure/Explorer/Skill/SkillData")]
public class SkillData : ScriptableObject
{
    // private properties in ISkill interface with public getters: Name, IsDonePerform, Icon, Description, CooldownTime, MaintanceTime, CastingTime, CanBeInterrupted
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _description;
    [SerializeField] private float _cooldownTime;
    [SerializeField] private float _maintanceTime;
    [SerializeField] private float _castingTime;
    [SerializeField] private bool _canBeInterrupted;

    // public getters for private properties
    public string Name => _name;
    public Sprite Icon => _icon;
    public string Description => _description;
    public float CooldownTime => _cooldownTime;
    public float MaintanceTime => _maintanceTime;
    public float CastingTime => _castingTime;
    public bool CanBeInterrupted => _canBeInterrupted;

}
