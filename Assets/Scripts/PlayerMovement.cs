using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private static readonly int Running = Animator.StringToHash("running");
    private SpriteRenderer _sprite;
    private float _dirX = 0f;
    private readonly float _moveSpeed = 7f;
    private readonly float _jumpForce = 14f;
    private static readonly int State = Animator.StringToHash("state");
    private BoxCollider2D _playerCollider;
    [SerializeField] private LayerMask _jumpableGround;
    private enum MovementState
    {
        Idle,
        Running,
        Jumping,
        Falling
    }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<BoxCollider2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        this.UpdateMovementState();
    }

    private void UpdateMovementState()
    {
        MovementState state;

        this.Jump();
        _dirX = Input.GetAxisRaw("Horizontal");
        this.Walk();

        switch (_dirX)
        {
            case > 0f:
                state = MovementState.Running;
                this.MovingRight();
                break;
            case < 0f:
                state = MovementState.Running;
                this.MovingLeft();
                break;
            default:
                state = MovementState.Idle;
                break;
        }

        state = _rb.velocity.y switch
        {
            > .1f => MovementState.Jumping,
            < -.1f => MovementState.Falling,
            _ => state
        };

        _animator.SetInteger(State, (int)state);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            _rb.velocity = new Vector3(_rb.velocity.x, _jumpForce);
        }
    }

    private void Walk()
    {
        _rb.velocity = new Vector2(_dirX * _moveSpeed, _rb.velocity.y);
    }

    private void MovingRight()
    {
        _sprite.flipX = false;
    }

    private void MovingLeft()
    {
        _sprite.flipX = true;
    }

    private bool IsGrounded()
    {
        var bounds = _playerCollider.bounds;
        return Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down, .1f, _jumpableGround);
    }
}