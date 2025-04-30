using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float JUMPFORCE = 1f;
    const float GRAVITY = -9.81f;

    private float maxMovementSpeed = 3f;

    private CharacterController _characterController;

    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector2 moveValue;
    private bool isJumping = false;
    private bool isClimbing = false;
    private float climbSpeed = 2f;
    private Vector3 climbDirection = Vector3.up;

    private Vector3 velocity;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        isJumping = jumpAction.ReadValue<float>() > 0.2f;

        Vector3 horizontalMovement = new Vector3(moveValue.x, 0, 0) * maxMovementSpeed;


        if (_characterController.isGrounded)
        {
            if (isJumping)
            {   
                velocity.y = Mathf.Sqrt(JUMPFORCE * -2f * GRAVITY);
            }
            else if (velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }
        else
        {
            horizontalMovement *= 1.2f;
        }

        velocity.y += GRAVITY * Time.deltaTime;

        if (isClimbing)
        {
            velocity.y = 0;

            velocity = climbDirection * moveValue.y * climbSpeed;

            _characterController.Move(velocity * Time.deltaTime);

            return;
        }

        Vector3 finalMovement = horizontalMovement + new Vector3(0, velocity.y, 0);
        _characterController.Move(finalMovement * Time.deltaTime);
    }

    public void StartClimbing(Transform enter, Transform top, Transform bottom)
    {
        isClimbing = true;
    }

    public void EndClimbing()
    {
        if (isClimbing)
        {
            isClimbing = false;
        }
    }
}
