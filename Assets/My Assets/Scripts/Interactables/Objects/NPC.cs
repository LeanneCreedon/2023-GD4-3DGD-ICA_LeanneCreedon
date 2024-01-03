using System.Collections;
using UnityEngine;

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

    public bool Interact(Interactor interactor)
    {
        PlaySound(interactor);

        StartCoroutine(Delay());
        return true;
    }
    IEnumerator Delay()
    {
        characterController.enabled = false;
        dialogueInteract.StartDialogue();
        foreach (var dialogue in dialogueObject.dialogueSegments)
        {
            yield return new WaitForSeconds(dialogue.dialogueDisplayTime);
        }
        characterController.enabled = true;
        audioSource.Stop();
    }

    void PlaySound(Interactor interactor)
    {
        npcGO = GameObject.Find(interactor.interactedObject.name);

        var behaviour = npcGO.gameObject.GetComponent<NPC_Data>();
        var npcData = behaviour.GetItem();

        audioClip = npcData.PickupClip;

        AudioSource.PlayClipAtPoint(audioClip, npcGO.transform.position);
    }
}
