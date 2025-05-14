using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Slot")]
public class InventorySlot : ScriptableObject
{
    public TextMeshPro AmountText;
    public InventoryItemData ItemData;
    public int Amount;

    void Actualize()
    {
        AmountText.text = $"{Amount}";
    }
}
