//------------------------------------------------------------------------------
//
// File Name:	ResetLevel.cs
// Author(s):	Gavin Cooper
//
// Project:		GMTK Game Jam 2021
//
// Description: A script that resets the scene
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    public KeyCode Reset = KeyCode.R;

    // Update is called once per frame
    void Update()
    {
        // Check if buttom pressed
        if (Input.GetKeyDown(Reset))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
