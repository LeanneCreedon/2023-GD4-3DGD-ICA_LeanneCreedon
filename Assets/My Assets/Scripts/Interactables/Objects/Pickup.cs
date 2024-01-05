using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Unity Interaction System | How To Interact With Any Game Object In Unity, Dan Pos -
/// https://www.youtube.com/watch?v=THmW4YolDok&t=861s
/// accessed - 22/12/2023
/// ---------------------
/// Script for handling the interaction response between the player and the pickup object.
/// </summary>
public class Pickup : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueInteract dialogueInteract;
    [SerializeField] public ItemDataGameEvent OnPickup;

    private GameObject itemGO;

    public string InteractionPrompt => _prompt;

    // When the player interacts with the Pickup object, do the following...
    public bool Interact(Interactor interactor)
    {
        // Get the game object collider
        itemGO = GameObject.Find(interactor.interactedObject.name);
        Collider collider = itemGO.GetComponent<Collider>();

        // Play the dialogue sequence
        dialogueInteract.StartDialogue();

        // Pickup the object
        PickupObject(collider);
        return true;
    }

    // Pickup the game object by raising an event
    private bool PickupObject(Collider other)
    {
        // If the collider is not null
        if (other != null)
        {
            var behaviour = other.gameObject.GetComponent<Item>();
            var itemData = behaviour.GetItem();

            // Raise the event
            OnPickup.Raise(itemData);

            // Play the pickup audio clip
            AudioSource.PlayClipAtPoint(itemData.PickupClip, itemGO.transform.position);

            // Destroy the game object
            Destroy(other.gameObject);

            return true;
        }
        return false;
    }
}
