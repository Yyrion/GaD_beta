using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System.Drawing;

[System.Serializable]
public class InventoryManager
{
    [SerializeField] private List<InventorySlot> _inventorySlots;

    public List<InventorySlot> InventorySlots => _inventorySlots;

    public UnityAction<InventorySlot> OnInventorySlotChange;
    public InventoryManager(int size)
    {
        _inventorySlots = new List<InventorySlot>(size);
        for (int i = 0; i < size; i++)
        {
            _inventorySlots.Add(new InventorySlot());
        }
    }

    public InventoryManager(InventoryDatabase data, List<InventoryItemData> items)
    {
        _inventorySlots = new List<InventorySlot>(items.Count);
        for (int i = 0;i < items.Count;i++)
        {
            int numberOfItem;
            switch (items[i].Id)
            {
                case 0 : numberOfItem = data.NumberOf_Rope; break;
                case 1 : numberOfItem = data.NumberOf_CrystalShard; break;
                case 2 : numberOfItem = data.NumberOf_GrapplinHook; break;
                default : numberOfItem = 0; break;
            }
            _inventorySlots.Add(new InventorySlot(items[i], numberOfItem));
        }
    }
}
