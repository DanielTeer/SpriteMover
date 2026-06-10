using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public float speed = 3f;
    public Boundary boundary;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity =
            Random.insideUnitCircle.normalized * speed;

        // FIND boundary in scene
        if (boundary == null)
        {
            boundary = FindFirstObjectByType<Boundary>();
        }
    }

    void FixedUpdate()
    {
        if (boundary == null) return;

        Vector3 pos = transform.position;

        if (pos.x < boundary.minX || pos.x > boundary.maxX ||
            pos.y < boundary.minY || pos.y > boundary.maxY)
        {
            Destroy(gameObject);
        }
    }
}