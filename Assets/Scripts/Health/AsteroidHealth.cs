using UnityEngine;

public class AsteroidHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public int scoreValue = 100;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.Instance.AddScore(scoreValue);
        GameManager.Instance.RemoveObstacle();

        Destroy(gameObject);
    }
}
