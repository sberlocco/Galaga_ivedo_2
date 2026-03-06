using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject enemyBullet;
    public float fireRate = 2f;

    private float nextFire;

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

        GameObject bullet = Instantiate(
            enemyBullet,
            transform.position,
            Quaternion.identity
        );

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        // SPARA VERSO IL PLAYER (cioè lungo -Z)
        bulletScript.Init(transform.forward, true);
    }
}