using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderObject : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;

    private Soilder _soilder;

    private GameObject _player;

    private void Awake()
    {
        _soilder = GetComponentInParent<Soilder>();
        _player = GameObject.FindWithTag("Player"); 
    }
    
    public void LookForward()
    {
        transform.rotation = Quaternion.LookRotation(_soilder.transform.forward);
    }

    public void LookPlayer()
    {
        Vector3 direction =  _player.transform.position - transform.position;

        direction.y = 0;


        if (direction.sqrMagnitude > 0.001f)
        {
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);

            transform.rotation = lookRotation;
        }

        _soilder.transform.rotation = Quaternion.Euler(new Vector3(_soilder.RigidCompo.velocity.x, 0
           , _soilder.RigidCompo.velocity.z));
    }

    public void Attack()
    {
        StartCoroutine(AttackCoolTime());
    }

    IEnumerator AttackCoolTime()
    {
        _soilder._isAttack = false;
        _soilder._isMove = false;

        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(_bulletPrefab, transform.position, Quaternion.identity);


        yield return new WaitForSeconds(0.5f);

        _soilder._isMove = true;

        yield return new WaitForSeconds(6f);

        _soilder._isAttack = true;

        
    }
}
