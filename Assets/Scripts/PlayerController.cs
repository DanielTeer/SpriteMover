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

        if (Input.GetKeyDown(KeyCode.UpArrow))//Teleport up
        {
            pawn.TeleportWorld(Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))//Teleport down
        {
            pawn.TeleportWorld(Vector3.down);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))//Teleport left
        {
            pawn.TeleportWorld(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))//Teleport right
        {
            pawn.TeleportWorld(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.T))//RandomTeleport key
        {
            pawn.RandomTeleport();
        }
    }
}
