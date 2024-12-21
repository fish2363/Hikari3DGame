using UnityEngine;

public interface IDamageable
{
    public void ApplyDamage(float damage, Vector3 direction, Vector3 knockBack, Entity dealer);
}