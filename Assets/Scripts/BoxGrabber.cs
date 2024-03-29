﻿//------------------------------------------------------------------------------
//
// File Name:	BoxGrabber.cs
// Author(s):	Gavin Cooper
//
// Project:		GMTK Game Jam 2021
//
// Description: A script that handles the rope grabbinng onto a box 
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGrabber : MonoBehaviour
{
    public KeyCode Drop = KeyCode.Space;
    public float BoxGrabCooldown = 0.5f;

    private FixedJoint2D Joint;
    private float BoxGrabTimer = 0;
    private bool BoxScript = false;
    private BoxInfo CurrentBoxScript = null;
    private Rigidbody2D MostRecentRB = null;

    // Start is called before the first frame update
    void Start()
    {
        Joint = GetComponent<FixedJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add to timers
        BoxGrabTimer += Time.deltaTime;

        if (Input.GetKey(Drop))
        {
            // Dettach box from joint
            Joint.connectedBody = null;

            // Turn off joint
            Joint.enabled = false;

            // Set BoxGrabTimer
            BoxGrabTimer = 0;

            // Set box variable
            if (BoxScript)
            {
                CurrentBoxScript.AttachedToRope = false;
            }
        }

        //Trying to make sure AttachedToRope is false when not attached, not sure how much of this works ;(
        if (Joint.connectedBody != MostRecentRB)
        {
            CurrentBoxScript.AttachedToRope = false;
        }
        else if (Joint.enabled == false && BoxScript)
        {
            CurrentBoxScript.AttachedToRope = false;
        }
    }

    // Check for collision with box
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check BoxScript exists
        var TestBoxScript = collision.gameObject.GetComponent<BoxInfo>();
        if (TestBoxScript == null)
        {
            BoxScript = false;
            return;
        }

        // Connect joint, if timer allows
        if (Joint.connectedBody == null && BoxGrabTimer > BoxGrabCooldown)
        {
            // If BoxScript exists, then save for later
            CurrentBoxScript = TestBoxScript;
            BoxScript = true;

            // Attach box to joint
            Joint.connectedBody = collision.rigidbody;
            MostRecentRB = collision.rigidbody;

            // Turn on joint
            Joint.enabled = true;

            // Set box variable
            if (CurrentBoxScript != null)
            {
                CurrentBoxScript.AttachedToRope = true;
            }
        }
    }
}
