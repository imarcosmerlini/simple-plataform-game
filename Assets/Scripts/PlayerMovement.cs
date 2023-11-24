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

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
        this.Jump();
        _dirX = Input.GetAxisRaw("Horizontal");
        this.Walk();
        
        switch (_dirX)
        {
            case > 0f:
                this.MovingRight();
                break;
            case < 0f:
                this.MovingLeft();
                break;
            default:
                this.Idle();
                break;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _jumpForce);
        }
    }

    private void Walk()
    {
        _rb.velocity = new Vector2(_dirX * _moveSpeed, _rb.velocity.y);
    }

    private void MovingRight()
    {
        _animator.SetBool(Running, true);
        _sprite.flipX = false;
    }

    private void MovingLeft()
    {
        _animator.SetBool(Running, true);
        _sprite.flipX = true;
    }

    private void Idle()
    {
        _animator.SetBool(Running, false);
    }
}