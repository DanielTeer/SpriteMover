using UnityEngine;

public class SpriteStretcher : MonoBehaviour
    //Create a variable for our transform
    //Create a variable for the max we can scale in one frame draw
{
    private Transform tf; // Create a variable for our transform component
    public float maxScale; // Create a variable for the max we can scale in one frame draw
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Load our transform component into our variable
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
        //Find out wich one and how far our axis stretch
        //Use that value to calculate a value betwee-100to100 of our max scale per frame
        //increase our object by that amount uniformly
    {
        // Find out how far and in which direction our axes are pressed
        float axesValue = Input.GetAxis("scale"); // This is between -1 and 1 -- a "percent"
                                                  // Use that value to calculate a value between -100% and 100% of our max scale per frame
        float scaleAmount = axesValue * maxScale;
        // Increase the scale of our object by that amount on all axes (1,1,1) * scaleAmount
        tf.localScale += Vector3.one * scaleAmount;
    }
}
