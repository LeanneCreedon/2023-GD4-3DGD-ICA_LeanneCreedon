using System.Collections;
using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Unity Interaction System | How To Interact With Any Game Object In Unity, Dan Pos -
/// https://www.youtube.com/watch?v=THmW4YolDok&t=861s
/// accessed - 23/12/2023
/// ---------------------
/// Script for handling the interaction response between the player and the bag object.
/// </summary>
public class Bag : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueInteract dialogueInteract;

    [SerializeField] private SGO_GameEvent searchEvent;

    [SerializeField] public bool hasKey = false;

    public string InteractionPrompt => _prompt;

    // When this is called, we check if the player already has the key
    // If they don't, play the dialogue and add item to inventory.
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

    // Delay the key being added to the inventory to simulate the player searching
    // through the bag before they find it
    IEnumerator DelayKeyAdd()
    {
        hasKey = true;
        yield return new WaitForSeconds(7);

        searchEvent.Raise();
    }
}