//------------------------------------------------------------------------------
//
// File Name:    PlayerController.cs
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

public class PlayerController : MonoBehaviour
{
    public float horizontal_torque = 1;
    public float vertical_force = 1;

    public Vector2 max_speed = new Vector2(10, 10);
    public float max_angle = 45;
    public bool enforce_max = true;

    private Rigidbody2D rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.AddForce((Input.GetAxisRaw("Vertical") * vertical_force) * transform.up);
        rb.AddTorque(Input.GetAxisRaw("Horizontal") * -horizontal_torque);

        
        if (enforce_max) {
            /*if (rb.velocity[0] >= max_speed[0]) {
                rb.velocity = new Vector2 (max_speed[0], rb.velocity[1]);
            } else if (rb.velocity[0] <= -max_speed[0]) {
                rb.velocity = new Vector2 (-max_speed[0], rb.velocity[1]);
            }

            if (rb.velocity[1] >= max_speed[1]) {
                rb.velocity = new Vector2 (rb.velocity[0], max_speed[1]);
            } else if (rb.velocity[1] <= -max_speed[1]) {
                rb.velocity = new Vector2 (rb.velocity[0], -max_speed[1]);
            }*/

            if (rb.rotation >= max_angle) {
                rb.rotation = max_angle;
            } else if (rb.rotation <= -max_angle) {
                rb.rotation = -max_angle;
            }
        }
    }
}
