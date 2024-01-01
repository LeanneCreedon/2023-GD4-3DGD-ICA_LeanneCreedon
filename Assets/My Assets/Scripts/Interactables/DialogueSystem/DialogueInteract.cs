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
        for (int i = 0; i < dialogueObject.dialogueStrings.Count; i++)
        {
            Debug.Log(dialogueObject.dialogueStrings[i]);
            dialogueText.text = dialogueObject.dialogueStrings[i];
            yield return new WaitForSeconds(1f);
        }
        dialogueCanvas.enabled = false;
    }
}
