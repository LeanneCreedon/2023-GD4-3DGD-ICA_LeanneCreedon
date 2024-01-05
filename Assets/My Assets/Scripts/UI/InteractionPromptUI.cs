using TMPro;
using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Unity Interaction System | How To Interact With Any Game Object In Unity, Dan Pos -
/// https://www.youtube.com/watch?v=THmW4YolDok&t=861s
/// accessed - 19/12/2023
/// ---------------------
/// Script for handling the interaction Panel that shows above the player when they are near an interactable object.
/// </summary>
public class InteractionPromptUI : MonoBehaviour
{
    [SerializeField] private Camera _UICam;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;

    private void Start()
    {
        _uiPanel.SetActive(false);
    }

    private void LateUpdate()
    {
        var rotaion = _UICam.transform.rotation;
        transform.LookAt(transform.position + rotaion * Vector3.forward, rotaion * Vector3.up);
    }

    public bool IsDisplayed = false;

    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}
