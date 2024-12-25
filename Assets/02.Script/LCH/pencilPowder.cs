using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pencilPowder : MonoBehaviour
{

    [SerializeField] private float _dmage;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            if(collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_dmage);
                Destroy(gameObject);
            }
        }

        Destroy(gameObject);
    }
}
