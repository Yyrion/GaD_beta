using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float JUMPFORCE = 1f;
    const float GRAVITY = -9.81f;

    private float maxMovementSpeed = 3f;

    private CharacterController _characterController;

    //Input Action
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction openInvAction;

    //Movement
    private Vector2 moveValue;
    private bool isJumping = false;
    public bool IsClimbing = false;
    private float climbSpeed = 2f;
    private Vector3 climbDirection = Vector3.up;
    private Vector3 climbMaxHeight;
    private Vector3 climbMinHeight;

    private Vector3 velocity;

    //Fall and Gravity
    private float fallStartY;
    private bool isFalling = false;
    private bool isGroundedLastFrame;

    //Health
    private HealthManager _healthManager;

    //Inventory
    public GameObject inventoryPanel;
    private bool inventoryOpen = false;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        openInvAction = InputSystem.actions.FindAction("OpenInventory");
        _characterController = GetComponent<CharacterController>();
        _healthManager = GetComponent<HealthManager>();
    }

    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        isJumping = jumpAction.ReadValue<float>() > 0.2f;

        Vector3 horizontalMovement = new Vector3(moveValue.x, 0, 0) * maxMovementSpeed;

        // Chute détectée : on stocke le début
        if (!_characterController.isGrounded && !isFalling && !IsClimbing)
        {
            isFalling = true;
            fallStartY = transform.position.y;
        }

        if (openInvAction.triggered)
        {
            inventoryOpen = !inventoryOpen;
            inventoryPanel.SetActive(inventoryOpen);
        }

        if (_characterController.isGrounded)
        {
            if (isFalling)
            {
                float fallDistance = fallStartY - transform.position.y;
                ApplyFallDamage(fallDistance);
                isFalling = false;
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
        else if (!IsClimbing)
        {
            horizontalMovement *= 1.2f;
        }

        velocity.y += GRAVITY * Time.deltaTime;

        if (IsClimbing)
        {
            velocity.y = 0;
            velocity = climbDirection * moveValue.y * climbSpeed;
            _characterController.Move(velocity * Time.deltaTime);

            if (climbMaxHeight.y < transform.position.y)
                transform.position = new Vector3(transform.position.x, climbMaxHeight.y, transform.position.z);

            if (climbMinHeight.y > transform.position.y)
                transform.position = new Vector3(transform.position.x, climbMinHeight.y, transform.position.z);

            return;
        }

        Vector3 finalMovement = horizontalMovement + new Vector3(0, velocity.y, 0);
        _characterController.Move(finalMovement * Time.deltaTime);

        isGroundedLastFrame = _characterController.isGrounded;
    }

    public void StartClimbing(Transform enter, Transform top, Transform bottom)
    {
        _characterController.enabled = false;
        Physics.IgnoreLayerCollision(9, 7, true);
        transform.position = enter.position + Vector3.up * 0.5f;
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
            Physics.IgnoreLayerCollision(9, 7, false);
        }
    }

    private void ApplyFallDamage(float fallDistance)
    {

        float damageStartHeight = 3f; // hauteur minimale avant dégâts
        float maxHeight = 10f;        // hauteur à laquelle les dégâts sont maximaux
        float maxDamage = 100f;

        if (fallDistance > damageStartHeight)
        {
            float t = Mathf.InverseLerp(damageStartHeight, maxHeight, fallDistance);
            float damage = Mathf.Pow(t, 2.5f) * maxDamage;
            _healthManager.TakeDamage(Mathf.RoundToInt(damage));
        }
    }
}
