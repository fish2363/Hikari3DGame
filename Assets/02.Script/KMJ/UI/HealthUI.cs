using DG.Tweening.Core.Easing;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Player _player;

    [SerializeField] private Image hpBarObj;
    [SerializeField] private Image hpBgBarObj;
    private float _lastHitTime;
    private bool _isChaseFill;
    [SerializeField] private float delayTime = 1;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _player.currentHp.OnValueChanged += SetupHP;
    }

    public void SetupHP(float prevHealth, float nextHealth)
    {
        hpBarObj.fillAmount = (float)_player.currentHp.Value / _player.MaxHp;

        _lastHitTime = Time.time;
        transform.DOShakePosition(0.4f, 1f, 100);
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
