using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private SO_ItemClass itemToFind;
    [SerializeField] private DialogueInteract dialogueInteract;

    [SerializeField] public bool isOpen = false;
    [SerializeField] public Animator animator;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        dialogueInteract.StartDialogue();
        return true;
        /*
        var inventory = interactor.inventory;

        if (inventory == null) { return false; }

        if (inventory.items.Contains(itemToFind.GetItem())
        {
            dialogueInteract.StartDialogue();
            isOpen = true;
            animator.SetBool("IsOpen", isOpen);
            return true;
        }

        return false;
        */
    }
}