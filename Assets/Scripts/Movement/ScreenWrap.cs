using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    void Update()
    {
        Vector3 pos = transform.position;

        if (pos.x > GameManager.Instance.maxX)
            pos.x = GameManager.Instance.minX;

        if (pos.x < GameManager.Instance.minX)
            pos.x = GameManager.Instance.maxX;

        if (pos.y > GameManager.Instance.maxY)
            pos.y = GameManager.Instance.minY;

        if (pos.y < GameManager.Instance.minY)
            pos.y = GameManager.Instance.maxY;

        transform.position = pos;
    }
}
