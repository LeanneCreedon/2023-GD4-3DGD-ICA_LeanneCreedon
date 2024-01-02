using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataGameEvent", menuName = "Scriptable Objects/Patterns/Events/Crafting")]
public class CraftingDataGameEvent : BaseGameEvent<ItemEventData>
{
    public void Raise(SO_ItemClass item)
    {
        Raise(new ItemEventData { eventType = ItemEventData.EventType.Pickup, item = item });
    }
}

[System.Serializable]
public class ItemEventData
{
    public enum EventType
    {
        Pickup,
        Crafted
    }

    public EventType eventType;
    public SO_ItemClass item;
}