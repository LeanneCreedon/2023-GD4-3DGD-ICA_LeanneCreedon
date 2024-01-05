using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Series Followed:
/// Let's make an Inventory System! ErenCode -
/// https://www.youtube.com/playlist?list=PLn1X2QyVjFVBM7Gr_-pMhVt3-7rlY5hkx
/// accessed - 25/12/2023
/// ---------------------
/// Script for handling inventory item data
/// </summary>
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
