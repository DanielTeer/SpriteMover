using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.RegisterObstacle();
    }
}
