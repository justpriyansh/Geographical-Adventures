using UnityEngine;

public class MyCharacter : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float worldRadius = 150f;
    public float alignSpeed = 10f;
    public float turnSpeed = 5f;

    [HideInInspector] public float speedModifier = 0f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 gravityUp = transform.position.normalized * worldRadius;

        Quaternion alignRotation = Quaternion.FromToRotation(transform.up, gravityUp) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, alignRotation, alignSpeed * Time.deltaTime);

        Vector3 forward = Vector3.Cross(transform.right, gravityUp).normalized;
        Vector3 moveDirection = (forward * v + transform.right * h).normalized;

        if (moveDirection.sqrMagnitude > 0.01f)
        {
            float currentSpeed = Mathf.Max(3f, moveSpeed - speedModifier);

            transform.position += moveDirection * currentSpeed * Time.deltaTime;

            Quaternion targetRotation = Quaternion.LookRotation(
                Vector3.ProjectOnPlane(moveDirection, gravityUp),
                gravityUp
            );

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                turnSpeed * Time.deltaTime
            );
        }

        transform.position = transform.position.normalized * (worldRadius + 1.2f);
    }
}