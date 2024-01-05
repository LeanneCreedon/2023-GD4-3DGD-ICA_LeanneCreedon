using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Simple Dialogue System with Scriptable Objects, Jared Brandjes -
/// https://www.youtube.com/watch?v=z3XgjSb_Oh0
/// accessed - 30/12/2023
/// ---------------------
/// Scriptable Object for dialogue string and duration shown on screen.
/// </summary>
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