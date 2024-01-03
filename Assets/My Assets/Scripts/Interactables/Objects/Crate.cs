using UnityEngine;

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

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interact CRATE");
        if (!CheckHaveApple(targetItem))
        {
            Debug.Log("NEED APPLES");
            dialogueInteract.StartDialogue();
        }
        else
        {
            // remove item from inventory
            interactCrate.Raise();

            // Checking the next apple isActive
            for (int i = 0; i < appleObjects.Length; i++)
            {
                if (!appleObjects[i].activeSelf)
                {
                    appleObjects[i].SetActive(true);
                    Debug.Log("ADDED APPLE TO CRATE");
                    return true;
                }
            }
        }
        return true;
    }

    bool CheckHaveApple(SlotClass item)
    {
        if (inventoryManager.Contains(item.GetItem()) != null)
        {
            return true;
        }
        else return false;
    }
}