using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Niall's Repo 2023_GD4_Introduction:
/// https://github.com/nmcguinness/2023_GD4_Introduction
/// accessed - 17/12/2023
/// ---------------------
/// Interface for creating a Selection Response.
/// </summary>
public interface ISelectionResponse
{
    void OnSelect(Transform transform);
    void OnDeselect(Transform transform);
}

