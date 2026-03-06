using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.3f;
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
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("Bullet Prefab o FirePoint NON assegnato!");
            return;
        }


        if (shootSound != null)
            audioSource.PlayOneShot(shootSound);
        {
            if (bulletPrefab == null || firePoint == null)
            {
                Debug.LogError("Bullet Prefab o FirePoint NON assegnato!");
                return;
            }

            GameObject bullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.identity
            );

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Init(Vector3.forward, false);
        }
    }
}