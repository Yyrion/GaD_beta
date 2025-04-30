using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;

    [SerializeField] private int _numFound;

    private void Start()
    {
        _interactableMask = LayerMask.NameToLayer("Interactable");
    }
}
