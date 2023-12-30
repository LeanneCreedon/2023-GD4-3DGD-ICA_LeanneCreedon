using UnityEngine;

public interface ISelectionResponse
{
    void OnSelect(Transform transform);
    void OnDeselect(Transform transform);
}

