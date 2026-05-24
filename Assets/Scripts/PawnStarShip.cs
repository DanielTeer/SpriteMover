using UnityEngine;

public class PawnStarShip : PawnSuperClass
{
    public float moveSpeed = 5f;
    public void Move(Vector3 direction)
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
