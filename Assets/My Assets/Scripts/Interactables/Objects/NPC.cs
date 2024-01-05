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
/// Script for handling the interaction response between the player and the NPCs.
/// </summary>
public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueInteract dialogueInteract;
    [SerializeField] SO_DialogueObject dialogueObject;

    [SerializeField] PlayerController characterController;
    public string InteractionPrompt => _prompt;
    private AudioClip audioClip;
    private AudioSource audioSource;
    private GameObject npcGO;

    // When the player interacts with an NPC, do the following...
    public bool Interact(Interactor interactor)
    {
        // Play the Mumble Sound 
        PlaySound(interactor);

        // Start a coroutine delay
        StartCoroutine(Delay());
        return true;
    }
    IEnumerator Delay()
    {
        // Disable the character controller so that you cannot move during the interaction,
        // allowing the player to focus on what they are saying
        characterController.enabled = false;

        // Display dialogue text on screen
        dialogueInteract.StartDialogue();

        // Begin time delay for each dialogue segment set in the inspector
        foreach (var dialogue in dialogueObject.dialogueSegments)
        {
            yield return new WaitForSeconds(dialogue.dialogueDisplayTime);
        }

        // After the dialogue is finished, re-enable the character controller
        characterController.enabled = true;

        // Stop the mumbling sound
        //audioSource.Stop();
    }

    // Play the sound effect
    void PlaySound(Interactor interactor)
    {
        // Get the game object (NPC) being interacted with
        npcGO = GameObject.Find(interactor.interactedObject.name);

        var behaviour = npcGO.gameObject.GetComponent<NPC_Data>();
        var npcData = behaviour.GetItem();

        // Get the audio clip assosiated with that NPC, set in the inspector
        audioClip = npcData.TalkingAudio;

        // Play the audio clip at that point
        AudioSource.PlayClipAtPoint(audioClip, npcGO.transform.position);
    }
}
