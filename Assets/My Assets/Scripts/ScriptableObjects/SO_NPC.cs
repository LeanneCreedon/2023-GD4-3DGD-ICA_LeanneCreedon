using Sirenix.OdinInspector;
using UnityEngine;

public abstract class SO_NPC : ScriptableObject
{
    [Header("NPC")] // Data shared across every item
    public string NPCName;
    public Sprite NPCIcon;

    [InlineButton("DoPress", "Press Me")]
    public AudioClip PickupClip;

    public abstract SO_NPC GetItem();

    public abstract NPCData GetNPCData();
}
