using UnityEngine;
using TMPro;
using System.Collections;

public class PickupNotification : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text notificationText;

    public void ShowNotification(string artifactName)
    {
        StartCoroutine(NotificationRoutine(artifactName));
    }

    IEnumerator NotificationRoutine(string artifactName)
    {
        panel.SetActive(true);

        notificationText.text = "Artifact Recovered!\n" + artifactName;

        yield return new WaitForSeconds(2f);

        panel.SetActive(false);
    }
}