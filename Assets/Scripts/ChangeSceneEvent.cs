//------------------------------------------------------------------------------
//
// File Name:	ChangeSceneEvent.cs
// Author(s):	Gavin Cooper
//
// Project:		GMTK Game Jam 2021
//
// Description: A script that has a function that changes scenes
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneEvent : MonoBehaviour
{
    [Tooltip("Name of the scene you want this script to load")]
    public string SceneName;

    // Function to be called that loads new scene
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
