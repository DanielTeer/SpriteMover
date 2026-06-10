using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;

    public float spawnRate = 3f;

    public int totalAsteroidsToSpawn = 10;

    private int asteroidsSpawned = 0;

    public Boundary boundary;

    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 1f, spawnRate);
    }

    void SpawnAsteroid()
    {
        if (asteroidsSpawned >= totalAsteroidsToSpawn)
        {
            CancelInvoke(nameof(SpawnAsteroid));
            return;
        }

        Vector2 pos = new Vector2(
        Random.Range(boundary.minX, boundary.maxX),
        Random.Range(boundary.minY, boundary.maxY));//spawn radius

        Instantiate(asteroidPrefab, pos, Quaternion.identity);

        asteroidsSpawned++;

        GameManager.Instance.RegisterObstacle();
    }
}