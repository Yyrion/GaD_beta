using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private bool grounded;

    private float maxMovementSpeed = 3f;
    private float jumpForce = 40f;
    
    private InputAction moveAction;

    private Rigidbody rb;

    private Vector2 moveValue;

    private Vector3 velocity = Vector3.zero;

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        if (moveValue.y > 0.5)
        {
            rb.AddForce(Vector3.up* jumpForce, ForceMode.Impulse);
        }
        velocity = Vector3.Slerp(velocity, new Vector3(maxMovementSpeed * moveValue.x, 0, 0), 0.5f);
        transform.position += velocity * Time.deltaTime;
    }
}
