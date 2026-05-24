using UnityEngine;

public class PlayerController : Controller
{
    
    public PawnStarShip pawn;//Names the star ship script reference as pawn
    void Update()
    {
        //The transforms that move the ship in the facing direction
        if (Input.GetKey(KeyCode.A))// Rotate Left
        {
            pawn.Rotate(1);
        }

        if (Input.GetKey(KeyCode.D))// Rotate Right
        {
            pawn.Rotate(-1);
        }

        if (Input.GetKey(KeyCode.W))// Move Forward
        {
            pawn.Move(Vector3.up);
        }

        if (Input.GetKey(KeyCode.S))// Move Backward
        {
            pawn.Move(Vector3.down);
        }

        // Moves relative to the screen
        if (Input.GetKey(KeyCode.UpArrow))//Move up
        {
            pawn.MoveWorld(Vector3.up);
        }

        // Move Down on screen
        if (Input.GetKey(KeyCode.DownArrow))//Move Down
        {
            pawn.MoveWorld(Vector3.down);
        }

        if (Input.GetKey(KeyCode.LeftArrow))// Move Left
        {
            pawn.MoveWorld(Vector3.left);
        }

        if (Input.GetKey(KeyCode.RightArrow))// Move Right
        {
            pawn.MoveWorld(Vector3.right);
        }
    }
}
