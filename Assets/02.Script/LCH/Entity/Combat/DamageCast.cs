using System.Collections;
using UnityEngine;

public class DamageCast : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private int _maxAvailableCount = 4;
    [SerializeField] private Vector3 _castSize;
    [field:SerializeField] public float Damage;
    [SerializeField] private Vector3 _knockBackForce = new Vector2(5f, 3f);
    public Collider[] cnt;

    private bool _canDamage = true;

    public void CastDamage()
    {
        if (!_canDamage) return;

       cnt  = Physics.OverlapBox(transform.position, _castSize, Quaternion.identity, _whatIsPlayer);

        for (int i = 0; i < cnt.Length; i++)
        {
            if (cnt[i].TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(Damage);
                StartCoroutine(DamageRoutine());
            }
        }
    }

    private IEnumerator DamageRoutine()
    {
        yield return new WaitForSeconds(1f);
        _canDamage = true;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _castSize);
    }
#endif
}
