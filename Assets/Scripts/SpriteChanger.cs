using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
        //name of our variable
        private SpriteRenderer theRenderer;//Variable for our renderer
        //Variable for our color
        public Color spriteColor;

    // Use this for the initialization
    void Start()
     {   
        //Load the SpriteRenderer component from the same object the SpriteRenderer component is on
        theRenderer = gameObject.GetComponent<SpriteRenderer>();
    
        //Change the color of our alpha to 1
        spriteColor.a = 1.0f;
        //Change the spritecolor to a color picker as long as the sprite renderer has been set
        if (theRenderer != null){
        
            theRenderer.color = spriteColor;
        }
        //Change the "color" of our SpriteRenderer for game like green or red
        //theRenderer.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
