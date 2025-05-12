using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory item")]
public class InventoryItemData : ScriptableObject
{
    public int Id;
    public bool IsReusable;

    public string Name;
    [TextArea(4,4)]
    public string Description;

    public Sprite ItemSprite;
}
