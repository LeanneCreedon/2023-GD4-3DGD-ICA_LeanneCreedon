using UnityEngine;

public class _CollectStickData : MonoBehaviour
{
    [SerializeField]
    private SO_Objective objectiveData;

    public SO_Objective GetObjective()
    {
        return objectiveData;
    }
}