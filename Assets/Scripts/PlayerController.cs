using UnityEngine;

public class PlayerController : Controller
{
   
    public PawnStarShip pawn;

    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pawn.Move(Vector3.right);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pawn.Move(Vector3.left);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            pawn.Move(Vector3.up);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            pawn.Move(Vector3.down);
        }
    }
}
