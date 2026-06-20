using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArtifactHUD : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text artifactName;
    public TMP_Text artifactWeight;

    void Start() 
    {
        panel.SetActive(false);
    }

    public void ShowArtifact(ArtifactData data)
    {
        panel.SetActive(true);
        artifactName.text = data.artifactName;
        artifactWeight.text = "Weight: " + data.weight;
    }

    public void HideArtifact()
    {
        panel.SetActive(false);
    }
}