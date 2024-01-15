using UnityEngine;

public class FlameSkill : MonoBehaviour
{
    [SerializeField] private MysticaSkillData _skillData;

    private float countDownTimeRemainSkill;

    private void Awake()
    {
        countDownTimeRemainSkill = _skillData.MaintanceTime;
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
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(_skillData.RangeWidth, _skillData.RangeHeight), 0f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                // deal damage
                collider.GetComponent<EnemyHealthBase>().TakeDamage(_skillData.DamagePerSecond * Time.fixedDeltaTime);
            }
        }
    }
}
