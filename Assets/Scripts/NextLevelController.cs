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
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevelController : MonoBehaviour
{
    public string SceneName;
    public int ScoreNeeded = 10;
    public GameObject ScoreBar = null;

    private RectTransform ScoreBarTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        // Get ScoreBar tranfrom
        ScoreBarTransform = ScoreBar.GetComponent<RectTransform>();

        // Reset score
        GameManager.Score = 0;

        // CheckScore and add listener to keep track of the score changing
        CheckScore();
        GameManager.OnVariablesUpdate.AddListener(CheckScore);
    }

    // Check if the score is high enought to go to the next level
    void CheckScore()
    {   
        // Check if finished
        if (GameManager.Score >= ScoreNeeded)
        {
            SceneManager.LoadScene(SceneName);
        }

        // Edit bar
        if (ScoreBar != null)
        {
            ScoreBarTransform.sizeDelta = new Vector2 (((float)GameManager.Score / (float)ScoreNeeded) * 100f, 100);
            ScoreBarTransform.localPosition = new Vector2 ((ScoreBarTransform.rect.width - 100f) / 2f, 0);
        }
        
    }

    //remove listener when destroyed
    void OnDestory()
    {
        GameManager.OnVariablesUpdate.RemoveListener(CheckScore);
    }
}
