using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, KeyAction.IPlayerActions
{
    public event Action AttackEvent;
    public event Action OnDashEvent;
    public event Action OnJumpEvent;
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
            playerKeyAction.Player.SetCallbacks(this);  //플레이어 인풋이 발생하면 이 인스턴스를 연결
        }
        playerKeyAction.Player.Enable(); //활성화
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
}
