using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    [SerializeField] private int _numFound;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Test2");
        if (other.gameObject.layer == _interactableMask) {
            Debug.Log("test");
            var interactableCollider = other.GetComponent<IInteractable>();
            if (interactableCollider != null)
            {
                other.transform.Find("Canvas").gameObject.SetActive(true);
                /*_interactable = interactableCollider;
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    interactableCollider.Interact(this);
                }*/
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        var interactableCollider = other.GetComponent<IInteractable>();
        if (interactableCollider != null)
        {
            other.transform.Find("Canvas").gameObject.SetActive(false);
        }
    }
}
