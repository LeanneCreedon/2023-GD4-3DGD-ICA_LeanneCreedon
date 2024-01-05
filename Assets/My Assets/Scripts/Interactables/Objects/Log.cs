using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Unity Interaction System | How To Interact With Any Game Object In Unity, Dan Pos -
/// https://www.youtube.com/watch?v=THmW4YolDok&t=861s
/// accessed - 23/12/2023
/// ---------------------
/// Script for handling the interaction response between the player and the Log object.
/// </summary>
public class Log : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueInteract dialogueInteract;

    public string InteractionPrompt => _prompt;

    // When the player interacts with the log, do the following...
    public bool Interact(Interactor interactor)
    {
        // Begin Dialogue
        dialogueInteract.StartDialogue();
        return true;
    }
}
