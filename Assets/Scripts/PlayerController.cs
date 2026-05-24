using UnityEngine;

public class PlayerController : Controller
{
   
    public PawnStarShip pawn;

    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pawn.Rotate(1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pawn.Rotate(-1);
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
