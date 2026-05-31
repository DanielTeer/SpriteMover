using UnityEngine;

public class Health : MonoBehaviour
{
    // Maximum health that designers can change in the Inspector
    public float maxHealth = 100f;

    // Tracks the current health during gameplay
    private float currentHealth;

    // Reference to a Death component if one exists
    private Death deathComponent;

    private bool isDead = false;

    void Start()
    {
        // Start at full health
        currentHealth = maxHealth;

        // Try to find a Death component on this GameObject
        deathComponent = GetComponent<Death>();
    }

    // Function that allows other objects to deal damage
    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        Debug.Log(gameObject.name + " took damage: " + damage);
        Debug.Log("Remaining Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log(gameObject.name + " died!");
            Die();
        }
    }

    // Function called when health reaches zero
    public void Die()
    {
        if (isDead) return;  

        isDead = true;       // Mark object as dead FIRST
        // Prevent health from becoming negative
        currentHealth = 0;

        Debug.Log(gameObject.name + " died!");
       

        // If a Death component exists, call its Die function
        if (deathComponent != null)
        {
            deathComponent.Die();
        }
    }
}

