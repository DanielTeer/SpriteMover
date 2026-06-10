using UnityEngine;

public class UIFollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
    }
}
