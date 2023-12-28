using UnityEngine;

[CreateAssetMenu(fileName = "new Consumable Class", menuName = "Item/Consumable")]
public class ConsumableClass : ItemClass
{
    // Data specific to Consumable class

    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override MiscClass GetMisc() { return null; }
    public override ConsumableClass GetConsumable() { return this; }
}
