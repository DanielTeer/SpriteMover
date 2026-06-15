using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    // Amount of damage dealt on collision
    public float damageAmount = 10f;// but were using instant kill now

    // Inspector checkbox for instant death
    public bool instantKill = false;// default is damage but we are setting true for class

    private void OnCollisionEnter2D(Collision2D collision)// If the collider detects another collider function
    {
        // ONLY affect the player
        if (!collision.gameObject.CompareTag("Player"))//Tags player for the collision prevents enemies from killing each other
        {
            return;//return nothing
        }

        Health health = collision.gameObject.GetComponent<Health>();//Adds the health of 100 to start of code

        if (health == null)// if no health
        {
            return;// nothing returns
        }

        if (instantKill)//if we check insta kill
        {
            health.Die();// collider kills the player game object
        }
        else//or if not checked
        {
            health.TakeDamage(damageAmount);// we can still damage
        }
    }
} 