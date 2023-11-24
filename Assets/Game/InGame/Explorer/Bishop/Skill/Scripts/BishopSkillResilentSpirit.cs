using UnityEngine;

public class BishopSkillResilentSpirit
    : SkillBase, ISkill
{
    [SerializeField] protected HealthBase _healthBase;

    [Space(12), Header("Data")]
    [SerializeField] protected BishopSkillData _skillData;
    [SerializeField] protected ExplorerBaseInfo _playerBaseInfo;

    public string Name => _skillData.Name;

    public bool IsDonePerform => !skillPerforming;

    public Sprite Icon => _skillData.Icon;

    public string Description => _skillData.Description;

    public float CooldownTime => _skillData.CooldownTime;

    public float MaintanceTime => _skillData.MaintanceTime;

    public float CastingTime => _skillData.CastingTime;

    public bool CanBeInterrupted => _skillData.CanBeInterrupted;

    #region PRIVATE PROPERTIES
    private bool skillPerforming = false;

    private float countDownTime = 0f;
    #endregion

    public void Interrupt()
    {
        ConsoleLog.Log("Cannot interrupt skill: " + Name);
    }

    public void Trigger()
    {
        // add bonus hp, attack, attackrate for explorer
        _healthBase.Heal(_skillData.BonusHP);
        _playerBaseInfo.Attack += _skillData.BonusAttack;
        _playerBaseInfo.RateAttack += _skillData.BonusRateAttack;

        // Setup trigger skill
        skillPerforming = true;
        countDownTime = _skillData.MaintanceTime;
    }

    private void Update()
    {
        if (skillPerforming)
        {
            countDownTime -= Time.deltaTime;

            if (countDownTime < 0)
            {
                // remove bonus attack, attackrate for explorer
                _playerBaseInfo.Attack -= _skillData.BonusAttack;
                _playerBaseInfo.RateAttack -= _skillData.BonusRateAttack;

                // Reset trigger skill
                skillPerforming = false;
                countDownTime = 0f;
            }
        }
    }

}
