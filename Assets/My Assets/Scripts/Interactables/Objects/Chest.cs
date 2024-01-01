using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private SO_ItemClass itemToFind;
    [SerializeField] private DialogueInteract dialogueInteract;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.inventory;

        if (inventory == null) { return false; }

        if (inventory.items.Contains(itemToFind))
        {
            dialogueInteract.StartDialogue();
            return true;
        }

        dialogueInteract.StartDialogue();
        return false;
    }
}