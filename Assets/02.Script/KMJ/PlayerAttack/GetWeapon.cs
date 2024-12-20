using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GetWeapon : MonoBehaviour
{
    [SerializeField] private WeaponData _thisWeapon;
    private TextMeshProUGUI Gettxt;

    private void Awake()
    {
        Gettxt = GameObject.Find("GetTxt").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {                 
            Gettxt.text = $"{gameObject.name} get!";
            Gettxt.DOFade(0, 3);
            other.GetComponentInChildren<WeaponManager>().GetWeapon(_thisWeapon);
            Destroy(gameObject);
        }
    }
}
