using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;//sets prefab for small asteroid
    public GameObject mediumAsteroidPrefab;//sets prefab for medium asteroid
    public GameObject largeAsteroidPrefab;//sets prefab for Large asteroid

    public float spawnRate = 3f;// rate of spawning in asteroids// difficulty scale

    public int totalAsteroidsToSpawn = 10;// total asteroids to spawn

    private int asteroidsSpawned = 0;// helps with reset

    public Boundary boundary;// outdated boundary no use now

    public GameObject ufoPrefab;// sets the ufo in a instance for use

    [Range(0, 100)]//random number
    public float ufoChance = 30f;// chance of ufo spawn
    [Range(0, 100)]//random number
    public float largeAsteroidChance = 20f;//chance of Large asteroid
    [Header("Asteroid Scales")]// nice header for a label
    public Vector3 smallAsteroidScale = new Vector3(1f, 1f, 1f);// default scale of asteroids
    public Vector3 mediumAsteroidScale = new Vector3(1.3f, 1.3f, 1f);//default scale for mediums
    public Vector3 largeAsteroidScale = new Vector3(1.7f, 1.7f, 1f);//default of large


    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 1f, spawnRate);//looks at spawn rate and instantiates over and over till complete
    }

    void SpawnAsteroid()//what happens when void start is called
    {
        if (asteroidsSpawned >= totalAsteroidsToSpawn)// keeps the total under number set in inspector
        {
            CancelInvoke(nameof(SpawnAsteroid));// stop if limit reached
            return;// nothing
        }

        Vector2 pos = new Vector2(Random.Range(boundary.minX, boundary.maxX), Random.Range(boundary.minY, boundary.maxY));// maintains wrap

        float roll = Random.Range(0f, 100f);// random number in chance to spawn ufo or large asteroid used later

        GameObject obj;// calls the game objects obj to type object less

        // UFO FIRST
        if (roll < ufoChance)//if roll is less than ufo chance
        {
            obj = Instantiate(ufoPrefab, pos, Quaternion.identity);// pop a ufo
        }
        else
        {
            float asteroidRoll = Random.Range(0f, 100f);// gives a random number for asteroid

            // LARGE
            if (asteroidRoll < largeAsteroidChance)
            {
                obj = Instantiate(largeAsteroidPrefab, pos, Quaternion.identity);
                obj.transform.localScale = largeAsteroidScale;
            }
            // MEDIUM
            else if (asteroidRoll < 60f) // designer range fot later use
            {
                obj = Instantiate(mediumAsteroidPrefab, pos, Quaternion.identity);
                obj.transform.localScale = mediumAsteroidScale;
            }
            // NORMAL
            else
            {
                obj = Instantiate(asteroidPrefab, pos, Quaternion.identity);
                obj.transform.localScale = smallAsteroidScale;
            }
        }

        asteroidsSpawned++;// add to asteroid
        GameManager.Instance.RegisterObstacle();//logs into game manager
    }




    public void ResetSpawner()// needed tor new game to reset spawner
    {
        asteroidsSpawned = 0;// starts over at zero

        CancelInvoke(nameof(SpawnAsteroid));//cancels the spawning

        InvokeRepeating(nameof(SpawnAsteroid), 1f, spawnRate);//reset the spawner
    }
}