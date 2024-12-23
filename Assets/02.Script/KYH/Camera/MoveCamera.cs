using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MoveCamera : MonoBehaviour
{

    public Transform combatLookAt;
    public Transform orientation;
    [SerializeField]
    private Player player;

    //private void Start()
    //{
    //    difValue = transform.position - followTarget.transform.position;
    //    difValue = new Vector3(Mathf.Abs(difValue.x), Mathf.Abs(difValue.y) - 3, Mathf.Abs(difValue.z));
    //}


    private void Update()
    {
        if(player.isCameraOn)
        {
            Vector3 viewDir = player.gameObject.transform.position - new Vector3(transform.position.x, player.gameObject.transform.position.y, transform.position.z);
            orientation.forward = viewDir.normalized;


            Vector3 dirToCombatLookAt = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = dirToCombatLookAt.normalized;

            player.gameObject.transform.forward = dirToCombatLookAt.normalized;
        }
    }
}
