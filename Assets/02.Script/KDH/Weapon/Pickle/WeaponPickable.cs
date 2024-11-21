using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickable : Pickable
{
    [SerializeField] private WeaponData _weaponData;

    private void Start()
    {
        if (_weaponData.weaponModel != null)
        {
            Instantiate(_weaponData.weaponModel, transform.position, Quaternion.identity, transform);
        }
    }

    public override void PickUp(Player agent)
    {
        //agent.PickUp(_weaponData);
    }
}
