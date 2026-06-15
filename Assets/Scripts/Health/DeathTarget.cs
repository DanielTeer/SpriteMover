using UnityEngine;

public class DeathTarget : DeathDestroy// DeathTarget inherits from Death destroy
{
    public override void Die()//Die function
    {
        AudioSource.PlayClipAtPoint(GameManager.Instance.explosionSound, transform.position, GameManager.Instance.sfxVolume);// calls audio to play on death

        // asteroid split hook
        AsteroidSplit splitter = GetComponent<AsteroidSplit>();//Gets the asteroid split .cs
        if (splitter != null)//checks if splitter is on the object
        {
            splitter.Split();//If it is it splits
        }

        GameManager.Instance.RemoveObstacle();//registers the split asteroids to game manager
        GameManager.Instance.AddScore(100);//100 points if destroyed or die function is called

        base.Die();// calls die to destroy game object.
    }
}
