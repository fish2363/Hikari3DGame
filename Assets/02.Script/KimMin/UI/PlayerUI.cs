using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private WeaponManager _weaponManager;
    [SerializeField] private Player _player;

    private CoolTimeSlider _attackCoolTime;
    private CoolTimeSlider _defenseCoolTime;
    private Image _weaponImage;

    private WeaponData _weaponData;

    private void Awake()
    {
        _attackCoolTime = transform.Find("background/WeaponInfo/SkillCoolTime").GetComponent<CoolTimeSlider>();
        _defenseCoolTime = transform.Find("background/WeaponInfo/DefenseCoolTime").GetComponent<CoolTimeSlider>();

        _weaponImage = transform.Find("background/WeaponInfo/WeaponVisual/OutLine/background/WeaponImage").GetComponent<Image>();

        _weaponManager.OnWeaponChanged += HandleWeaponChanged;
        _player.OnAttackEvent += HandleWeaponAttack;
    }

    private void Start()
    {
        _weaponImage.sprite = _player.currentWeaponData.weaponSprite;
    }

    private void HandleWeaponChanged()
    {
        _weaponImage.sprite = _player.currentWeaponData.weaponSprite;
    }

    private void HandleWeaponAttack()
    {
        _attackCoolTime.CallbackSlider(_player.currentWeaponData.weaponAttackCoolTime);
    }
}
