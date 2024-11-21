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

    [SerializeField] private ScissorsClone _scissorsClone;

    private void Awake()
    {
        _scissors = GetComponent<BossBase>();
        _targetPlayer = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void BossPhases()
    {
        int PhaseCount = Random.Range(1, 4);

        //switch (PhaseCount)
        //{
        //    case 1:
        //        ScissorsPhase1();
        //        break;
        //    case 2:
        //        ScissorsPhase2();
        //        break;
        //    case 3:
        //        ScissorsPhase3();
        //        break;
        //    case 4:
                ScissorsPhase4();
        //        break;
        //}
    }

    private void ScissorsPhase2()
    {
        _scissors.RbCompo.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
        if (_scissors.RbCompo.velocity.y < 0)
        {
            Vector3 dir = (_targetPlayer.transform.position - transform.position).normalized;
            _scissors.RbCompo.velocity = dir;
        }
    }

    private void ScissorsPhase1()
    {
        Vector3 direction = (_targetPlayer.transform.position - transform.position).normalized;
        _scissors.RbCompo.AddForce(direction * _dashPower, ForceMode.Impulse);
    }

    private void ScissorsPhase3()
    {
        StartCoroutine(SissorsPhaseCoroutine());
    }

    private void ScissorsPhase4()
    {
         Instantiate(_scissorsClone, -transform.position,Quaternion.identity);  
    }

    private IEnumerator SissorsPhaseCoroutine()
    {
        float CurrentTime = 0;
        while (CurrentTime <= 7)
        {
            CurrentTime += Time.deltaTime;
            Vector3 direction = _targetPlayer.transform.position - transform.position;
            _scissors.RbCompo.velocity = direction.normalized * _scissors.Enemystat.MoveSpeed;
            yield return null;
        }
        _scissors.RbCompo.velocity = Vector3.zero;
    }
}
