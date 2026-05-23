using UnityEngine;

public class InputChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Bang");
        }
     /*   if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("The A key is down!");
        }
            else
        {
            Debug.Log("The A key is not down!");
        }*/
    }
}
