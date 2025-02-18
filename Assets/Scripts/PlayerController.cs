using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.Splines.Interpolators;

public class PlayerController : MonoBehaviour
{
    const float GRAVITY = 9.81f;
    const float JUMPFORCE = 1f;
    private float maxMovementSpeed = 3f;

    private bool isJumping = false;
    private bool isGrounded = false;
    
    private InputAction moveAction;

    private CharacterController characterController;

    private Vector2 moveValue;

    private Vector3 movement = Vector3.zero;

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.gravity = new Vector3(0, -9.81f, 0);
        moveAction = InputSystem.actions.FindAction("Move");
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        if (!isGrounded)
        {
            movement.y = -GRAVITY;
        }
        

        
        //_xmovement = Vector3.Slerp(_xmovement, new Vector3(maxMovementSpeed * moveValue.x, 0, 0), 0.5f);
        movement.x = Mathf.Lerp(movement.x, maxMovementSpeed * moveValue.x, 0.5f);
        characterController.Move(movement * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            isGrounded = true;

        } else
        {
            isGrounded = false;
        }
    }
}
