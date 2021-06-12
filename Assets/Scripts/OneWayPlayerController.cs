//------------------------------------------------------------------------------
//
// File Name:	OneWayPlayerController.cs
// Author(s):	Gavin Cooper
//
// Project:		GMTK Game Jam 2021
//
// Description: A script that handle movement in one direction at a time
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlayerController : MonoBehaviour
{
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public float Speed = 2;
    public Vector2 MaxSpeed = new Vector2(10, 10);

    private enum Directions { Left, Right, Up, Down, None};

    private int ButtonOrderSize = 4;
    private Directions[] ButtonOrder = { Directions.None, Directions.None, Directions.None, Directions.None };
    private Vector2 DirectionVector;

    private Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //set dirrection memory
        if (Input.GetKeyDown(Left))
        {
            ButtonOrder[3] = ButtonOrder[2];
            ButtonOrder[2] = ButtonOrder[1];
            ButtonOrder[1] = ButtonOrder[0];
            ButtonOrder[0] = Directions.Left;
        }
        else if (Input.GetKeyUp(Left))
        {
            RemoveButtonMemory(Directions.Left);
        }
        if (Input.GetKeyDown(Right))
        {
            ButtonOrder[3] = ButtonOrder[2];
            ButtonOrder[2] = ButtonOrder[1];
            ButtonOrder[1] = ButtonOrder[0];
            ButtonOrder[0] = Directions.Right;
        }
        else if (Input.GetKeyUp(Right))
        {
            RemoveButtonMemory(Directions.Right);
        }
        if (Input.GetKeyDown(Up))
        {
            ButtonOrder[3] = ButtonOrder[2];
            ButtonOrder[2] = ButtonOrder[1];
            ButtonOrder[1] = ButtonOrder[0];
            ButtonOrder[0] = Directions.Up;
        }
        else if (Input.GetKeyUp(Up))
        {
            RemoveButtonMemory(Directions.Up);
        }
        if (Input.GetKeyDown(Down))
        {
            ButtonOrder[3] = ButtonOrder[2];
            ButtonOrder[2] = ButtonOrder[1];
            ButtonOrder[1] = ButtonOrder[0];
            ButtonOrder[0] = Directions.Down;
        }
        else if (Input.GetKeyUp(Down))
        {
            RemoveButtonMemory(Directions.Down);
        }

        // Set dirrection
        switch (ButtonOrder[0])
        {
            case Directions.Left:
                DirectionVector = new Vector2(-1, 0);
                break;

            case Directions.Right:
                DirectionVector = new Vector2(1, 0);
                break;

            case Directions.Up:
                DirectionVector = new Vector2(0, 1);
                break;

            case Directions.Down:
                DirectionVector = new Vector2(0, -1);
                break;

            case Directions.None:
                DirectionVector = new Vector2(0, 0);
                break;
        }

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

    // Function to move a dirrection from the buttom memory
    private void RemoveButtonMemory(Directions Target)
    {
        // Find the direction 
        int Index = -1;

        for (int i = 0; i < ButtonOrderSize; i++)
        {
            if (ButtonOrder[i] == Target)
            {
                Index = i;
                break;
            }
        }

        // If direction doesnt exit, return
        if (Index == -1)
        {
            return;
        }

        // Move the list down
        for (int i = Index; i < ButtonOrderSize; i++)
        {
            if (i + 1 == ButtonOrderSize)
            {
                ButtonOrder[i] = Directions.None;
            }
            else
            {
                ButtonOrder[i] = ButtonOrder[i + 1];
            }
        }

    }
}
