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

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pawn.TeleportWorld(Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pawn.TeleportWorld(Vector3.down);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pawn.TeleportWorld(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pawn.TeleportWorld(Vector3.right);
        }
    }
}
