using System.Collections;
using UnityEngine;

public class FallenTree : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueInteract dialogueInteract;
    [SerializeField] private InventoryManager inventory;

    [Header("Setting Tree on Fire")]
    [SerializeField] public GameObject fireVFX;
    [SerializeField] public ItemDataGameEvent OnRemove;
    [SerializeField] private SlotClass itemRequired;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        dialogueInteract.StartDialogue();

        if (inventory.Contains(itemRequired.GetItem()) != null)
        {
            Debug.Log("BURNT DOWN TREE");

            // Remove Torch from Inventory
            OnRemove.Raise(itemRequired.GetItem());

            fireVFX.SetActive(true);
            BeginDestruction();
        }
        else
            Debug.Log("CANNOT BURN DOWN TREE! NEED FLAME");
        return true;
    }
    public void BeginDestruction()
    {
        StartCoroutine(DelayDestroy());
    }

    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(10);
        fireVFX.SetActive(false);
        Destroy(this.gameObject);
    }
}
