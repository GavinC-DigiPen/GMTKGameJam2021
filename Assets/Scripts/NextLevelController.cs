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
    public float HoldTime = 0f;
    public float ScreenChangeDelay = 1f;
    public GameObject ScoreBar = null;

    private bool Timer = false;
    private float HoldTimeTimer = 0;
    private RectTransform ScoreBarTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        // Get ScoreBar tranfrom
        if (ScoreBar != null)
        {
            ScoreBarTransform = ScoreBar.GetComponent<RectTransform>();
        }

        // Reset score
        GameManager.Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if score is met
        if (GameManager.Score >= ScoreNeeded)
        {
            // Add to timer
            HoldTimeTimer += Time.deltaTime;

            // If timer is up, change scene
            if (HoldTimeTimer >= HoldTime)
            {
                Invoke("ChangeScene", ScreenChangeDelay);
            }
        }
        else
        {
            // Reset timer
            HoldTimeTimer = 0;
        }

        Debug.Log(HoldTimeTimer);

        // Edit bar
        if (ScoreBar != null)
        {
            ScoreBarTransform.sizeDelta = new Vector2(((float)GameManager.Score / (float)ScoreNeeded) * 100f, 100);
            ScoreBarTransform.localPosition = new Vector2((ScoreBarTransform.rect.width - 100f) / 2f, 0);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneName);
    }

}
