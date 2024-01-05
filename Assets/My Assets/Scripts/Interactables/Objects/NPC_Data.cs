using UnityEngine;

/// <summary>
/// Script for handling the data of the NPC Scriptable object so that it can be attached to the NPC
/// as it is a MonoBehaviour
/// </summary>
public class NPC_Data : MonoBehaviour
{
    [SerializeField]
    private SO_NPC npcData;

    public SO_NPC GetItem()
    {
        return npcData;
    }
}
