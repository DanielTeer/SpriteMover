using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Maximum health that designers can change in the Inspector
    public float maxHealth = 100f;

    // Tracks the current health during gameplay
    private float currentHealth;

    // Reference to a Death component if one exists
    private Death deathComponent;

    private bool isDead = false;

    public Image healthImage;//Image name for reference

    private AudioSource audioSource;//audio

    void Start()
    {
        // Start at full health
        currentHealth = maxHealth;

        // Try to find a Death component on this GameObject
        deathComponent = GetComponent<Death>();

        if (healthImage != null)
            UpdateUI();

        audioSource = GetComponent<AudioSource>();//audio
    }

    // Function that allows other objects to deal damage
    public void TakeDamage(float damage)
    {
        if (isDead) return;

        if (audioSource != null)
        {
            audioSource.PlayOneShot(GameManager.Instance.damageSound);//audio one shot on hit
        }

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateUI();//update ui

        if (currentHealth <= 0)
        {
            Debug.Log(gameObject.name + " died!");
            Die();
        }
    }
    public bool Heal(float amount)//Checks to see if We need health before using healthpack
    {
        if (isDead) return false;

        if (currentHealth >= maxHealth)
        {
            return false;// chacks if i am full health before using health pack
        }

        currentHealth += amount;//Heal amount
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);//Math to update health on heal

        UpdateUI();//updates healthbar image
        return true;//if true then complete the function, this bool true will be used in HealthPack.cs
    }
   
    void UpdateUI()
    {
        if (healthImage != null)//Checks to see if i have the healthbar image on Gameobject
        {
            healthImage.fillAmount = currentHealth / maxHealth;//Updates the health bar fill amount
        }
    }
    public void ResetHealth()
    {
        isDead = false;
        currentHealth = maxHealth;
        UpdateUI();
    }

    // Function called when health reaches zero
    public void Die()//Die function
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

