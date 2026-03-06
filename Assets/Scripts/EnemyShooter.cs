using UnityEngine;
public class EnemyShooter : MonoBehaviour
{
    public GameObject enemyBullet;
    public float fireRate = 2f;
    private float nextFire;

    [Header("Audio")]
    public AudioClip shootSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (enemyBullet == null) return;

        if (shootSound != null && audioSource != null)
            audioSource.PlayOneShot(shootSound);

        GameObject bullet = Instantiate(
            enemyBullet,
            transform.position,
            Quaternion.identity
        );
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Init(transform.forward, true);
    }
}