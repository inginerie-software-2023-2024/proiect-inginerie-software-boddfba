using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        // Move forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }

        // Move left (technically, turn left and move forward)
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }

        // Move backward
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }

        // Move right (technically, turn right and move forward)
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }
}
