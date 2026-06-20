using UnityEngine;
using TMPro;

public class ObjectiveTracker : MonoBehaviour
{
    public TMP_Text objectiveText;
    public GameObject missionCompletePanel;


    public bool swordFound;
    public bool gunFound;
    public bool treasureFound;

    void Start()
    {
        UpdateObjective();

        if (missionCompletePanel != null)
        missionCompletePanel.SetActive(false);

    }

    void UpdateObjective()
    {
        if (swordFound && gunFound && treasureFound)
        {
            objectiveText.text = "Objective Complete!";
            if (missionCompletePanel != null)
                missionCompletePanel.SetActive(true);
            return;
        }

        string objectives = "Find:\n";

        if (swordFound)
        {
            objectives += "[Done] Sword\n";
        }
        else
        {
            objectives += "[ ] Sword\n";
        }

        if (gunFound)
        {
            objectives += "[Done] Gun\n";
        }
        else
        {
            objectives += "[ ] Gun\n";
        }

        if (treasureFound)
        {
            objectives += "[Done] Treasure";
        }
        else
        {
            objectives += "[ ] Treasure";
        }

        objectiveText.text = objectives;
    }

    public void CollectSword()
    {
        swordFound = true;
        UpdateObjective();
    }

    public void CollectGun()
    {
        gunFound = true;
        UpdateObjective();
    }

    public void CollectTreasure()
    {
        treasureFound = true;
        UpdateObjective();
    }
}