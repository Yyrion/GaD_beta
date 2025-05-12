using UnityEngine;
using UnityEngine.InputSystem;

public class CrystalShardInteraction : MonoBehaviour, IInteractable
{
    private GameObject _actionCanvas;
    private bool _canInteract = false;

    private void Awake()
    {
        _actionCanvas = transform.Find("Canvas").gameObject;
    }

    private void Update()
    {
        if (_canInteract)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Interact();
                Destroy(gameObject);
            }
        }
    }

    public void Interact()
    {
        Debug.Log("CrystalShard");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_actionCanvas != null && (other.tag == "Player"))
        {
            _actionCanvas.SetActive(true);
            _canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_actionCanvas != null && (other.tag == "Player"))
        {
            _actionCanvas.SetActive(false);
            _canInteract = false;
        }
    }
}
