using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueInteract dialogueInteract;
    [SerializeField] public ItemDataGameEvent OnPickup;

    private GameObject itemGO;
    private OnDestroyBehaviour onDestroy;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        itemGO = GameObject.Find(interactor.interactedObject.name);
        Collider collider = itemGO.GetComponent<Collider>();

        dialogueInteract.StartDialogue();
        PickupObject(collider);
        return true;
    }

    private bool PickupObject(Collider other)
    {
        if (other != null)
        {
            var behaviour = other.gameObject.GetComponent<Item>();
            var itemData = behaviour.GetItem();

            OnPickup.Raise(itemData);

            AudioSource.PlayClipAtPoint(itemData.PickupClip, itemGO.transform.position);

            Destroy(other.gameObject);

            return true;
        }
        return false;
    }
}
