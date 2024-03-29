﻿//------------------------------------------------------------------------------
//
// File Name:    TurnPlayerController.cs
// Author(s):    Dominic Salmeiri
//
// Project:        GMTK Game Jam 2021
//
// Description: The drone player controller for handling input and player movement
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayerController : MonoBehaviour
{
    public float thrust = 1;
    public float spin_speed = 1;

    public Vector2 max_speed = new Vector2(10, 10);
    public float max_angle = 45;
    public bool enforce_max = true;

    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;


    private Rigidbody2D rb;
    private int Direction;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        if (Input.GetKeyDown(Left))
        {
            Direction = -1;
        }
        else if (Input.GetKey(Left) && !Input.GetKey(Right))
        {
            Direction = -1;
        }
        else if (Input.GetKeyDown(Right))
        {
            Direction = 1;
        }
        else if (Input.GetKey(Right) && !Input.GetKey(Left))
        {
            Direction = 1;
        }
        else if (!Input.GetKey(Left) && !Input.GetKey(Right))
        {
            Direction = 0;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce((Input.GetAxisRaw("Vertical") * thrust) * transform.up);
        //rb.rotation += Input.GetAxisRaw("Horizontal") * -spin_speed;
        rb.rotation += Direction * -spin_speed;
        
        if (enforce_max) {

            if (rb.velocity[0] >= max_speed[0]) {
                rb.velocity = new Vector2 (max_speed[0], rb.velocity[1]);
            } else if (rb.velocity[0] <= -max_speed[0]) {
                rb.velocity = new Vector2 (-max_speed[0], rb.velocity[1]);
            }

            if (rb.velocity[1] >= max_speed[1]) {
                rb.velocity = new Vector2 (rb.velocity[0], max_speed[1]);
            } else if (rb.velocity[1] <= -max_speed[1]) {
                rb.velocity = new Vector2 (rb.velocity[0], -max_speed[1]);
            }

            if (rb.rotation >= max_angle) {
                rb.rotation = max_angle;
            } else if (rb.rotation <= -max_angle) {
                rb.rotation = -max_angle;
            }

        }
    }
}
