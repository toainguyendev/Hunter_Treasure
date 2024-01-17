using SuperMaxim.Messaging;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class BarbarianSkillLavaFlow : SkillBase, ISkill
{
    [Header("Reference")]
    [SerializeField] private Transform _skillSpawnPoint;

    [Space(10), Header("Component")]
    [SerializeField] private ExplorerAnimationBase _animationController;


    [Space(12), Header("Data")]
    [SerializeField] protected BarbarianSkillData _skillData;
    [SerializeField] protected ExplorerBaseInfo _playerBaseInfo;

    public override string Name => _skillData.Name;

    public override bool IsDonePerform => !skillPerforming;

    public override Sprite Icon => _skillData.Icon;

    public override string Description => _skillData.Description;

    public override float CooldownTime => _skillData.CooldownTime;

    public override float MaintanceTime => _skillData.MaintanceTime;

    public override float CastingTime => _skillData.CastingTime;

    public override bool CanBeInterrupted => _skillData.CanBeInterrupted;


    #region PRIVATE PROPERTIES
    private bool skillPerforming = false;

    private float countDownTimeRemainSkill = 0f;
    private float countDownTimeTriggerSkill = 0f;
    #endregion

    public override void Interrupt()
    {
        ConsoleLog.Log("Cannot interrupt skill: " + Name);
    }

    public override void Trigger()
    {
        if (countDownTimeTriggerSkill > 0)
        {
            ConsoleLog.Log($"Skill is in cooldown {countDownTimeTriggerSkill}");
            return;
        }

        // set data
        skillPerforming = true;
        countDownTimeRemainSkill = _skillData.MaintanceTime;
        countDownTimeTriggerSkill = _skillData.CooldownTime;

        // create skill prefab
        AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(_skillData.SkillPrefab, _skillSpawnPoint.position, Quaternion.identity);
        handle.Completed += (op) =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject skillObj = op.Result;
                skillObj.transform.position = _skillSpawnPoint.position;
                skillObj.transform.forward = _skillSpawnPoint.forward;
            }
        };
    }

    private void Update()
    {
        if (skillPerforming)
        {
            countDownTimeRemainSkill -= Time.deltaTime;
            if (countDownTimeRemainSkill <= 0)
            {
                skillPerforming = false;
                _animationController.PlayIdle();
            }
        }

        if (countDownTimeTriggerSkill > 0 && !skillPerforming)
        {
            countDownTimeTriggerSkill -= Time.deltaTime;
        }

        if(countDownTimeTriggerSkill > 0)
        {
            Messenger.Default.Publish<SkillPerformingMessage>(new SkillPerformingMessage() { TimeCountDown = countDownTimeTriggerSkill, PercentCountDown = (countDownTimeTriggerSkill / _skillData.CooldownTime) });
        }
    }
}
