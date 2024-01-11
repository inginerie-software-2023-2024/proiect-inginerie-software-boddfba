using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    [SerializeField] float sensitivity;

    float xRotation;
    float yRotation;

    private void Update()
    {
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        yRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);             // to stop the player from looking above/below 90

        transform.localEulerAngles = new Vector3(xRotation, yRotation, 0);
    }

}
