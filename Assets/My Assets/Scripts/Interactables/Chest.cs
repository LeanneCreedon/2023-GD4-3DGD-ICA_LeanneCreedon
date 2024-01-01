using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private SO_ItemClass itemToFind;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory = interactor.inventory;

        if (inventory == null) { return false; }

        if (inventory.items.Contains(itemToFind))
        {
            Debug.Log("Opening Chest!");
            return true;
        }

        Debug.Log("Need Key!");
        return false;
    }
}