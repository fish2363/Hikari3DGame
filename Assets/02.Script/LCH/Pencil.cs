using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : MonoBehaviour
{
	private Transform _player;
    private Rigidbody _rbCompo;
    [SerializeField] private float _shotSpeed = 1f;

    [SerializeField] private float _damge;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
        _rbCompo = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Vector3 target =  _player.position - transform.position;
        _rbCompo.velocity = target * _shotSpeed;
        transform.LookAt(_player);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            if(collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_damge);
                Destroy(gameObject);
            }
        }
        Destroy(gameObject);
    }
}
