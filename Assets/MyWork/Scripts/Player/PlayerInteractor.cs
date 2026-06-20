using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public Transform holdPoint;
    public float interactDistance = 3f;
    public ArtifactHUD hud;
    public ObjectiveTracker objectiveTracker;
    public PickupNotification pickupNotification;

    Artifact carriedArtifact;
    MyCharacter player;

    void Start()
    {
        player = GetComponent<MyCharacter>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (carriedArtifact == null)
                PickupArtifact();
            else
                DropArtifact();
        }
    }

    void PickupArtifact()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, interactDistance);

        foreach (Collider hit in hits)
        {
            Artifact artifact = hit.GetComponent<Artifact>();

            if (artifact != null)
            {
                carriedArtifact = artifact;

                player.speedModifier = artifact.data.weight;

                artifact.transform.SetParent(holdPoint);
                artifact.transform.localPosition = artifact.data.holdOffset;
                artifact.transform.localRotation = Quaternion.identity;

                Rigidbody rb = artifact.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.isKinematic = true;

                if (hud != null)
                    hud.ShowArtifact(artifact.data);

                if (pickupNotification != null)
                    pickupNotification.ShowNotification(artifact.data.artifactName);

                if (objectiveTracker != null)
                {
                    if (artifact.data.artifactName == "Sword")
                        objectiveTracker.CollectSword();

                    else if (artifact.data.artifactName == "Gun")
                        objectiveTracker.CollectGun();

                    else if (artifact.data.artifactName == "Treasure")
                        objectiveTracker.CollectTreasure();
                }

                Debug.Log("Picked up: " + artifact.data.artifactName);
                Debug.Log("Weight: " + artifact.data.weight);

                return;
            }
        }
    }

    void DropArtifact()
    {
        player.speedModifier = 0f;

        carriedArtifact.transform.SetParent(null);

        carriedArtifact.transform.position =
            (transform.position + transform.right * 1.5f).normalized * 151f;

        Rigidbody rb = carriedArtifact.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        Debug.Log("Dropped: " + carriedArtifact.data.artifactName);

        if (hud != null)
            hud.HideArtifact();

        carriedArtifact = null;
    }
}