using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueObject", menuName = "Scriptable Objects/Dialogue/Dialogue Object")]
public class SO_DialogueObject : ScriptableObject
{
    [Header("Dialogue")]
    public List<DialogueSegment> dialogueSegments = new List<DialogueSegment>();

    [Header("Follow on dialogue - Optional")]
    public SO_DialogueObject endDialogue; // Optional
}

[System.Serializable]
public struct DialogueSegment
{
    public string dialogueText;

    public float dialogueDisplayTime;
}
