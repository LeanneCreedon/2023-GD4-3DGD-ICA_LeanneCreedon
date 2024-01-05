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
/// Script for handling the interaction response between the player and the Fallen Tree object.
/// </summary>
public class FallenTree : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueInteract dialogueInteract;
    [SerializeField] private InventoryManager inventory;
    [SerializeField] private ObjectiveManager objectiveManager;

    [Header("Setting Tree on Fire")]
    [SerializeField] public GameObject fireVFX;
    [SerializeField] public ItemDataGameEvent OnRemove;
    [SerializeField] private SlotClass itemRequired;

    public string InteractionPrompt => _prompt;

    // When the player interacts with the fallen tree object, do the following
    public bool Interact(Interactor interactor)
    {
        // Begin dialogue
        dialogueInteract.StartDialogue();

        // Check if the inventory contains the required item, in this case, the FireTorch
        if (inventory.Contains(itemRequired.GetItem()) != null)
        {
            // Remove Torch from Inventory
            OnRemove.Raise(itemRequired.GetItem());

            // Setting active the fire effect on the tree so it looks to be burning down.
            fireVFX.SetActive(true);

            // Begin destruction of the tree object
            BeginDestruction();
        }
        return true;
    }

    // Start a coroutine
    public void BeginDestruction()
    {
        StartCoroutine(DelayDestroy());
    }

    // Delay the destruction of the tree for visual effect
    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(10);

        // Update Objective Text (crude way but works for now)
        objectiveManager.objectiveText.text = objectiveManager.objectives[1].objectiveName;

        // Turning off the fire effect before the tree gets burnt down (destroyed)
        fireVFX.SetActive(false);
        Destroy(this.gameObject);
    }
}
