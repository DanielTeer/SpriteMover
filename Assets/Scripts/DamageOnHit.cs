using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    // Amount of damage dealt on collision
    public float damageAmount = 10f;

    // Inspector checkbox for instant death
    public bool instantKill = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Try to find a Health component on the object we hit
        Health health = collision.gameObject.GetComponent<Health>();

        // If no Health component exists, stop safely
        if (health == null)
        {
            return;
        }

        // If Instant Kill is checked
        if (instantKill)
        {
            health.Die();
        }
        else
        {
            // Otherwise deal normal damage
            health.TakeDamage(damageAmount);
        }
    }
} 