using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Niall's Repo 2023_GD4_Introduction:
/// https://github.com/nmcguinness/2023_GD4_Introduction
/// accessed - 29/12/2023
/// ---------------------
/// Stores data relating to a level comprised of multiple scenes
/// </summary>
/// <see cref="https://blogs.unity3d.com/2020/07/01/achieve-better-scene-workflow-with-scriptableobjects/"/>
[CreateAssetMenu(fileName = "GameLevel", menuName = "Scriptable Objects/Game/Level", order = 2)]
public class GameLevel : ScriptableGameObject
{
    [TabGroup("tab1", "Scenes", SdfIconType.PieChartFill)]
    [Searchable]
    public List<GameScene> Scenes;

    [TabGroup("tab1", "Objectives (optional)", SdfIconType.CardChecklist)]
    [Searchable]
    public List<GameObjective> Objectives;

    [TabGroup("tab1", "Postprocessing (optional)", SdfIconType.Fan)]
    public Volume PostProcessPrefab;

    [TabGroup("tab1", "Postprocessing (optional)")]
    public VolumeProfile DefaultPostProcessProfile;

    //internal
    private Volume instancePostProcessPrefab;

    public void LoadLevel()
    {
        foreach (GameScene scene in Scenes)
            scene.LoadScene();

        if (PostProcessPrefab != null && DefaultPostProcessProfile != null)
        {
            instancePostProcessPrefab = Instantiate(PostProcessPrefab);
            instancePostProcessPrefab.profile = DefaultPostProcessProfile;
        }
    }

    public void UnloadLevel()
    {
        foreach (GameScene scene in Scenes)
            scene.UnloadScene();

        if (instancePostProcessPrefab != null)
            Destroy(instancePostProcessPrefab);
    }
}