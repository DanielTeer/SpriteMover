using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    private Transform tf; // A variable to hold our Transform component
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Transform Component
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move up every frame draw by adding 1 to the y of our position
        tf.position = tf.position + (Vector3.up * 0.5f);
    }
}
