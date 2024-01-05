using System.Collections;
using UnityEngine;
using TMPro;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Simple Dialogue System with Scriptable Objects - https://www.youtube.com/watch?v=z3XgjSb_Oh0
/// accessed - 31/12/2023
/// ---------------------
/// Script for handling the dialogue UI
/// </summary>
public class DialogueInteract : MonoBehaviour
{
    // Getting references to UI Components

    [SerializeField] Canvas dialogueCanvas;

    [SerializeField] TextMeshProUGUI dialogueText;

    [SerializeField] SO_DialogueObject dialogueObject;

    // Starting the Dialogue Coroutine
    public void StartDialogue()
    {
        StartCoroutine(DisplayDialogue());
    }

    // Displaying the Dialogue
    IEnumerator DisplayDialogue()
    {
        // Turning on Canvas
        dialogueCanvas.enabled = true;

        // Displaying dialogue text segments and displaying for the allocated time
        foreach (var dialogue in dialogueObject.dialogueSegments)
        {
            dialogueText.text = dialogue.dialogueText;
            yield return new WaitForSeconds(dialogue.dialogueDisplayTime);
        }

        // Turning off the  after dialogue has ended
        dialogueCanvas.enabled = false;
    }
}
