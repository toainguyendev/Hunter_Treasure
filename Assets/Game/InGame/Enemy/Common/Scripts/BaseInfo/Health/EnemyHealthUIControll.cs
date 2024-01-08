using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUIControll : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Slider _healthBar;

    private float _maxHealth;
    private float _currentHealth;

    public void SetupHealth(float maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;

        UpdateUI(_currentHealth);
    }

    // create method to make health bar opposite to camera
    private void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void UpdateUI(float currentHealth)
    {
        _healthBar.maxValue = _maxHealth;
        _healthBar.DOValue(_currentHealth, 0.5f);
    }
}
