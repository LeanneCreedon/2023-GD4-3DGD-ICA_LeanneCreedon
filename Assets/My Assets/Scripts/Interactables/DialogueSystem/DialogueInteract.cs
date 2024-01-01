using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueInteract : MonoBehaviour
{
    [SerializeField] Canvas dialogueCanvas;
    [SerializeField] TextMeshProUGUI dialogueText;

    [SerializeField] SO_DialogueObject dialogueObject;

    public void StartDialogue()
    {
        StartCoroutine(DisplayDialogue());
    }

    IEnumerator DisplayDialogue()
    {
        dialogueCanvas.enabled = true;
        foreach (var dialogue in dialogueObject.dialogueSegments)
        {
            dialogueText.text = dialogue.dialogueText;
            yield return new WaitForSeconds(dialogue.dialogueDisplayTime);
        }
        dialogueCanvas.enabled = false;
    }
}
