using UnityEngine;

public class DamageCast : MonoBehaviour
{
    [SerializeField] private ContactFilter2D _contactFilter;
    [SerializeField] private int _maxAvailableCount = 4;
    [SerializeField] private Vector3 _castSize;
    [SerializeField] private float _damage = 5f;
    [SerializeField] private Vector3 _knockBackForce = new Vector2(5f, 3f);
    private Collider2D[] _colliders;

    protected Entity _owner;
    public void InitCaster(Entity owner)
    {
        _owner = owner;
        _colliders = new Collider2D[_maxAvailableCount];
    }

    public void CastDamage()
    {
        Vector3 start = (Vector3)transform.position - _castSize * 0.5f;
        Vector3 end = start + _castSize;
        int cnt = Physics2D.OverlapArea(start, end, _contactFilter, _colliders);

        Vector3 atkDirection = _owner.transform.right;
        Vector3 knockBackForce = _knockBackForce;
        knockBackForce.x *= atkDirection.x;
        for (int i = 0; i < cnt; i++)
        {
            if (_colliders[i].TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_damage, atkDirection, knockBackForce, _owner);
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _castSize);
    }
#endif
}
