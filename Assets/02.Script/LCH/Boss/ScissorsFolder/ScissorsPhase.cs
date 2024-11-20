using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsPhase : MonoBehaviour
{

    private Rigidbody _rbCopmo;

    [SerializeField] private float _dashPower = 8f;
    [SerializeField] private float _jumpPower = 30;

    private BossBase _scissors;

    private Player _targetPlayer;

    private void Awake()
    {
        _scissors = GetComponent<BossBase>();
        _rbCopmo = GetComponent<Rigidbody>();
        _targetPlayer = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void BossPhases()
    {
        int PhaseCount = Random.Range(1, 4);

        //switch (PhaseCount)
        //{
        //    case 1:
                //ScissorsPhase1();
        //        break;
               //case 2:
                    ScissorsPhase2();
                  //break;
        //}
    }

    private void ScissorsPhase2()
    {
        _scissors.phase2 = true;
        _rbCopmo.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        if(_rbCopmo.velocity.y < 0)
        {
            Vector3 dir = (_targetPlayer.transform.position - transform.position).normalized;
            _rbCopmo.velocity = dir;
        }
    }

    private void ScissorsPhase1()
    {
        Vector3 direction = (_targetPlayer.transform.position - transform.position).normalized;
        _rbCopmo.AddForce(direction * _dashPower, ForceMode.Impulse);
    }
}
