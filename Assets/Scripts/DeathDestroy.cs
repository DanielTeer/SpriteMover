using UnityEngine;

// Child class that destroys the GameObject when it dies
public class DeathDestroy : Death
{
    // Overrides the abstract Die function from Death
    public override void Die()
    {
        // Remove the GameObject from the scene
        Destroy(gameObject);
    }
}
