using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Transform tf;//transform variable
    public float turnSpeed;//adjustable turn speed
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = GetComponent<Transform>();//putad the transform in the variable
    }

    // Update is called once per frame
    void Update()
    {
        tf.Rotate(0, 0, turnSpeed);
    }
}
