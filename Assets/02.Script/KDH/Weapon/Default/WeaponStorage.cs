using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStorage
{
    public List<WeaponData> weaponDataList = new List<WeaponData>();
    private int currentWeaponIndex = -1;

    public int WeaponCount => weaponDataList.Count;

    public WeaponData GetCurrentWeapon()
    {
        if (currentWeaponIndex == -1)
            return null;
        return weaponDataList[currentWeaponIndex];
    }

    public bool AddWeaponData(WeaponData weaponData)
    {
        if (weaponDataList.Contains(weaponData))
        {
            return false;
        }
        weaponDataList.Add(weaponData);
        currentWeaponIndex = weaponDataList.Count - 1;
        return true;
    }

    public WeaponData SwapWeapon()
    {
        if (currentWeaponIndex == -1)
            return null;

        currentWeaponIndex++;
        if (currentWeaponIndex >= weaponDataList.Count)
            currentWeaponIndex = 0;

        return weaponDataList[currentWeaponIndex];
    }
}
