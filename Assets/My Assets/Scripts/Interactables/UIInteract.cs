using UnityEngine;
using UnityEngine.Events;

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
        Debug.Log("Interacting");
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
