using UnityEngine;

public class SmoothFollowCamera : MonoBehaviour
{
    public Transform targetObject;
    public float followDistance = 15f; // The distance between the camera and the character
    public float heightOffset = 2f; // The height offset above the character
    public float rotationSpeed = 5f; // The speed of camera rotation around the character
    public bool lookAtTarget = false;

    void LateUpdate()
    {
        // Calculate the new position of the camera, keeping the followDistance and heightOffset above the character
        Vector3 newPosition = targetObject.position - targetObject.forward * followDistance + Vector3.up * heightOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * rotationSpeed);

        // Handle camera collision with obstacles
        if (Physics.Raycast(targetObject.position, transform.position - targetObject.position, out RaycastHit hit, followDistance))
        {
            transform.position = hit.point - (transform.position - targetObject.position).normalized * 0.2f;
        }

        if (lookAtTarget)
        {
            // Calculate the point to look at slightly above the target
            Vector3 lookAtPosition = targetObject.position + Vector3.up * heightOffset;

            // Smoothly rotate the camera to look at the calculated point
            Quaternion targetRotation = Quaternion.LookRotation(lookAtPosition - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            // Rotate the camera around the character to keep it centered
            transform.RotateAround(targetObject.position, Vector3.up, Input.GetAxis("Horizontal") * rotationSpeed);
        }
    }
}
