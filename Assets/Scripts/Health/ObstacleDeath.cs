using UnityEngine;

public class ObstacleDeath : Death
{
    public override void Die()
    {
        GameManager.Instance.RemoveObstacle();
        Destroy(gameObject);
    }
}
