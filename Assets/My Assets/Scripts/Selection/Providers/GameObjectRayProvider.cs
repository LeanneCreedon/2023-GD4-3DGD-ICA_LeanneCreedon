using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Niall's Repo 2023_GD4_Introduction:
/// https://github.com/nmcguinness/2023_GD4_Introduction
/// accessed - 26/12/2023
/// ---------------------
/// Allows a new ray to be created.
/// </summary>
public class GameObjectRayProvider : MonoBehaviour, IRayProvider
{
    [SerializeField]
    [Tooltip("Normally set to the in-game player game object")]
    private GameObject rayOrigin;

    private float gizmoRayLength = 20;
    private Ray ray;

    public Ray CreateRay()
    {
        ray = new Ray(rayOrigin.transform.position, rayOrigin.transform.forward);
        return ray;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        // Gizmos.DrawRay(ray);
        Gizmos.DrawLine(ray.origin,
            ray.origin + gizmoRayLength * ray.direction);
    }
}
