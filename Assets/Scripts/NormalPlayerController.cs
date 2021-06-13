//------------------------------------------------------------------------------
//
// File Name:	NormalPlayerController.cs
// Author(s):	Gavin Cooper
//
// Project:		GMTK Game Jam 2021
//
// Description: A script that handle movement
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlayerController : MonoBehaviour
{
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public float Speed = 2;
    public Vector2 MaxSpeed = new Vector2(10, 10);

    private Vector2 DirectionVector;

    private Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();

        // Fix speed because I used to use update for main loop
        Speed *= 15;
    }

    // Update is called once per frame
    void Update()
    {
        // Left and right dirrections
        if (Input.GetKeyDown(Left))
        {
            DirectionVector = new Vector2(-1, DirectionVector.y);
        }
        else if (Input.GetKey(Left) && !Input.GetKey(Right))
        {
            DirectionVector = new Vector2(-1, DirectionVector.y);
        }
        else if (Input.GetKeyDown(Right))
        {
            DirectionVector = new Vector2(1, DirectionVector.y);
        }
        else if (Input.GetKey(Right) && !Input.GetKey(Left))
        {
            DirectionVector = new Vector2(1, DirectionVector.y);
        }
        else if (!Input.GetKey(Left) && !Input.GetKey(Right))
        {
            DirectionVector = new Vector2(0, DirectionVector.y);
        }

        // Up and down dirrections
        if (Input.GetKeyDown(Up))
        {
            DirectionVector = new Vector2(DirectionVector.x, 1);
        }
        else if (Input.GetKey(Up) && !Input.GetKey(Down))
        {
            DirectionVector = new Vector2(DirectionVector.x, 1);
        }
        else if (Input.GetKeyDown(Down))
        {
            DirectionVector = new Vector2(DirectionVector.x, -1);
        }
        else if (Input.GetKey(Down) && !Input.GetKey(Up))
        {
            DirectionVector = new Vector2(DirectionVector.x, -1);
        }
        else if (!Input.GetKey(Up) && !Input.GetKey(Down))
        {
            DirectionVector = new Vector2(DirectionVector.x, 0);
        }
    }

    // Update is called consistantly
    void FixedUpdate()
    {
        // Add force
        RB.AddForce(DirectionVector * Speed);

        // Fix speed if needed
        if (RB.velocity[0] >= MaxSpeed[0])
        {
            RB.velocity = new Vector2(MaxSpeed[0], RB.velocity[1]);
        }
        else if (RB.velocity[0] <= -MaxSpeed[0])
        {
            RB.velocity = new Vector2(-MaxSpeed[0], RB.velocity[1]);
        }

        if (RB.velocity[1] >= MaxSpeed[1])
        {
            RB.velocity = new Vector2(RB.velocity[0], MaxSpeed[1]);
        }
        else if (RB.velocity[1] <= -MaxSpeed[1])
        {
            RB.velocity = new Vector2(RB.velocity[0], -MaxSpeed[1]);
        }
    }
}
