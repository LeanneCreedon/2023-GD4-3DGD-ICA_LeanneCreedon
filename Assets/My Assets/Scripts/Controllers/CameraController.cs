using UnityEngine;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Click To Move | Unity RPG Tutorial #1 - https://www.youtube.com/watch?v=LVu3_IVCzys
/// accessed - 22/12/2023
/// ---------------------
/// Script to handle the camera controller to follow player
/// </summary>
public class CameraController : MonoBehaviour
{
    // Transform of the player target
    public Transform target;

    // Adjusting speed and offset
    public float smoothSpeed = 8f;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        // Camera to the desired position and smoothing it out using Lerp.
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
