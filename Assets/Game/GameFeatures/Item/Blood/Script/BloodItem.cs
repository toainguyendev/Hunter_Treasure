using UnityEngine;
using static UnityEditor.Progress;

public class BloodItem : ItemBase
{
	public override void Upgrade()
    {

    }

    public override void Use()
    {
		// Khi mìn nổ, kích hoạt hiệu ứng hạt
		ParticleSystem explosionEffect = GetComponentInChildren<ParticleSystem>();
		if (explosionEffect != null)
		{
			explosionEffect.Play();
		}
	}
}
