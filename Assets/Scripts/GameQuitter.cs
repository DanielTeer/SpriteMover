using UnityEngine;

public class GameQuitter : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("quit"))//Uses the axis to find my escape key button
        {
            Application.Quit();//Exits the application if i push it.
        }
    }
}
