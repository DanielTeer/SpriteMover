using UnityEngine;

public class AsteroidSplit : MonoBehaviour//name of class 
{
    public GameObject nextAsteroidPrefab;// inspector asteroid prefab
    public int spawnCount = 2;//spawns two smaller asteroids
    public float spawnForce = 2f;// movement force on split

    private bool hasSplit = false;// calls the split function to false

    public void Split()//split function
    {
        if (hasSplit) return;//if has split is false return
        hasSplit = true;//make it true

        if (nextAsteroidPrefab == null)// make sure we set the next asteroid or no error
            return;// if no prefab return nothing

        for (int i = 0; i < spawnCount; i++)// checks each spawn count
        {
            GameObject newAsteroid = Instantiate(nextAsteroidPrefab, transform.position, Random.rotation);// orientation of smaller asteroid
            newAsteroid.transform.localScale = transform.localScale;// the new asteroids orientation

            Rigidbody2D rb = newAsteroid.GetComponent<Rigidbody2D>();// keeps the rigid body of larger asteroid

            if (rb != null)// checks to see if new asteroid has rigid body
            {
                Vector2 dir = Random.insideUnitCircle.normalized;// normalizes the vector 2
                rb.linearVelocity = dir * spawnForce;// linear velocity not velocity
            }

            GameManager.Instance.RegisterObstacle();// game manager references the new obstacle
        }
    }
}