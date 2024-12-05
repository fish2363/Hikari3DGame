using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody RigidCompo { get; private set; }

    [SerializeField] private WeaponManager weaponManager;

    public float MaxHp { get { return maxHp; } }
    public float CurrentHp { get { return currentHp; } }
    public float MoveSpeed { get { return moveSpeed; } }

    [SerializeField]
    protected float maxHp;
    [SerializeField]
    protected float currentHp;
    [SerializeField]
    protected float moveSpeed;


    private Dictionary<StateEnum, State> stateDictionary = new Dictionary<StateEnum, State>();
    private StateEnum currentEnum;

    private void Awake()
    {
        if (weaponManager == null)
            weaponManager = GetComponentInChildren<WeaponManager>();

        foreach (StateEnum enumState in Enum.GetValues(typeof(StateEnum)))
        {
            Type t = Type.GetType($"{enumState}State");
            State state = Activator.CreateInstance(t, new object[] { this }) as State;
            stateDictionary.Add(enumState,state);
        }
        ChangeState(StateEnum.Idle);

        InputReader.OnDashEvent += HandleDashEvent;
        InputReader.OnJumpEvent += HandleJumpEvent;
        InputReader.OnAttackEvent += HandleAttackEvent;
        InputReader.OnWeaponSwapEvent += HandleWeaponSwap;
    }

    private void Update()
    {
        stateDictionary[currentEnum].StateUpdate();
    }

    private void FixedUpdate()
    {
        stateDictionary[currentEnum].FixedUpdate();
    }

    private void HandleJumpEvent()
    {

    }

    private void HandleDashEvent()
    {

    }

    private void HandleWeaponSwap()
    {
        if (weaponManager == null)
            return;

        weaponManager.SwapWeapon();
    }

    private void HandleAttackEvent()
    {
        if (weaponManager == null || weaponManager.GetCurrentWeapon() == null)
            return;

        WeaponData currentWeapon = weaponManager.GetCurrentWeapon();
        Vector3 attackDirection = transform.forward;
        LayerMask hittableLayer = LayerMask.GetMask("Enemy"); // 공격 대상 레이어 설정

        currentWeapon.PerformAttack(this, hittableLayer, attackDirection);
    }

    public void ChangeState(StateEnum newEnum)
    {
        stateDictionary[currentEnum].Exit();
        currentEnum = newEnum;
        stateDictionary[currentEnum].Enter();
    }

    public void PickUp(WeaponData weaponData)
    {
        if (weaponManager == null)
        {
            Debug.LogWarning("WeaponManager가 설정되지 않았습니다.");
            return;
        }

        weaponManager.PickUpWeapon(weaponData);
    }
}
