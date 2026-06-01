using UnityEngine;

public class ShooterBullet : Shooter
{
    public GameObject projectilePrefab;// prefab of bullet names projectile
    public Transform firePoint;// firepoint object reference in game
    public float bulletSpeed = 10f;// bullet speed
    public AudioSource audioSource; // reference to sound player

    public AudioClip shootSound; // sound effect for shooting

    public override void Shoot()
    {
        // play sound when firing
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);// repeatable shoot sound
        }
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);// instanced bullet

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();// bullet colision reference
        rb.linearVelocity = firePoint.up * bulletSpeed;// goes where starship is pointed
    }
}
