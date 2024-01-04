using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Most of this Code Genterated using ChatGTP
/// </summary>
public class ObjectiveManager : MonoBehaviour
{
    public List<SO_Objective> objectives;

    [SerializeField] InventoryManager inventory;
    [SerializeField] TextMeshProUGUI objectiveText;
    [SerializeField] Image backgroundImg;

    int objectiveIndex;

    // Singleton pattern to ensure only one instance exists
    private static ObjectiveManager _instance;
    public static ObjectiveManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ObjectiveManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = "ObjectiveManager";
                    _instance = obj.AddComponent<ObjectiveManager>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        objectiveIndex = 0;
        objectiveText.text = objectives[objectiveIndex].objectiveName;

        // Ensure only one instance of ObjectiveManager exists
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        // Initialize objectives - Setting completed to false initailly
        objectives.ForEach(obj => obj.isCompleted = false);
    }

    public void CompleteObjective(SO_Objective objective)
    {
        if (objectives.Contains(objective))
        {
            objective.MarkAsCompleted();
            CheckObjectivesCompletion();
        }
        else
        {
            Debug.LogWarning("Attempting to complete an objective that is not in the list.");
        }
    }

    private void CheckObjectivesCompletion() // check overall completion of objectives
    {
        // Change the objective UI element
        objectiveText.text = objectives[objectiveIndex++].objectiveName;

        // initally setting to all complete
        bool allObjectivesCompleted = true;

        // going through list of objectives and search for incomplete objectives
        foreach (var objective in objectives)
        {
            if (!objective.isCompleted)
            {
                objectiveText.text = objective.name;
                allObjectivesCompleted = false;
                break;
            }
        }

        if (allObjectivesCompleted)
        {
            // Trigger an event, show a message, or perform any other action when all objectives are completed.
            Debug.Log("All objectives completed!");
        }
    }
}
