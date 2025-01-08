using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create new Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public GameObject gameObj;
    public int value;
    public Sprite sprite;
}
