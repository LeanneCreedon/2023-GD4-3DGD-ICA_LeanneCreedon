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
/// Script for handling NPC data
/// </summary>
public abstract class SO_NPC : ScriptableObject
{
    [Header("NPC")] // Data shared across every item
    public string NPCName;
    public Sprite NPCIcon;

    [InlineButton("DoPress", "Press Me")]
    public AudioClip PickupClip;

    public abstract SO_NPC GetNPC();

    public abstract NPCData GetNPCData();
}
