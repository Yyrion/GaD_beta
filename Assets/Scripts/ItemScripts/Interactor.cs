using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    [SerializeField] private int _numFound;

    private void Start()
    {
        _interactableMask = LayerMask.NameToLayer("Interactable");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _interactableMask.value) {
            var interactableCollider = other.GetComponent<IInteractable>();
            
            if (interactableCollider != null)
            {
                Debug.Log("Enter");
                other.transform.Find("Canvas").gameObject.SetActive(true);
                /*_interactable = interactableCollider;*/
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    Debug.Log("LALALAAAA");
                    interactableCollider.Interact(this);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _interactableMask.value)
        {
            Debug.Log("Out");
            var interactableCollider = other.GetComponent<IInteractable>();
            if (interactableCollider != null)
            {
                other.transform.Find("Canvas").gameObject.SetActive(false);
            }
        }
    }
}
