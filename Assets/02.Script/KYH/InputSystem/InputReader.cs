using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, KeyAction.IPlayerActions
{
    public event Action OnAttackEvent;
    public event Action OnDashEvent;
    public event Action OnJumpEvent;
    public event Action OnWeaponSwapEvent;
    public event Action<Vector2> OnMoveEvent;

    public Vector3 direction { get; private set; }
    public Vector2 moveDir { get; private set; }

    private KeyAction playerKeyAction;

    [SerializeField]
    private InputReader inputReader;

    private void OnEnable()
    {
        if (playerKeyAction == null)
        {
            playerKeyAction = new KeyAction();
            playerKeyAction.Player.SetCallbacks(this);  //�÷��̾� ��ǲ�� �߻��ϸ� �� �ν��Ͻ��� ����
        }
        playerKeyAction.Player.Enable(); //Ȱ��ȭ
    }

    public void OnDisable()
    {
        if (playerKeyAction != null)
            playerKeyAction.Player.Disable(); // ��Ȱ��ȭ
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnJumpEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
        direction = new Vector3(moveDir.x, 0f, moveDir.y);
        OnMoveEvent?.Invoke(moveDir);
    }

    // ����
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnAttackEvent?.Invoke();
    }

    // ���� ��ü
    public void OnWeaponSwap(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnWeaponSwapEvent?.Invoke();
    }

    // ���
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnDashEvent?.Invoke();
    }
}
