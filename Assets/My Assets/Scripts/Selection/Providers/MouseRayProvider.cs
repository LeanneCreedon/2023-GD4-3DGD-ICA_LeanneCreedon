using UnityEngine;

/// <summary>
/// NOT IN USE
/// </summary>
public class MouseRayProvider : MonoBehaviour, IRayProvider
{
    public Ray CreateRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}

