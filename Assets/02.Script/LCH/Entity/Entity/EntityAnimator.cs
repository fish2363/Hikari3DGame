using System;
using UnityEngine;

public class EntityAnimator : MonoBehaviour, IEntityComponent
{
    public event Action OnAnimationEnd;
    public event Action OnAttackEvent;
    public event Action OnPhase2Attack;
    public event Action OnPhase3Attack;
    public event Action OnNailShot;
    protected Entity _entity;
    
    protected virtual void AnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }

    public void Initialize(Entity entity)
    {
        _entity = entity;    
    }
}
