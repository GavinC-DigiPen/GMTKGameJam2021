//------------------------------------------------------------------------------
//
// File Name:	BoxInfo.cs
// Author(s):	Gavin Cooper
//
// Project:		GMTK Game Jam 2021
//
// Description: A script that hold info about the box
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInfo : MonoBehaviour
{
    public int ScoreValue;
    public bool InGoal;
    public bool TouchingEdge;
    public bool AttachedToRope;
    public string Type = "Default";
}
