using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilderBullet : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody rbcombo;
    private Vector3 _moveDir;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        rbcombo = GetComponent<Rigidbody>();
        _moveDir = _player.transform.position - transform.position;

        _moveDir.Normalize();
    }
    private void Start()
    {

    }

    private void Update()
    {
        transform.position += _moveDir * 9 * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("´ê¾Ò¾î");
            gameObject.SetActive(false);
        }
    }
}
