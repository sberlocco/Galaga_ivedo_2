using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Player HP: " + health);

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Player morto!");
        Destroy(gameObject); // oppure trigger Game Over
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("EnemyBullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}