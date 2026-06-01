using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // singleton reference

    public int obstacleCount; // tracks obstacles in scene
    public int targetCount;   // tracks DeathTarget objects in scene

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); // prevents duplicate GameManagers
            return;
        }

        Instance = this; // assigns singleton instance
        DontDestroyOnLoad(gameObject); // keeps manager between scenes
    }

    public void RegisterObstacle()
    {
        obstacleCount++; // adds obstacle when spawned
    }

    public void RemoveObstacle()
    {
        obstacleCount--; // removes obstacle when destroyed

        if (obstacleCount <= 0)
        {
            Debug.Log("Victory"); // old win condition for obstacles
        }
    }

    public void RegisterTarget()
    {
        targetCount++; // adds target when spawned
    }

    public void RemoveTarget()
    {
        targetCount--; // removes target when destroyed

        if (targetCount <= 0)
        {
            WinGame(); // calls win method when all targets are gone
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
}