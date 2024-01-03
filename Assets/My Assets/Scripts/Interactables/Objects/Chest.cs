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
            isOpen = true;
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
        return true;
    }
}