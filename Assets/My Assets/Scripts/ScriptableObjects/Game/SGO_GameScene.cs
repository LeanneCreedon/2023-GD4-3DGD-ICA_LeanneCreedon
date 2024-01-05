﻿using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Niall's Repo 2023_GD4_Introduction:
/// https://github.com/nmcguinness/2023_GD4_Introduction
/// accessed - 27/12/2023
/// ---------------------
/// Stores data relating to a single scene within a level
/// </summary>
/// <see cref="https://blogs.unity3d.com/2020/07/01/achieve-better-scene-workflow-with-scriptableobjects/"/>
[CreateAssetMenu(fileName = "GameScene", menuName = "Scriptable Objects/Game/Scene", order = 3)]
public class GameScene : ScriptableGameObject
{
    [Space()]
    [Header("Scene Info")]
    [Tooltip("Ensure that the object provided is a valid Unity scene")]
    public Object SceneObject; //store as generic object so that if we change scene name we can access the new name

    #region Properties

    //public string Name
    //{
    //    get
    //    {
    //        if (!SceneObject.GetType().Equals(typeof(Scene)))
    //            throw new System.Exception($"{SceneObject.name} is not a valid scene!");

    //        return SceneObject.name;
    //    }
    //}

    #endregion Properties

    public void LoadScene()
    {
        var sceneName = SceneObject.name;

        if (SceneManager.GetSceneByName(sceneName).isLoaded)
            return;

        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadScene()
    {
        var sceneName = SceneObject.name;

        if (SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.UnloadSceneAsync(sceneName);
    }
}