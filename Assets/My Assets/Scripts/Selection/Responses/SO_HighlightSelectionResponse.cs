using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_HighlightSelectionResponse", menuName = "Scriptable Objects/Responses/Highlight")]
[Serializable]
public class SO_HighlightSelectionResponse : ScriptableObject, ISelectionResponse
{
    [SerializeField]
    [Tooltip("Set selected (highlighted) material for game object")]
    private Material selectedMaterial;

    private Material currentOriginalMaterial;

    public void OnDeselect(Transform selection)
    {
        var renderer = selection.GetComponent<Renderer>();

        if (renderer != null && currentOriginalMaterial != null)
            renderer.material = currentOriginalMaterial;
    }

    public void OnSelect(Transform selection)
    {
        var renderer = selection.GetComponent<Renderer>();
        if (renderer != null)
        {
            currentOriginalMaterial = renderer.material;
            renderer.material = selectedMaterial;
        }
    }
}
