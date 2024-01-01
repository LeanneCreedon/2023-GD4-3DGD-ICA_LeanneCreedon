using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueObject", menuName = "Scriptable Objects/Events/NPC Dialogue Object")]
public class SO_DialogueObject : ScriptableObject
{
    [Header("Dialogue")]
    public List<string> dialogueStrings = new List<string>();

    [Header("Follow on dialogue - Optional")]
    public SO_DialogueObject endDialogue; // Optional
}
