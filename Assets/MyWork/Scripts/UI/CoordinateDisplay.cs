using UnityEngine;
using TMPro;

public class CoordinateDisplay : MonoBehaviour
{
    public Transform player;
    public TMP_Text coordinatesText;

    void Update()
    {
        Vector3 p = player.position.normalized;

        float latitude = Mathf.Asin(p.y) * Mathf.Rad2Deg;
        float longitude = Mathf.Atan2(p.z, p.x) * Mathf.Rad2Deg;

        coordinatesText.text =
            $"Lat: {latitude:F2}\nLon: {longitude:F2}";
    }
}