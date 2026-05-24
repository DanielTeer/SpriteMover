using UnityEngine;

public class PawnStarShip : PawnSuperClass//Takes the additional code in my superclass that holds the Monobehavior
{
    private Transform tf;//Takes the transform component and names it tf

    public float moveSpeed = 5f;//Adjustable speed

    public float rotationSpeed = 180f;//Adjustable rotation speed

    public float turboMultiplier = 2f; //TURBO SPEED!!!

    public float minX = -5f;
    public float maxX = 5f;
    public float minY = -5f;
    public float maxY = 5f;

    public void RandomTeleport()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        tf.position = new Vector3(randomX, randomY, 0f);
    }

    void Start()
    {
        tf = GetComponent<Transform>();// Store the Transform component inside tf
    }

    public void Move(Vector3 direction)//Local to the sprite movement
    {
        float speed = moveSpeed;//Names the variable to speed

            if (Input.GetKey(KeyCode.LeftShift))//TURBO Buttons
            {
                speed *= turboMultiplier;
            }
            if (Input.GetKey(KeyCode.RightShift))//other TURBO button
            {
                speed *= turboMultiplier;
            }

        tf.position += tf.TransformDirection(direction) * speed * Time.deltaTime;
    }

    public void MoveWorld(Vector3 direction)//Relative to the screen or origin space movement
    {
        float speed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))//World TURBO Buttons
        {
            speed *= turboMultiplier;
        }
        if (Input.GetKey(KeyCode.RightShift))//other World TURBO button
        {
            speed *= turboMultiplier;
        }

        tf.position += direction * speed * Time.deltaTime;
    }

    public void Rotate(float direction)//Rotation line
    {
        tf.Rotate(Vector3.forward * direction * rotationSpeed * Time.deltaTime);
    }
    public void TeleportWorld(Vector3 direction)//Teleport using movement speed
    {
        tf.position += direction * moveSpeed;
    }
}
