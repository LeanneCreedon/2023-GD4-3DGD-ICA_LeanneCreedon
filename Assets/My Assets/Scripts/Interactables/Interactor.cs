using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Unity Interaction System | How To Interact With Any Game Object In Unity, Dan Pos -
/// https://www.youtube.com/watch?v=THmW4YolDok&t=861s
/// accessed - 19/12/2023
/// ---------------------
/// Script for handling the interaction between the player and other objects that are interactable.
/// </summary>
public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _InteractionPoint;
    [SerializeField] private float _InteractionPointRadius = 0.5f;
    [SerializeField] private LayerMask _InteractableMask;
    [SerializeField] private InteractionPromptUI _InteractionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;
    [SerializeField] public GameObject interactedObject;

    private IInteractable _interactable;

    private void Update()
    {
        // Get the number of interactable objects the player is currently colliding with
        _numFound = Physics.OverlapSphereNonAlloc(_InteractionPoint.position, _InteractionPointRadius, _colliders, _InteractableMask);

        // If they are colliding with something...
        if (_numFound > 0)
        {
            // Get the interactable component for the object
            _interactable = _colliders[0].GetComponent<IInteractable>();

            // If they object contains the interactable componant
            if (_interactable != null)
            {
                // If the interaction prompt is not already being displayed, display it
                if (!_InteractionPromptUI.IsDisplayed) _InteractionPromptUI.SetUp(_interactable.InteractionPrompt);

                // If the player pressed the E key
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    // Call the interact method and pass in the object
                    interactedObject = _colliders[0].gameObject;
                    _interactable.Interact(this);
                }
            }
        }
        else
        {
            // Otherwise, set _interactable to null and close the UI prompt
            if (_interactable != null) _interactable = null;
            if (_InteractionPromptUI.IsDisplayed) _InteractionPromptUI.Close();
        }
    }

    // Method to show the interaction radius which is being used to detect the interact collisions
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_InteractionPoint.position, _InteractionPointRadius);
    }
}
