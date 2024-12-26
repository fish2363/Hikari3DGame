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
        _player.currentHp.OnValueChanged += SetupHP;
    }

    public void SetupHP(float entityHealth, float nextHealth)
    {
        hpBarObj.fillAmount = _player.currentHp.Value / _player.MaxHp;

        _lastHitTime = Time.time;
    }

    private void Update()
    {
        if (!_isChaseFill && _lastHitTime + delayTime > Time.time)
        {
            _isChaseFill = true;
            hpBgBarObj.DOFillAmount(hpBarObj.fillAmount, 0.6f)
                .SetEase(Ease.InCubic)
                .OnComplete(() => _isChaseFill = false);
        }
    }
}
