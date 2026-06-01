using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;// Damage able to change in inspector

    void Start()
    {
        Destroy(gameObject, 2f);// Projectile dies after 2 seconds
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (health != null)// Checks for helth with no orror
        {
            health.TakeDamage(damage);// hits if its good
        }

        Destroy(gameObject);// Destroy if health is zero
    }
}
