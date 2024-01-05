using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Unity Interaction System | How To Interact With Any Game Object In Unity, Dan Pos -
/// https://www.youtube.com/watch?v=THmW4YolDok&t=861s
/// accessed - 23/12/2023
/// ---------------------
/// Script for handling the interaction response between the player and the chest object.
/// </summary>
public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private SlotClass itemToFind;
    [SerializeField] private SlotClass itemInside;
    [SerializeField] private DialogueInteract dialogueInteract;
    [SerializeField] private InventoryManager inventory;
    [SerializeField] public ItemDataGameEvent OnPickup, OnRemove;

    [SerializeField] public bool isOpen;
    [SerializeField] public bool hasInteracted;
    [SerializeField] public Animator animator;
    [SerializeField] public Bag bag;

    public string InteractionPrompt => _prompt;

    // Called when the player interacts with the campfire
    public bool Interact(Interactor interactor)
    {
        // Begin dialogue, which is a message telling the player they need the key to open the chest.
        dialogueInteract.StartDialogue();

        // If the player has the key, do the following
        if (bag.hasKey)
        {
            // Set Animation
            hasInteracted = true;
            isOpen = true;
            animator.SetBool("hasInteracted", hasInteracted);
            animator.SetBool("isOpen", isOpen);

            // If the player does not already have the book item, then add it upon opening the chest
            if (inventory.Contains(itemInside.GetItem()) == null)
            {
                // Add Book to Inventory
                OnPickup.Raise(itemInside.GetItem());
            }

            // Remove Key from Inventory
            OnRemove.Raise(itemToFind.GetItem());
        }
        else
        {
            // Set Animation
            hasInteracted = true;
            animator.SetBool("hasInteracted", hasInteracted);
        }

        return true;
    }
}