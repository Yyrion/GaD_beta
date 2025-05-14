using UnityEngine;

public class InventoryHolder : MonoBehaviour
{
    public Inventory inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < inventory.InventorySlots.Count; i++)
        {
            Debug.Log("Test");
        }
    }
}
