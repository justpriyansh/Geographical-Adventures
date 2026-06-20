using UnityEngine;

public class TPPCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 6f, height = 2f, mouseSensitivity = 3f, followSmoothness = 10f;

    float yaw, pitch = 20f;

    void LateUpdate()
    {
        if (target == null) return;

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch - Input.GetAxis("Mouse Y") * mouseSensitivity, -60f, 60f);

        Vector3 gravityUp = target.position.normalized;
        Quaternion cameraRotation = Quaternion.FromToRotation(Vector3.up, gravityUp) * Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position - cameraRotation * Vector3.forward * distance + gravityUp * height;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSmoothness * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, followSmoothness * Time.deltaTime);
    }
}