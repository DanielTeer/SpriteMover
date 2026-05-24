using UnityEngine;

public class RandomMover : MonoBehaviour
{
    private Transform tf;//Stores the tf as the transform component
    private SpriteRenderer theRenderer;//references the sprite renderer
    //Changable perameters
    public float minX = -5.0f;// minimun x value
    public float maxX = 5.0f;//max x value

    public float minY = -5.0f;// min y value
    public float maxY = 5.0f;//max y value

    public Color spriteColor;//holds the color of the sprites

    void Start()
    {
        { 
            tf = GetComponent<Transform>();//stores the transform component into tf
        }

        {
             theRenderer = GetComponent<SpriteRenderer>();//stores the sprite renderer into the name theRenderer for refrence later
        }

        {
            // Make sure sprite is visible
            spriteColor.a = 1.0f;
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)//Checks for any key to be pressed every frame
        {
            
            float randomX = Random.Range(minX, maxX);//Creates random X value between the editable perameters
            float randomY = Random.Range(minY, maxY);//Created a random Y value between the editable perameters

            
            tf.position = new Vector3(randomX, randomY, 0.0f);//Moves StarShip to random location without Z

            
            spriteColor.r = Random.Range(0.0f, 1.0f);//Random red range
            spriteColor.g = Random.Range(0.0f, 1.0f);//Random Green range
            spriteColor.b = Random.Range(0.0f, 1.0f);//Random Blue range

            
            if (theRenderer != null)//Adds the color to the sprite if I remember to add object to theRenderer component with out error message
            {
                theRenderer.color = spriteColor;
            }
        }
    }
}
