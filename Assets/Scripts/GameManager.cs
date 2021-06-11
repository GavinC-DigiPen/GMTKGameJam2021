//------------------------------------------------------------------------------
//
// File Name:	GameManager.cs
// Author(s):	Gavin Cooper
//
// Project:		GMTK Game Jam 2021
//
// Description: A script that stores global variables (time & score)
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //set up private variables
    private static int score = 0;

    //sends update when variable update
    public static UnityEvent OnVariablesUpdate = new UnityEvent();

    //set up the way to access each private variable
    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            OnVariablesUpdate.Invoke();
        }
    }
}
