using UnityEngine;

// Abstract parent class for all death behaviors
public abstract class Death : MonoBehaviour
{
    // Every child class must create its own Die function
    public abstract void Die();
}
