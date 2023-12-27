using UnityEngine;

public class BishopSkillResilentSpirit : MonoBehaviour, ISkill
{
    [Header("Component")]
    [SerializeField] private ExplorerAnimationBase _animationController;

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

    private float countDownTimeRemainSkill = 0f;
    private float countDownTimeTriggerSkill = 0f;
    #endregion


    public void Interrupt()
    {
        ConsoleLog.Log("Cannot interrupt skill: " + Name);
    }

    public void Trigger()
    {
        if(countDownTimeTriggerSkill > 0)
        {
            ConsoleLog.Log($"Skill is in cooldown {countDownTimeTriggerSkill}");
            return;
        }
        // Setup trigger skill
        skillPerforming = true;
        countDownTimeRemainSkill = _skillData.MaintanceTime;
        countDownTimeTriggerSkill = _skillData.CooldownTime;
    }

    private void Awake()
    {
        countDownTimeTriggerSkill = float.MinValue;
    }

    private void FixedUpdate()
    {
        if (skillPerforming)
        {
            // Detect enemy around player and damage them
            Vector3 castOrigin = transform.position;
            Collider[] hitColliders = Physics.OverlapSphere(castOrigin, _skillData.DamageRange);
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].CompareTag("Enemy"))
                {
                    ConsoleLog.Log($"Hit enemy with damage {_skillData.DamagePerSecond * Time.fixedDeltaTime}");
                }
            }
            // Perform skill animation
            _animationController.PlayRotateSkill();
        }
    }

    private void Update()
    {
        if (skillPerforming)
        {
            countDownTimeRemainSkill -= Time.deltaTime;
            if (countDownTimeRemainSkill < 0)
            {
                _animationController.PlayIdle();
                // Reset trigger skill
                skillPerforming = false;
                countDownTimeRemainSkill = 0f;
            }
        }
        else
        {
            countDownTimeTriggerSkill -= Time.deltaTime;
            if (countDownTimeTriggerSkill < 0)
            {
                countDownTimeTriggerSkill = -1f;
            }
        }
    }

}
