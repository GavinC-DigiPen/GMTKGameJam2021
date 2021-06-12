//------------------------------------------------------------------------------
//
// File Name:	ChangeSceneEvent.cs
// Author(s):	Gavin Cooper
//
// Project:		GMTK Game Jam 2021
//
// Description: A script that changes to the next level when enought points has been reached
//
//------------------------------------------------------------------------------


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NextLevelController : MonoBehaviour
{
    public string SceneName;
    public int ScoreNeeded = 10;
    public TextMeshProUGUI MyTMP;

    // Start is called before the first frame update
    void Start()
    {
        // Set TMP to show score needed
        MyTMP = GetComponent<TextMeshProUGUI>();
        if (MyTMP != null)
        {
            MyTMP.text = "Score Needed: " + ScoreNeeded.ToString("N0");
        }

        // Reset score
        GameManager.Score = 0;

        // Add listener to keep track of the score changing
        GameManager.OnVariablesUpdate.AddListener(CheckScore);
    }

    // Check if the score is high enought to go to the next level
    void CheckScore()
    {
        if (GameManager.Score >= ScoreNeeded)
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    //remove listener when destroyed
    void OnDestory()
    {
        GameManager.OnVariablesUpdate.RemoveListener(CheckScore);
    }
}
