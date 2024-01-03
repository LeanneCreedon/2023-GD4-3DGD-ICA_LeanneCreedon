using UnityEngine;

[CreateAssetMenu(fileName = "new NPC Data", menuName = "Scriptable Objects/NPC/NPC Data")]
public class NPCData : SO_NPC
{
    // Data specific to NPC Data class
    public override SO_NPC GetItem() { return this; }

    public override NPCData GetNPCData() { return this; }
}
