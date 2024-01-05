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

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform, Vector3.back);
        transform.Rotate(Vector3.right * 180f);
    }

    private void OnEnable()
    {
        PlayerController.OnInteract += Interact;
        PlayerController.OnEnterInteractable += ShowUI;
        PlayerController.OnExitInteractable += HideUI;
    }
    private void OnDisable()
    {
        PlayerController.OnInteract -= Interact;
        PlayerController.OnEnterInteractable -= ShowUI;
        PlayerController.OnExitInteractable -= HideUI;
    }
    void Interact()
    {
        OnInteract.Invoke();
    }

    void ShowUI()
    {
        canvas.enabled = true;
    }

    void HideUI()
    {
        canvas.enabled = false;
    }
}
