//------------------------------------------------------------------------------
//
// File Name:	GoalEdge.cs
// Author(s):	Gavin Cooper
//
// Project:		GMTK Game Jam 2021
//
// Description: A script that handles checking if a box is touching the edge of the goal
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalEdge : MonoBehaviour
{
    // Check for box ENTERING area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var BoxScript = collision.gameObject.GetComponent<BoxInfo>();

        if (BoxScript == null)
        {
            return;
        }

        BoxScript.TouchingEdge = true;
    }

    // Check for box LEAVING area
    private void OnTriggerExit2D(Collider2D collision)
    {
        var BoxScript = collision.gameObject.GetComponent<BoxInfo>();

        if (BoxScript == null)
        {
            return;
        }

        BoxScript.TouchingEdge = false;
    }
}
