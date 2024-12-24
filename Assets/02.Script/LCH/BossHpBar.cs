using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpBar : MonoBehaviour
{
	private EntityHealth _entityHealth;

    [SerializeField] private Image _hpBar;

    private float _hpFillAmount;

    private void Awake()
    {
        _entityHealth = GetComponentInParent<EntityHealth>();
    }

    private void Update()
    {
        BossHpSetting(_entityHealth.Damge);
    }

    public void BossHpSetting(float damge)
    {
        _hpFillAmount = Mathf.Clamp(_entityHealth.MaxHealth - damge, 0, 1);
        _hpBar.fillAmount = _hpFillAmount;
    }
}
