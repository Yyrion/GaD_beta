using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    LayerMask _interactableMask;
    [SerializeField] private int _numFound;

    private void Start()
    {
        _interactableMask = LayerMask.NameToLayer("Interactable");
    }
}
