using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float JUMPFORCE = 1f;
    const float GRAVITY = -9.81f;
    const float MAXFALLSPEED = -15f;

    private float maxMovementSpeed = 3f;

    private CharacterController _characterController;

    private InputAction moveAction;
    private InputAction jumpAction;

    private Vector2 moveValue;
    private bool isJumping = false;
    public bool IsClimbing = false;
    private float climbSpeed = 2f;
    private Vector3 climbDirection = Vector3.up;
    private Vector3 climbMaxHeight;
    private Vector3 climbMinHeight;

    private Vector3 velocity;
    private float _fallVelocity;
    private bool isGroundedLastFrame;

    private HealthManager _healthManager;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        _characterController = GetComponent<CharacterController>();
        _healthManager = GetComponent<HealthManager>();
    }

    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        isJumping = jumpAction.ReadValue<float>() > 0.2f;

        Vector3 horizontalMovement = new Vector3(moveValue.x, 0, 0) * maxMovementSpeed;


        if (_characterController.isGrounded)
        {
            if (!isGroundedLastFrame)
            {
                if (_fallVelocity < MAXFALLSPEED)
                {
                    float damage = Mathf.Abs(_fallVelocity + MAXFALLSPEED) * 3;
                    _healthManager.TakeDamage(Mathf.RoundToInt(damage));
                }
                _fallVelocity = 0f;
            }

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
            _fallVelocity += GRAVITY * Time.deltaTime;
        }

        isGroundedLastFrame = _characterController.isGrounded;


        velocity.y += GRAVITY * Time.deltaTime;

        if (IsClimbing)
        {
            velocity.y = 0;

            velocity = climbDirection * moveValue.y * climbSpeed;

            _characterController.Move(velocity * Time.deltaTime);
            if (climbMaxHeight.y < transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, climbMaxHeight.y, transform.position.z);
            } if (climbMinHeight.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, climbMinHeight.y, transform.position.z);
            }

            return;
        }

        Vector3 finalMovement = horizontalMovement + new Vector3(0, velocity.y, 0);
        _characterController.Move(finalMovement * Time.deltaTime);
        
}

    public void StartClimbing(Transform enter, Transform top, Transform bottom)
    {
        _characterController.enabled = false;
        transform.position = enter.position + Vector3.up*0.5f + Vector3.right*0.45f;
        _characterController.enabled = true;
        IsClimbing = true;
        climbMaxHeight = top.position + Vector3.up;
        climbMinHeight = bottom.position;
    }

    public void EndClimbing()
    {
        if (IsClimbing)
        {
            IsClimbing = false;
        }
    }
}
