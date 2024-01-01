using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueInteract dialogueInteract;

    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        dialogueInteract.StartDialogue();
        return true;
    }
}
