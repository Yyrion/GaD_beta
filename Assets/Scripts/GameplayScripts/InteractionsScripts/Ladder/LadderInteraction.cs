using UnityEngine;
using UnityEngine.InputSystem;

public class LadderInteraction : MonoBehaviour
{
    private bool _canInteract;
    private Transform _top;
    private Transform _bottom;
    PlayerController _controller;
    private void Start()
    {
        _controller = GameObject.Find("Player").GetComponent<PlayerController>();
        _top = transform.parent.Find("Top");
        _bottom = transform.parent.Find("Bottom");

    }

    private void Update()
    {
        if (_canInteract)
        {
            if (Keyboard.current.fKey.wasPressedThisFrame)
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
        if (!_controller.IsClimbing)
        {
            _controller.IsClimbing = true;
            _controller.StartClimbing(transform, _top, _bottom);
        }
        else
        {
            _controller.EndClimbing();
        }

    }
}
