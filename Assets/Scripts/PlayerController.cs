using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.Splines.Interpolators;

public class PlayerController : MonoBehaviour
{
    const float JUMPFORCE = 500f;

    private LayerMask _groundLayer;
    private float maxMovementSpeed = 3f;

    private bool isGrounded = false;

    Rigidbody rb;

    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector2 moveValue;
    private float jumpValue;
    

    private Vector3 movement = Vector3.zero;

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody>();
        _groundLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        jumpValue = jumpAction.ReadValue<float>();

        if (jumpValue > 0.10f)
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * JUMPFORCE * jumpValue);
            }
            
        }

        if (moveValue.x < 0f)
        {
            //RotateLeft
        } else if (moveValue.x > 0f)
        {
            //RotateRight
        }
        movement.z = Mathf.Lerp(movement.z, maxMovementSpeed * moveValue.x, 0.5f);
        if (!isGrounded)
        {
            movement.z *= 1.05f;
        }
        transform.Translate(movement * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f, _groundLayer))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
    }
}
