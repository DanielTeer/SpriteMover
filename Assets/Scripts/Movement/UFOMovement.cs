using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    public float speed = 2f;//speed of movement

    private Transform player;//sets the transform
    private Rigidbody2D rb;//sets the rigidbody to rb

    public Boundary boundary;// old boundary reference

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// gets the Rigidbody on reset

        if (rb == null)//if we get a rigidbody

        if (boundary == null)
            boundary = FindFirstObjectByType<Boundary>();//gets the boundary
    }

    void Update()
    {
        if (player == null)//checks if player
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");//finds the starship with the player tag
            if (p != null) player = p.transform;//tracks the P which is player
        }
    }

    void FixedUpdate()
    {
        if (player == null || rb == null) return;// if no player ir rigidbody nothing

        Vector2 direction =(player.position - transform.position).normalized;// normalized the movement
        rb.linearVelocity = direction * speed;// linear nor just velocity
    }
    void LateUpdate()
    {
        transform.position =GameManager.Instance.WrapPosition(transform.position);// keeps inside warp
    }
}
