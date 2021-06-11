//------------------------------------------------------------------------------
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

    // Start is called before the first frame update
    void Start()
    {
        Joint = GetComponent<FixedJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add to BoxGrabTimer
        BoxGrabTimer += Time.deltaTime;

        if (Input.GetKeyDown(Drop))
        {
            // Dettach box from joint
            Joint.connectedBody = null;

            // Turn off joint
            Joint.enabled = false;

            // Set BoxGrabTimer
            BoxGrabTimer = 0;
        }
    }

    // Check for collision with box
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            if (Joint.connectedBody == null && BoxGrabTimer > BoxGrabCooldown)
            {
                // Attach box to joint
                Joint.connectedBody = collision.rigidbody;

                // Turn on joint
                Joint.enabled = true;
            }
        }
    }
}
