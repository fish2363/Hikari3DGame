using System;
using UnityEngine;

public class EntityMover : MonoBehaviour, IEntityComponent
{
    [field:SerializeField] public float _moveSpeed = 5f;
    
    [SerializeField] private Transform _groundTrm;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Vector3 _groundCheckSize;

    [SerializeField] private AnimParamSO _ySpeedParam;

    public bool CanManualMove { get; set; } = true;
    public Vector3 Velocity => _rbCompo.velocity;
    public bool IsGrounded { get; private set; }
    public event Action<bool> OnGroundStatusChange;
    public event Action<Vector3> OnMoveVelocity;

    private Entity _entity;
    private Rigidbody2D _rbCompo;
    private Vector3 _movementX;
    private bool _isEnemy = true;
    
    private float _moveSpeedMultiplier, _originalGravityScale;
    
    public void Initialize(Entity entity)
    {
        _entity = entity;
        _rbCompo = entity.GetComponent<Rigidbody2D>();
        
        _originalGravityScale = _rbCompo.gravityScale;
        _moveSpeedMultiplier = 1f;
    }
    
    public void SetMoveSpeedMultiplier(float value) => _moveSpeedMultiplier = value;
    public void SetGravityScale(float value) => _rbCompo.gravityScale = _originalGravityScale * value;

    public void AddForceToEntity(Vector2 force)
    {
        _rbCompo.AddForce(force, ForceMode2D.Impulse);
    }

    public void StopImmediately(bool isYAxisToo = false)
    {
        if (isYAxisToo)
            _rbCompo.velocity = Vector3.zero;
    }

    public void SetMovement(Vector3 value)
    {
        _movementX = value;
    }

    public void IsPlayer()
    {
        _isEnemy = false;
    }
    
    private void FixedUpdate()
    {
        CheckGround();
        MoveCharacter();

    }
    
    private void CheckGround()
    {
        bool before = IsGrounded;
        IsGrounded = Physics2D.OverlapBox(_groundTrm.position, _groundCheckSize, 0, _groundMask);
        if (before != IsGrounded)
            OnGroundStatusChange?.Invoke(IsGrounded);
    }

    private void MoveCharacter()
    {
        if (CanManualMove)
        {
            _rbCompo.velocity = _movementX * _moveSpeed * _moveSpeedMultiplier;
        }
        OnMoveVelocity?.Invoke(_rbCompo.velocity);
    }
    
    private void OnDrawGizmos()
    {
        if (_groundTrm == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundTrm.position, _groundCheckSize);
    }
}
