using UnityEngine;

public class DeathTarget : DeathDestroy
{
    void Start()
    {
        GameManager.Instance.RegisterObstacle();
    }

    public override void Die()
    {
        GameManager.Instance.RemoveObstacle();
        GameManager.Instance.AddScore(100);

        base.Die();
    }
}
