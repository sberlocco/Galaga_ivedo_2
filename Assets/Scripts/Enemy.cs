using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public GameObject enemyBullet;
    public float fireRate = 2f;
    private float nextFire;

    void Update()
    {
        // Movimento lento verso il basso (puoi cambiare logica per pattern più complessi)
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Sparo automatico
        if (Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (enemyBullet != null)
        {
            GameObject b = Instantiate(enemyBullet, transform.position, Quaternion.identity);
            Bullet bulletScript = b.GetComponent<Bullet>();
            if (bulletScript != null)
                bulletScript.targetTag = "Player"; // cambia il target
        }
    }
}