using UnityEngine;

public class DeathTarget : DeathDestroy
{
    void Start()
    {
        GameManager.Instance.RegisterTarget();
    }

    public override void Die()
    {
        GameManager.Instance.RemoveTarget();

        base.Die(); // calls Destroy(gameObject)
    }
}
