using UnityEngine;

public class DeathTarget : DeathDestroy
{
    void Start()
    {
        GameManager.Instance.RegisterObstacle();
    }

    public override void Die()
    {
        AudioSource.PlayClipAtPoint(
            GameManager.Instance.explosionSound,
            transform.position,
            GameManager.Instance.sfxVolume
        );

        GameManager.Instance.RemoveObstacle();
        GameManager.Instance.AddScore(100);

        base.Die();
    }
}
