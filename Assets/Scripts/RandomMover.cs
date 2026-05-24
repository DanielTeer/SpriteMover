using UnityEngine;

public class RandomMover : MonoBehaviour
{
    private Transform tf;
    private SpriteRenderer theRenderer;

    public Color spriteColor;

    void Start()
    {
        // Access Transform component
        tf = GetComponent<Transform>();

        // Access SpriteRenderer component
        theRenderer = GetComponent<SpriteRenderer>();

        // Make sure sprite is visible
        spriteColor.a = 1.0f;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            // Random position
            float randomX = Random.Range(-5.0f, 5.0f);
            float randomY = Random.Range(-5.0f, 5.0f);

            tf.position = new Vector3(randomX, randomY, 0.0f);

            // Random color
            spriteColor.r = Random.Range(0.0f, 1.0f);
            spriteColor.g = Random.Range(0.0f, 1.0f);
            spriteColor.b = Random.Range(0.0f, 1.0f);

            // Apply color if renderer exists
            if (theRenderer != null)
            {
                theRenderer.color = spriteColor;
            }
        }
    }
}
