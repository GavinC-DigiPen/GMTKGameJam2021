//------------------------------------------------------------------------------
//
// File Name:	DestroyOnTime.cs
// Author(s):	Gavin Cooper
//
// Project:		GMTK Game Jam 2021
//
// Description: A script that destroys and object after time
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    public float TimeDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeDelay);
    }
}
