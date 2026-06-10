using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 1f, 0);

    void Start()
    {
        if (target == null)
        {
            target = transform.root; // automatically finds asteroid
        }
    }

    void Update()
    {
        if (target == null) return;

        transform.position = target.position + offset;
        transform.rotation = Camera.main.transform.rotation;
    }
}
