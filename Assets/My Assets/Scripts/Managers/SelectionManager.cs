using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Niall's Repo 2023_GD4_Introduction:
/// https://github.com/nmcguinness/2023_GD4_Introduction
/// accessed - 17/12/2023
/// ---------------------
/// Allows us to attach multiple responses to a selected object
/// </summary>
public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private MouseRayProvider rayProvider;

    [SerializeField]
    private ISelector selector;

    [SerializeField]
    [RequireInterface(typeof(ISelectionResponse))]
    private List<ScriptableObject> selectionResponses;

    private Transform currentSelection;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        //get a ray provider
        rayProvider = GetComponent<MouseRayProvider>();

        //get a selector
        selector = GetComponent<ISelector>();
    }

    private void Update()
    {
        //set de-selected
        if (currentSelection != null)
        {
            foreach (ISelectionResponse response in selectionResponses)
                response.OnDeselect(currentSelection);
        }

        //create/get ray
        selector.Check(rayProvider.CreateRay());

        //get current selection (cast ray, do tag comparison)
        currentSelection = selector.GetSelection();

        //set selected
        if (currentSelection != null)
        {
            foreach (ISelectionResponse response in selectionResponses)
                response.OnSelect(currentSelection);
        }
    }
}