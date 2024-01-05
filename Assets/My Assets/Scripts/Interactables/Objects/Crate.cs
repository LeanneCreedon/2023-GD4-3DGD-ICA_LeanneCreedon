using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Unity Interaction System | How To Interact With Any Game Object In Unity, Dan Pos -
/// https://www.youtube.com/watch?v=THmW4YolDok&t=861s
/// accessed - 23/12/2023
/// ---------------------
/// Script for handling the interaction response between the player and the Crate object.
/// </summary>
public class Crate : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueInteract dialogueInteract;
    [SerializeField] public InventoryManager inventoryManager;
    [SerializeField] public SlotClass targetItem;

    [SerializeField] private SGO_GameEvent interactCrate;

    [Header("Objects In Crate To Set Active")]
    [SerializeField] private GameObject[] appleObjects;

    public string InteractionPrompt => _prompt;

    // When the player interacts with the crate, do the following
    public bool Interact(Interactor interactor)
    {
        // Check if the player does not have any apples
        if (!CheckHaveApple(targetItem))
        {
            dialogueInteract.StartDialogue();
        }
        else
        {
            // Remove an apple from inventory
            interactCrate.Raise();

            // Checking the next apple to isActive() to true in the scene (an apple will appear in the crate).
            for (int i = 0; i < appleObjects.Length; i++)
            {
                if (!appleObjects[i].activeSelf)
                {
                    appleObjects[i].SetActive(true);
                    return true;
                }
            }
        }
        return true;
    }

    // Method to check if there is an apple in the inventory
    bool CheckHaveApple(SlotClass item)
    {
        if (inventoryManager.Contains(item.GetItem()) != null)
        {
            return true;
        }
        else return false;
    }
}