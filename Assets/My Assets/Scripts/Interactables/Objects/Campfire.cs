using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Unity Interaction System | How To Interact With Any Game Object In Unity, Dan Pos -
/// https://www.youtube.com/watch?v=THmW4YolDok&t=861s
/// accessed - 23/12/2023
/// ---------------------
/// Script for handling the interaction response between the player and the Campfire object.
/// </summary>
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

        // If the player has the required item, which is a torch
        if (inventory.Contains(itemRequired.GetItem()) != null)
        {
            // if they player does not already have the fire torch, then add it to inventory using pickup event
            if (inventory.Contains(newItem.GetItem()) == null)
            {
                // Add FireTorch to Inventory
                OnPickup.Raise(newItem.GetItem());
            }
            // Remove Torch from Inventory
            OnRemove.Raise(itemRequired.GetItem());
        }
        return true;
    }
}
