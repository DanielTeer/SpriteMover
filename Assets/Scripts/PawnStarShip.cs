using UnityEngine;

public class PawnStarShip : PawnSuperClass//Takes the additional code in my superclass that holds the Monobehavior
{
    private Transform tf;//Takes the transform component and names it tf

    public float moveSpeed = 5f;//Adjustable speed

    public float rotationSpeed = 180f;//Adjustable rotation speed

    void Start()
    {
        tf = GetComponent<Transform>();// Store the Transform component inside tf
    }

    public void Move(Vector3 direction)//Local to the sprite movement
    {
        tf.position += tf.TransformDirection(direction) * moveSpeed * Time.deltaTime;
    }

    public void MoveWorld(Vector3 direction)//Relative to the screen or origin space movement
    {
        tf.position += direction * moveSpeed * Time.deltaTime;
    }

    public void Rotate(float direction)//Rotation line
    {
        tf.Rotate(Vector3.forward * direction * rotationSpeed * Time.deltaTime);
    }
}
