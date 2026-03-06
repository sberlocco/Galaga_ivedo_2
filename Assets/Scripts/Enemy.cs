using UnityEngine;
public class Enemy : MonoBehaviour
{
    public int health = 1;

    [Header("Audio")]
    public AudioClip deathSound;

    [Header("Effetti")]
    public GameObject explosionPrefab;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        if (deathSound != null)
            AudioSource.PlayClipAtPoint(deathSound, transform.position);

        if (explosionPrefab != null)
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}