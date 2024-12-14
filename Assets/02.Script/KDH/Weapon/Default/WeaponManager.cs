using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{



    /*private MeshRenderer _meshRenderer;
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
        //SwapWeaponModel(weaponData.weaponModel);
    }

    public void SwapWeapon()
    {
        if (_weaponStorage.WeaponCount <= 0)
        {
            return;
        }
       // SwapWeaponModel(_weaponStorage.SwapWeapon().weaponModel);
    }*/

    [SerializeField] private Player player;
    public List<WeaponData> weaponList = new List<WeaponData>();
    public MeshFilter weaponMesh;
    public MeshRenderer weaponMaterial;
    private bool isChange;

    private void Awake()
    {
        isChange = true;
        player.currentWeaponData = weaponList[0];
    }

    private void Update()
    {
        ChangeWeapon();
        weaponMesh.mesh = player.currentWeaponData.weaponModel;
        weaponMaterial.material = player.currentWeaponData.weaponMaterial;
        player.animator.runtimeAnimatorController = player.currentWeaponData.animatorControlloer;
    }

    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isChange)
        {
            player.currentWeaponData = weaponList[0];
            StartCoroutine(ChangeWait());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && isChange)
        {
            {
                if (weaponList[1] == null)
                    return;
                player.currentWeaponData = weaponList[1];
                StartCoroutine(ChangeWait());
            }
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && isChange)
        {
            if (weaponList[2] == null)
                return;
            player.currentWeaponData = weaponList[2];
            StartCoroutine(ChangeWait());
        }
    }

    public void AddWeaponData(WeaponData weaponData)
    {
        if (weaponList[1] == null)
            weaponList[1] = weaponData;
        else
            weaponList.Add(weaponData);
    }

    private IEnumerator ChangeWait()
    {
        isChange = false;
        yield return new WaitForSeconds(5f);

        isChange = true;
    }


}
