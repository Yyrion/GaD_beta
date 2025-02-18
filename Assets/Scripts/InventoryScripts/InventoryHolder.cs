using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventoryHolder : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private InventoryDatabase _inventoryDatabase;
    [SerializeField] private List<InventoryItemData> _inventoryItems;

    public static UnityAction<InventoryManager> OnDynamicInventoryDisplayRequested;

    public InventoryManager InventoryManager => _inventoryManager;

    private void Awake()
    {
        _inventoryManager = new InventoryManager(_inventoryDatabase, _inventoryItems);
    }
}
