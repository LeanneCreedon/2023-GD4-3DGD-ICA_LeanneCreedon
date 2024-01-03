using UnityEngine;

public class Camp : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueInteract dialogueInteract;
    [SerializeField] private InventoryManager inventory;

    [Header("Crafting Torch")]
    [SerializeField] public ItemDataGameEvent OnPickup, OnRemove;
    [SerializeField] private SlotClass itemRequired;
    [SerializeField] private SlotClass newItem;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        dialogueInteract.StartDialogue();

        if (inventory.Contains(itemRequired.GetItem()) != null)
        {
            Debug.Log("CREATED FIRE TORCH!");

            if (inventory.Contains(newItem.GetItem()) == null)
            {
                // Add FireTorch to Inventory
                OnPickup.Raise(newItem.GetItem());
            }

            // Remove Torch from Inventory
            OnRemove.Raise(itemRequired.GetItem());
        }
        else
            Debug.Log("CANNOT CREATE FIRE TORCH...");
        return true;
    }
}
