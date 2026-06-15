using UnityEngine;

public class GameQuitter : MonoBehaviour

{
   
// Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("quit"))//Uses the axis to find my escape key button
        {
            Application.Quit();//Exits the application if i push it.
        }
    }
}
