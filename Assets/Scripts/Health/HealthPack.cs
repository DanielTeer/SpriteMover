using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public float healAmount = 10f; // Amount healed

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Try to find a Health component
        Health health = collision.gameObject.GetComponent<Health>();

        // If no Health component exists, stop safely
        if (health == null)
        {
            return;
        }

        if (health.Heal(healAmount))//If the bool in health comes back true with needing health then use health pack
        {
            Destroy(gameObject);
        }
    }
}
