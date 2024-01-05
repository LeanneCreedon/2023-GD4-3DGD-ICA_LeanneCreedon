using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Unity Interaction System | How To Interact With Any Game Object In Unity, Dan Pos -
/// https://www.youtube.com/watch?v=THmW4YolDok&t=861s
/// accessed - 19/12/2023
/// ---------------------
/// Script for handling the UI of the interaction prompt above player.
/// </summary>
public class UIInteract : MonoBehaviour
{
    [SerializeField] UnityEvent OnInteract;

    Canvas canvas;

    // Get the Canvas Component on Awake and disable it initally
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update the UI to face the Main Camera transform and rotate it
    private void Update()
    {
        transform.LookAt(Camera.main.transform, Vector3.back);
        transform.Rotate(Vector3.right * 180f);
    }

    // When enabled, call the following methods...
    private void OnEnable()
    {
        PlayerController.OnInteract += Interact;
        PlayerController.OnEnterInteractable += ShowUI;
        PlayerController.OnExitInteractable += HideUI;
    }

    // When disabled, uncall the following methods...
    private void OnDisable()
    {
        PlayerController.OnInteract -= Interact;
        PlayerController.OnEnterInteractable -= ShowUI;
        PlayerController.OnExitInteractable -= HideUI;
    }

    // Invoke the OnInteract event
    void Interact()
    {
        OnInteract.Invoke();
    }

    // Show the UI for the interaction Prompt
    void ShowUI()
    {
        canvas.enabled = true;
    }

    // Hide the UI for the interaction Prompt
    void HideUI()
    {
        canvas.enabled = false;
    }
}
