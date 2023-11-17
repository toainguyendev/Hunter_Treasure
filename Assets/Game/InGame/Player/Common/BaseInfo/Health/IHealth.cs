

public interface IHealth
{
    // current hp
    public float CurrentHP { get; set; }

    // decrease hp
    public void TakeDamage(float damage);

    // increase hp 
    public void Heal(float healAmount);
}
