using UnityEngine;
using UnityEngine.InputSystem;

public class Rope : MonoBehaviour, IInteractable
{

    private LineRenderer _lineRenderer;
    public Transform StartRope;
    public Transform EndRope;
    private bool _canInteract = false;

    void Start()
    {
        StartRope = transform.parent.transform.Find("Start").transform;
        EndRope = transform.parent.transform.Find("End").transform ;
        _lineRenderer = transform.parent.GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }


    void Update()
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
        _lineRenderer.enabled = true;
        StartRope.gameObject.SetActive(true);
        EndRope.gameObject.SetActive(true);

        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, StartRope.position);
        _lineRenderer.SetPosition(2, EndRope.position);
        _lineRenderer.alignment = LineAlignment.View;
    }
}
