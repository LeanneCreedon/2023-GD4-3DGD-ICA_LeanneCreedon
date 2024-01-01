using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueInteract dialogueInteract;
    [SerializeField] private ItemDataGameEvent eventPickup;

    private SO_ItemClass item;
    private GameObject itemGO;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        dialogueInteract.StartDialogue();
        //eventPickup.Raise(interactor.gameObject.GetComponent<SO_ItemClass>().GetItem());
        //eventPickup.Raise(interactor.gameObject.GetComponent<SlotClass>().GetItem());
        itemGO = GameObject.Find(interactor.interactedObject.name);
        //item = itemGO.GetComponent<SO_ItemClass>();
        SO_ItemClass item = itemGO.GetComponent<SO_ItemClass>();

        Debug.Log("NAME = " + interactor.interactedObject.name);
        Debug.Log("GAME OBJECT = " + itemGO);

        Debug.Log("ITEM OBJECT = " + item.name);
        Debug.Log("ITEM OBJECT = " + item.GetItem());



        PickupObject(item);
        return true;
    }

    private bool PickupObject(SO_ItemClass item)
    {
        if (item != null)
        {
            eventPickup.Raise(item);
            Destroy(item);
            return true;
        }
        else
            return false;
    }
}
