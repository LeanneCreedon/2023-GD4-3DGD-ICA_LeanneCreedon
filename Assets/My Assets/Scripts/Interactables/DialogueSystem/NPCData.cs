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
[CreateAssetMenu(fileName = "new NPC Data", menuName = "Scriptable Objects/NPC/NPC Data")]
public class NPCData : SO_NPC
{
    // Data specific to NPC Data class
    public override SO_NPC GetNPC() { return this; }

    public override NPCData GetNPCData() { return this; }
}
