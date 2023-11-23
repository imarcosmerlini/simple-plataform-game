using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(dirX * 7f, _rb.velocity.y);
        
        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector3(_rb.velocity.x, 14f);
        }
    }
}