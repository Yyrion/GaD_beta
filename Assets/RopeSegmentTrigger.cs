using UnityEngine;
using UnityEngine.InputSystem;

public class RopeSegmentTrigger : MonoBehaviour, IInteractable
{
    private Rope _rope;
    private bool _canInteract;
    PlayerController _controller;
    private void Start()
    {
        _rope = transform.parent.GetComponent<Rope>();
        _controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (_canInteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Interact();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _canInteract = false;
        }
    }

    public void Interact()
    {
        _controller.StartClimbing(transform, _rope.StartRope, _rope.EndRope);
    }
}
