using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    [Header("Audio")]
    public AudioClip deathSound;
    private AudioSource audioSource;
    [Header("Effetti")]
    public GameObject explosionPrefab;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("Player morto!");

        if (deathSound != null)
            AudioSource.PlayClipAtPoint(deathSound, transform.position); 

        if (explosionPrefab != null)                                    
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
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