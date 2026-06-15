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
    public GameObject VictoryScreenStateObject;

    public TMP_Text scoreText;//HUD variables names
    public TMP_Text livesText;

    public int score = 0;//HUD initial numbers
    public int lives = 3;

    public Image playerHealthImage;

    public GameObject playerPrefab;//Respawn Variables for player and a spawn point
    public Transform spawnPoint;

    public CameraFollow cameraFollow;//sets the camera in inspector

    public float minX;//warp boundary references-14,14,-9,9 for now
    public float maxX;
    public float minY;
    public float maxY;

    [Header("Sound Effects")]// cool header
    public AudioClip shootSound;// sounds to use for the inspector
    public AudioClip damageSound;
    public AudioClip explosionSound;
    public AudioClip asteroidHum;

    [Header("Volume Settings")]// header title
    [Range(0f, 1f)]// zero to one only
    public float masterVolume = 1f;// default loudness

    [Range(0f, 1f)]// zero to one only
    public float musicVolume = 1f;// default loudness

    [Range(0f, 1f)]// zero to one only
    public float sfxVolume = 1f;// default loudness

    public AsteroidSpawner asteroidSpawner;//Calls the asteroid spawner reset.


    void Awake()//starts on awake anyway
    {
        if (Instance != null)//checks if there is already a game manager
        {
            Destroy(gameObject); // prevents duplicate GameManagers
            return;//no error 
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
        obstacleCount++; // adds obstacle when spawned to game manager
    }

    public void RemoveObstacle()
    {
        obstacleCount--;// when destroyed we remove the instance

        if (obstacleCount <= 0)// if no more available
        {
            WinGame();// calls win function
        }
    }

    public void WinGame()//win function
    {
        ActivateVictoryScreen(); // win condition output
    }

    public void LoseGame()//Lose screen
    {
        ActivateGameOverScreen(); // lose condition output
    }

    public void PlayerDied()// duh duh duh dead.
    {
        LoseGame(); // calls lose method when player dies
    }
    public void AddScore(int amount)//Values to be added to score
    {
        score += amount;//points to gain inspector has value
        UpdateHUD();// show me the points
    }

    public void LoseLife()//Value to subtract to lives
    {
        lives--;// if i lose a life subtract it

        UpdateHUD();// show me the new number

        if (lives <= 0)// if i have no more lives
        {
            LoseGame();// calls game over screen
        }
        else//or
        {
            RespawnPlayer();//Calls Respawn player
        }
    }
    public void RespawnPlayer()// what happens in a respawn
    {
        GameObject newPlayer = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);// new clone of starship

        Health health = newPlayer.GetComponent<Health>();//get the health

        health.healthImage = playerHealthImage;// check image

        cameraFollow.target = newPlayer.transform;// camera goes to new location

        health.ResetHealth();//full health
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

    public void ActivateGameplay()// gameplay function
    {
        score = 0;//start at the initial settings on reset
        lives = 3;
        obstacleCount = 0;

        UpdateHUD();// resets hud

        DeactivateAllStates();//ensures no other game state is on
        GameplayStateObject.SetActive(true);// sets the current gameplay is on

        // destroy enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");// no enemie stay on reset
        foreach (GameObject enemy in enemies)// checks enemy tag
        {
            Destroy(enemy);//destroy the tagges enemies
        }

        // destroy old player safely
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)// if player is alive
        {
            Destroy(player);// remove old player before new game
        }
        
        SpawnNewPlayer();//spawn new player

        asteroidSpawner.ResetSpawner();//reset the asteroid spawner
    }

    private void SpawnNewPlayer()//Calls what it means to spawn as a function
    {
        RespawnPlayer();// respawn the player
    }

    public void ActivateGameOverScreen()// death screen name
    {
        DeactivateAllStates();// calls the Deactivate all states funtion
        GameOverScreenStateObject.SetActive(true);// enables the Game Over screen in this function
    }

    public void ActivateVictoryScreen()// death screen name
    {
        DeactivateAllStates();// calls the Deactivate all states funtion
        VictoryScreenStateObject.SetActive(true);// enables the Game Over screen in this function
    }
    public void UpdateHUD()//This will change the HUD initial values
    {
        if (scoreText != null)//checks if the score text is there
        {
            scoreText.text = "Score: " + score;// sets score
        }

        if (livesText != null)//checks lives
        {
            livesText.text = "Lives: " + lives;//sets lives
        }
    }
    public Vector3 WrapPosition(Vector3 pos)// the wrap boundary
    {
        if (pos.x > maxX) pos.x = minX;//set in inpector
        if (pos.x < minX) pos.x = maxX;

        if (pos.y > maxY) pos.y = minY;
        if (pos.y < minY) pos.y = maxY;

        return pos;
    }
    public void DeactivateAllStates()// this is the function that we are calling to deactivate the game states
    {
        TitleScreenStateObject.SetActive(false);// this will diactivate the gamestates 
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
        VictoryScreenStateObject.SetActive(false);
    }
}