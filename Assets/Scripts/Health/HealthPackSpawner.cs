using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    public GameObject healthPackPrefab;

    public float spawnRate = 10f;

    public int maxHealthPacks = 3;

    private int currentHealthPacks = 0;

    public Boundary boundary;

    void Start()
    {
        InvokeRepeating(nameof(SpawnHealthPack), 2f, spawnRate);
    }

    void SpawnHealthPack()
    {
        if (currentHealthPacks >= maxHealthPacks)
        {
            return;
        }

        Vector2 pos = new Vector2(
        Random.Range(boundary.minX, boundary.maxX),
        Random.Range(boundary.minY, boundary.maxY));//clamp in boundary


        Instantiate(healthPackPrefab, pos, Quaternion.identity);

        currentHealthPacks++;
    }

    public void HealthPackCollected()
    {
        currentHealthPacks--;
    }
}
