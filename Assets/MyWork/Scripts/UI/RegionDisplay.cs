using UnityEngine;
using TMPro;

public class RegionDisplay : MonoBehaviour
{
    public Transform player;
    public TMP_Text regionText;

    void Update()
    {
        Vector3 p = player.position.normalized;

        float latitude = Mathf.Asin(p.y) * Mathf.Rad2Deg;
        float longitude = Mathf.Atan2(p.z, p.x) * Mathf.Rad2Deg;

        string region = "Unknown";

        if (latitude > 60)
            region = "Arctic";

        else if (latitude < -60)
            region = "Antarctica";

        else if (longitude >= -170 && longitude < -30)
            region = "Americas";

        else if (longitude >= -30 && longitude < 60)
            region = "Europe / Africa";

        else if (longitude >= 60 && longitude < 180)
            region = "Asia / Australia";

        regionText.text = "Region: " + region;
    }
}