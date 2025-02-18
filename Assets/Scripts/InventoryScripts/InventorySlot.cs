using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    [SerializeField] private InventoryItemData _item;
    [SerializeField] private int _stackSize;

    public InventoryItemData Item => _item;
    public int StackSize => _stackSize;

    public InventorySlot(InventoryItemData item, int stackSize = 0)
    {
        _item = item;
        _stackSize = stackSize;
    }

    public InventorySlot()
    {
        _item = null;
        _stackSize = 0;
    }

    public void Add(int amount)
    {
        _stackSize += amount;
    }

    public void Remove(int amount)
    {
        _stackSize -= amount;
        if (_stackSize < 0)
        {
            _stackSize = 0;
        }
    }
}
