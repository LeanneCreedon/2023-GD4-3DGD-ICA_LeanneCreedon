using UnityEngine;

public abstract class ItemClass : ScriptableObject
{
    [Header("Item")] // Data shared across every item
    public string itemName;
    public Sprite itemIcon;

    public abstract ItemClass GetItem();
    public abstract ToolClass GetTool();
    public abstract MiscClass GetMisc();
    public abstract ConsumableClass GetConsumable();
}