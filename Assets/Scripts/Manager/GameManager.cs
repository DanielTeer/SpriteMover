using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // singleton reference

    public int obstacleCount; // tracks obstacles in scene
    //public int targetCount;   // tracks DeathTarget objects in scene
    
    public GameObject TitleScreenStateObject;// These will be the individual screens that enable gameplay
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;

    public TMP_Text scoreText;//HUD variables names
    public TMP_Text livesText;

    public int score = 0;//HUD initial numbers
    public int lives = 3;

    public Image playerHealthImage;

    public GameObject playerPrefab;//Respawn Variables for player and a spawn point
    public Transform spawnPoint;

    public CameraFollow cameraFollow;

    [Header("Sound Effects")]
    public AudioClip shootSound;
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip asteroidHum;

    [Header("Volume Settings")]
    [Range(0f, 1f)]
    public float masterVolume = 1f;

    [Range(0f, 1f)]
    public float musicVolume = 1f;

    [Range(0f, 1f)]
    public float sfxVolume = 1f;


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); // prevents duplicate GameManagers
            return;
        }

        Instance = this; // assigns singleton instance
        DontDestroyOnLoad(gameObject); // keeps manager between different iterations of play
    }
    void Start()
    {
        ActivateTitleScreen();//Begins on the title screen after game manager is made
        UpdateHUD();//Updates HUD text values
    }

    public void RegisterObstacle()
    {
        obstacleCount++; // adds obstacle when spawned
    }

    public void RemoveObstacle()
    {
        obstacleCount--;

        if (obstacleCount <= 0)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        Debug.Log("You Win"); // win condition output
    }

    public void LoseGame()
    {
        Debug.Log("You Lose"); // lose condition output
    }

    public void PlayerDied()
    {
        LoseGame(); // calls lose method when player dies
    }
    public void AddScore(int amount)//Values to be added to score
    {
        score += amount;
        UpdateHUD();
    }

    public void LoseLife()//Value to subtract to lives
    {
        lives--;

        UpdateHUD();

        if (lives <= 0)
        {
            LoseGame();
        }
        else
        {
            RespawnPlayer();//Calls Respawn player
        }
    }
    public void RespawnPlayer()//creates game object once dead
    {
        GameObject newPlayer = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);//at spawn point

        Health health = newPlayer.GetComponent<Health>();

        health.healthImage = playerHealthImage; // reassign HUD reference

        cameraFollow.target = newPlayer.transform;//Camera reset to new clone

        health.ResetHealth();

    }
    public void ActivateTitleScreen()// Lables the variable to call on during start
    {
        DeactivateAllStates();// calls the Deactivate all states funtion
        TitleScreenStateObject.SetActive(true);// enables the title screen in this function
    }

    public void ActivateMainMenuScreen()// Label for main menu
    {
        DeactivateAllStates();// calls the Deactivate all states funtion
        MainMenuStateObject.SetActive(true);// enables the Main menu screen in this function
    }

    public void ActivateOptionsScreen()//Label for options
    {
        DeactivateAllStates();// calls the Deactivate all states funtion
        OptionsScreenStateObject.SetActive(true);// enables the options screen in this function
    }

    public void ActivateCreditsScreen()//credits label
    {
        DeactivateAllStates();// calls the Deactivate all states funtion
        CreditsScreenStateObject.SetActive(true);// enables the Credits screen in this function
    }

    public void ActivateGameplay()// gameplay will use on button to call this function
    {
        DeactivateAllStates();// calls the Deactivate all states funtion
        GameplayStateObject.SetActive(true);// enables the GamePlay in this function
    }

    public void ActivateGameOverScreen()// death screen name
    {
        DeactivateAllStates();// calls the Deactivate all states funtion
        GameOverScreenStateObject.SetActive(true);// enables the Game Over screen in this function
    }
    public void UpdateHUD()//This will change the HUD initial values
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }
    public void DeactivateAllStates()// this is the function that we are calling to deactivate the game states
    {
        TitleScreenStateObject.SetActive(false);// this will diactivate the gamestates 
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
    }
}