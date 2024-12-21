using System;
using System.Collections;
using UnityEngine;

public class EntityHealth : MonoBehaviour, IEntityComponent, IDamageable
{
    [field:SerializeField] public float MaxHealth;
    public float _currentHealth;
    [SerializeField] private float _knockBackTime = 0.5f;
    private Entity _entity;
    private EntityMover _mover;

    public event Action OnHit;
    public event Action OnDeath;
    
    public void Initialize(Entity entity)
    {
        _entity = entity;
        _mover = _entity.GetCompo<EntityMover>();
        
    }

    private void Start()
    {
        _currentHealth = MaxHealth;
        
    }


    public void ApplyDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, MaxHealth);
        OnHit?.Invoke();

        if (_currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
