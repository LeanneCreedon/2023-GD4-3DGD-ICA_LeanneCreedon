using System.Collections;
using UnityEngine;

public class Bag : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueInteract dialogueInteract;

    [SerializeField] private SGO_GameEvent searchEvent;

    [SerializeField] public bool hasKey = false;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (!hasKey)
        {
            dialogueInteract.StartDialogue();
            BeginDelay();
        }
        return true;
    }

    void BeginDelay() { StartCoroutine(DelayKeyAdd()); }

    IEnumerator DelayKeyAdd()
    {
        hasKey = true;
        yield return new WaitForSeconds(8);

        searchEvent.Raise();
    }
}