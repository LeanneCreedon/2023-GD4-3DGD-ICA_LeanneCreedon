using UnityEngine;
using UnityEngine.InputSystem;

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
        _numFound = Physics.OverlapSphereNonAlloc(_InteractionPoint.position, _InteractionPointRadius, _colliders, _InteractableMask);

        if (_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if (_interactable != null)
            {
                if (!_InteractionPromptUI.IsDisplayed) _InteractionPromptUI.SetUp(_interactable.InteractionPrompt);

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    interactedObject = _colliders[0].gameObject;
                    _interactable.Interact(this);
                }

            }
        }
        else
        {
            if (_interactable != null) _interactable = null;
            if (_InteractionPromptUI.IsDisplayed) _InteractionPromptUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_InteractionPoint.position, _InteractionPointRadius);
    }
}
