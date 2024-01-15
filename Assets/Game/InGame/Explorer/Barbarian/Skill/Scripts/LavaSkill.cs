using UnityEngine;

public class LavaSkill : MonoBehaviour
{
    [SerializeField] private BarbarianSkillData _skillData;

    private float countDownTimeRemainSkill;

    private void Awake()
    {
        countDownTimeRemainSkill = _skillData.MaintanceTime;
        this.transform.localScale = new Vector3(_skillData.Range, 0.1f, _skillData.Range);
    }

    private void Update()
    {
        if (countDownTimeRemainSkill > 0)
        {
            countDownTimeRemainSkill -= Time.deltaTime;
            if (countDownTimeRemainSkill <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        // check enemy in range
        Collider[] colliders = Physics.OverlapSphere(transform.position, _skillData.Range);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                // deal damage
                collider.GetComponent<EnemyHealthBase>().TakeDamage(_skillData.DamagePerSecond * Time.fixedDeltaTime);
            }
        }
    }
}
