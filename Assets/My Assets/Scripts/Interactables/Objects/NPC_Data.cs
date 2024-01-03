using UnityEngine;

public class NPC_Data : MonoBehaviour
{
    [SerializeField]
    private SO_NPC npcData;

    public SO_NPC GetItem()
    {
        return npcData;
    }
}
