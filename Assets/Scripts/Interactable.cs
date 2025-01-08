using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Rigidbody playerRb;
    public Collider playerCol;
    public object onInteract;
    public bool canBeInteractable;

    private void Start()
    {
        canBeInteractable = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("IN");
            canBeInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("OUT");
            canBeInteractable = false;
        }
    }
}
