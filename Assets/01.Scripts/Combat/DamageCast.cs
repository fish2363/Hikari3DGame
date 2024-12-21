using UnityEngine;

public class DamageCast : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private int _maxAvailableCount = 4;
    [SerializeField] private Vector3 _castSize;
    [SerializeField] private float _damage = 5f;
    [SerializeField] private Vector3 _knockBackForce = new Vector2(5f, 3f);
    public Collider[] cnt;

    protected Entity _owner;
    public void CastDamage()
    {
       cnt  = Physics.OverlapBox(transform.position, _castSize, Quaternion.identity, _whatIsPlayer);

        for (int i = 0; i < cnt.Length; i++)
        {
            if (cnt[i].TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_damage);
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
