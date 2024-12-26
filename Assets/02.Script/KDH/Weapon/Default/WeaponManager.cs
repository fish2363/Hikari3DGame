using System;
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

    public event Action OnWeaponChanged;
    public event Action OnAttack;

    [SerializeField] private Player player;
    [SerializeField]
    private bool isChange;
    public List<GameObject> weaponCount = new List<GameObject>();
    public List<GameObject> LeftWeaponManager = new List<GameObject>();
    [SerializeField] private GameObject currentWeaapon;

    [SerializeField]
    private bool _isChangeSecontWaepon;
    [SerializeField]
    private bool _isChangeThirdWaepon;


    private void Awake()
    {
        isChange = false;
        print(weaponCount[0].GetComponent<ThisWeaponData>().weaponData.weaponName);
        player.currentWeaponData = weaponCount[0].GetComponent<ThisWeaponData>().weaponData;
        player.animator.runtimeAnimatorController = weaponCount[0].GetComponent<ThisWeaponData>().weaponData.animatorControlloer;
        currentWeaapon = weaponCount[0];
    }

    private void Update()
    {
        ChangeWeapon();

        if (player.currentWeaponData.weaponName == "Clip")
        {
            LeftWeaponManager.ForEach(F => F.SetActive(false));
            LeftWeaponManager[0].SetActive(true);
        }
        else if (player.currentWeaponData.weaponName == "Pencil")
        {
            LeftWeaponManager.ForEach(F => F.SetActive(false));
            LeftWeaponManager[1].SetActive(true);
        }
        else
            LeftWeaponManager.ForEach(F => F.SetActive(false));
    }

    public void GetWeapon(WeaponData weaponData)
    {
        weaponCount.Add(GameObject.Find($"Weapon_{weaponData.weaponName}").transform.GetChild(0).gameObject);
        if (_isChangeSecontWaepon == false)
        {
            weaponCount.Add(GameObject.Find($"Weapon_{weaponData.weaponName}").transform.GetChild(0).gameObject);
            _isChangeSecontWaepon = true;
        }
        else if (_isChangeSecontWaepon)
        {
            weaponCount.Add(GameObject.Find($"Weapon_{weaponData.weaponName}").transform.GetChild(0).gameObject);
            _isChangeThirdWaepon = true;
        }
    }

    private void ChangeWeapon()
    {
        if (!isChange)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeItem(0, 0);
                StartCoroutine(ChangeWait());
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && _isChangeSecontWaepon)
            {
                ChangeItem(0, 1);
                StartCoroutine(ChangeWait());

            }

            else if (Input.GetKeyDown(KeyCode.Alpha3) && _isChangeThirdWaepon)
            {
                ChangeItem(0, 2);
                StartCoroutine(ChangeWait());

            }
        }
    }
    private void ChangeItem(int childNum, int ItemNum)
    {
        currentWeaapon.gameObject.SetActive(false);
        weaponCount[ItemNum].gameObject.SetActive(true);
        currentWeaapon = weaponCount[ItemNum];
        player.currentWeaponData = weaponCount[ItemNum].GetComponent<ThisWeaponData>().weaponData;
        player.animator.runtimeAnimatorController = weaponCount[ItemNum].GetComponent<ThisWeaponData>().weaponData.animatorControlloer;

        OnWeaponChanged?.Invoke();
    }

    private IEnumerator ChangeWait()
    {
        isChange = true;
        yield return new WaitForSeconds(3f);
        isChange = false;
    }
}
