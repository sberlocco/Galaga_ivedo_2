using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 5f;

    private Vector3 moveDirection;
    private bool isEnemyBullet;

    public void Init(Vector3 direction, bool enemyBullet)
    {
        moveDirection = direction.normalized;
        isEnemyBullet = enemyBullet;

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isEnemyBullet && other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeDamage(1);

            Destroy(gameObject);
        }

        if (isEnemyBullet && other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}