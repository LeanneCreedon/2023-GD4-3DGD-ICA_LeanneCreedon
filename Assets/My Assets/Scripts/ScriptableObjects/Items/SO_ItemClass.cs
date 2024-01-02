using Sirenix.OdinInspector;
using UnityEngine;

public abstract class SO_ItemClass : ScriptableObject
{
    [Header("Item")] // Data shared across every item
    public string itemName;
    public Sprite itemIcon;
    public bool isStackable = true;
    public bool isCraftable = false;

    [InlineButton("DoPress", "Press Me")]
    public AudioClip PickupClip;

    public abstract SO_ItemClass GetItem();
    public abstract MiscClass GetMisc();
    public abstract QuestCollectable GetQuestCollectable();
}
