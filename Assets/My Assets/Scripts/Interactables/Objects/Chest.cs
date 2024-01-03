using UnityEngine;

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
    //[SerializeField] public bool hasKey;
    [SerializeField] public Animator animator;
    [SerializeField] public Bag bag;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        dialogueInteract.StartDialogue();
        if (bag.hasKey)
        {
            // Set Animation
            hasInteracted = true;
            isOpen = true;
            animator.SetBool("hasInteracted", hasInteracted);
            animator.SetBool("isOpen", isOpen);

            Debug.Log(itemInside.GetItem());

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