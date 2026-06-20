using UnityEngine;

[CreateAssetMenu(fileName = "Artifact", menuName = "Artifacts/Artifact Data")]
public class ArtifactData : ScriptableObject
{
    public string artifactName;
    [TextArea] public string description;
    public float weight;
    public Sprite icon;
    public Vector3 holdOffset;
}