//------------------------------------------------------------------------------
//
// File Name:	Goal.cs
// Author(s):	Gavin Cooper
//
// Project:		GMTK Game Jam 2021
//
// Description: A script that handles the counting of score with boxes
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public string Typeing = "Default";

    // Check for box DEING IN area
    private void OnTriggerStay2D(Collider2D collision)
    {
        var BoxScript = collision.gameObject.GetComponent<BoxInfo>();

        // Check BoxScript exists
        if (BoxScript == null)
        {
            return;
        }

        // Check if box and goal match
        if (BoxScript.Type != Typeing)
        {
            return;
        }

        // Add or remove score
        if (!BoxScript.TouchingEdge && !BoxScript.InGoal)
        {
            GameManager.Score += BoxScript.ScoreValue;

            BoxScript.InGoal = true;
        }
        else if (BoxScript.TouchingEdge && BoxScript.InGoal)
        {
            GameManager.Score -= BoxScript.ScoreValue;

            BoxScript.InGoal = false;
        }
    }

    // Check for when EXITING area
    private void OnTriggerExit2D(Collider2D collision)
    {
        var BoxScript = collision.gameObject.GetComponent<BoxInfo>();

        // Check BoxScript exists
        if (BoxScript == null)
        {
            return;
        }

        // Check if box and goal match
        if (BoxScript.Type != Typeing)
        {
            return;
        }

        // Remove score
        if (BoxScript.InGoal)
        {
            BoxScript.InGoal = false;
            GameManager.Score -= BoxScript.ScoreValue;
        }
    }
}
