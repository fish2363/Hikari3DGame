using DG.Tweening.Core.Easing;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Player _player;

    private Image hpBarObj;
    private Image hpBgBarObj;
    private float _lastHitTime;
    private bool _isChaseFill;
    private float delayTime = 1;

    private EntityHealth _entityHealth;

    private void Awake()
    {
        hpBarObj = transform.Find("HpBar").GetComponent<Image>();
        hpBgBarObj = transform.Find("HpBarBack").GetComponent<Image>();

        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _entityHealth = _player.GetComponent<EntityHealth>();
        //_player.currentHp.OnValueChanged += SetupHP;
    }

    public void SetupHP()
    {
        hpBarObj.rectTransform.localScale = new Vector3(_entityHealth._currentHealth / _entityHealth.MaxHealth, 1, 1);
    }

    private void Update()
    {
        SetupHP();
    }
}
