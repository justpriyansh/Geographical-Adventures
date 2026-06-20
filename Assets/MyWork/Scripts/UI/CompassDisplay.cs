using UnityEngine;
using TMPro;

public class CompassDisplay : MonoBehaviour
{
    public Transform player;
    public TMP_Text compassText;

    void Update()
    {
        Vector3 gravityUp = player.position.normalized;

        Vector3 north = Vector3.ProjectOnPlane(Vector3.up, gravityUp).normalized;

        Vector3 forward = Vector3.ProjectOnPlane(player.forward, gravityUp).normalized;

        float angle = Vector3.SignedAngle(north, forward, gravityUp);

        if (angle < 0)
            angle += 360f;

        string direction = "N";

        if (angle >= 22.5f && angle < 67.5f)
            direction = "NE";
        else if (angle >= 67.5f && angle < 112.5f)
            direction = "E";
        else if (angle >= 112.5f && angle < 157.5f)
            direction = "SE";
        else if (angle >= 157.5f && angle < 202.5f)
            direction = "S";
        else if (angle >= 202.5f && angle < 247.5f)
            direction = "SW";
        else if (angle >= 247.5f && angle < 292.5f)
            direction = "W";
        else if (angle >= 292.5f && angle < 337.5f)
            direction = "NW";

        compassText.text = direction;
    }
}