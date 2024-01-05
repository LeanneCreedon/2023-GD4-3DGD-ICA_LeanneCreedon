using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Niall's Repo 2023_GD4_Introduction:
/// https://github.com/nmcguinness/2023_GD4_Introduction
/// accessed - 17/12/2023
/// ---------------------
/// Interface for selection of an object.
/// </summary>
public interface ISelector
{
    void Check(Ray ray);

    Transform GetSelection();

    RaycastHit GetHitInfo();
}
