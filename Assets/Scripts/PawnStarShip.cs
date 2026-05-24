using UnityEngine;

public class PawnStarShip : PawnSuperClass
{
    private Transform tf;//reference the transform component
    public float moveSpeed = 5f;//sets the movement speed in an adjustable speed
    public float rotationSpeed = 180f;//sets the rotation in an adjustable speed
    
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = GetComponent<Transform>();//grabs the Transform from the object and uses tf as the storage box label
    }
    public void Move(Vector3 direction)
    {
        tf.position += tf.TransformDirection(direction) * moveSpeed * Time.deltaTime;
    }

    public void Rotate(float direction)
    {
        tf.Rotate(Vector3.forward * direction * rotationSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
