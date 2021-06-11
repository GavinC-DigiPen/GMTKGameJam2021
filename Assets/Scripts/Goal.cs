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
    // Check for box ENTERING area
    private void OnTriggerStay2D(Collider2D collision)
    {
        var BoxScript = collision.gameObject.GetComponent<BoxInfo>();

        if (BoxScript == null)
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
}
