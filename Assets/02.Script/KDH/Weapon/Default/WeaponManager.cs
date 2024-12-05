using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private WeaponStorage _weaponStorage;

    public UnityEvent<GameObject> OnWeaponSwap;
    public UnityEvent OnMultipleWeapons;
    public UnityEvent OnWeaponPickUp;

    private GameObject _currentWeaponModel;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _weaponStorage = new WeaponStorage();
        ToggleWeaponVisibility(false);
    }

    public void ToggleWeaponVisibility(bool value)
    {
        if (_currentWeaponModel != null)
            _currentWeaponModel.SetActive(value);
    }

    private void SwapWeaponModel(GameObject weaponModel)
    {
        if (_currentWeaponModel != null)
            Destroy(_currentWeaponModel);

        _currentWeaponModel = Instantiate(weaponModel, transform);
        _currentWeaponModel.transform.localPosition = Vector3.zero;
        _currentWeaponModel.transform.localRotation = Quaternion.identity;

        OnWeaponSwap?.Invoke(weaponModel);
    }

    public WeaponData GetCurrentWeapon()
    {
        return _weaponStorage.GetCurrentWeapon();
    }

    public void PickUpWeapon(WeaponData weaponData)
    {
        AddWeaponData(weaponData);
        OnWeaponPickUp?.Invoke();
    }

    private void AddWeaponData(WeaponData weaponData)
    {
        if (!_weaponStorage.AddWeaponData(weaponData))
            return;

        if (_weaponStorage.WeaponCount == 2)
        {
            OnMultipleWeapons?.Invoke();
        }
        SwapWeaponModel(weaponData.weaponModel);
    }

    public void SwapWeapon()
    {
        if (_weaponStorage.WeaponCount <= 0)
        {
            return;
        }
        SwapWeaponModel(_weaponStorage.SwapWeapon().weaponModel);
    }
}
