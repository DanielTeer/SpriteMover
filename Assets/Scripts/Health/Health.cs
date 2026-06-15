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

    private bool isDead = false;// names the isDead variable

    public Image healthImage;//Image name for reference

    private AudioSource audioSource;//audio

    void Start()
    {
        // Start at full health
        currentHealth = maxHealth;

        // Try to find a Death component on this GameObject
        deathComponent = GetComponent<Death>();

        if (healthImage != null)//checks if object has a health image
            UpdateUI();// health image matches the heath percent

        audioSource = GetComponent<AudioSource>();//audio
    }

    // Function that allows other objects to deal damage
    public void TakeDamage(float damage)
    {
        if (isDead) return;// if object is dead return nothing

        if (audioSource != null)//checks audio source
        {
            audioSource.PlayOneShot(GameManager.Instance.damageSound);//audio one shot on shoot projectile
        }

        currentHealth -= damage;// looks for damage to health
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);// cant fall below zero health

        UpdateUI();//update ui

        if (currentHealth <= 0)//if health is zero
        {
            Debug.Log(gameObject.name + " died!");//lets us know what died
            Die();//then destroy game object
        }
    }
    public bool Heal(float amount)//Checks to see if We need health before using healthpack
    {
        if (isDead) return false;// cant use health if your dead

        if (currentHealth >= maxHealth)// dont use health if its full
        {
            return false;// checks if i am full health before using health pack
        }

        currentHealth += amount;//Heal amount
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);//Math to update health on heal

        UpdateUI();//updates healthbar image
        return true;//if true then complete the function, this bool true will be used in HealthPack.cs
    }
   
    void UpdateUI()// This is what happens to update the ui
    {
        if (healthImage != null)//Checks to see if i have the healthbar image on Gameobject
        {
            healthImage.fillAmount = currentHealth / maxHealth;//Updates the health bar fill amount
        }
    }
    public void ResetHealth()// this resets health on new game
    {
        isDead = false;// If isdead is false
        currentHealth = maxHealth;// reset health
        UpdateUI();//reset ui
    }

    // Function called when health reaches zero
    public void Die()//Die function
    {
        if (isDead) return;  // checks the is dead function

        isDead = true;       // Mark object as dead FIRST
        // Prevent health from becoming negative
        currentHealth = 0;

        Debug.Log(gameObject.name + " died!");// calls who died
       

        // If a Death component exists, call its Die function
        if (deathComponent != null)// checks if object can die
        {
            deathComponent.Die();//destroy it
        }
    }
}

