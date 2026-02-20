using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f;
    public string targetTag = "Enemy"; // cambiare in "Player" per proiettili nemici

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.up * speed; // usa Vector3.down se è proiettile nemico
        Destroy(gameObject, 5f); // auto-distruzione
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}