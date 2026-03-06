using UnityEngine;

public class EnemyFormation : MonoBehaviour
{

    void Update()
    {
        float offset = Mathf.Sin(Time.time * 2f) * 5f;

        transform.position = new Vector3(
            offset,
            transform.position.y,
            transform.position.z
        );
    }

    [Header("Prefab")]
    public GameObject enemyPrefab;

    [Header("Grid Settings")]
    public int rows = 4;          // profondità (asse Z)
    public int columns = 6;       // larghezza (asse X)

    public float spacingX = 2f;
    public float spacingZ = 2f;

    [Header("Position Settings")]
    public float distanceFromPlayer = 20f;  // quanto davanti al player

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnFormation();
    }

    void SpawnFormation()
    {
        if (player == null)
        {
            Debug.LogError("Player non trovato!");
            return;
        }

        // Punto centrale davanti al player
        Vector3 formationCenter =
            player.position +
            player.forward * distanceFromPlayer;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calcolo offset
                float offsetX = col * spacingX - ((columns - 1) * spacingX / 2f);
                float offsetZ = -row * spacingZ;

                Vector3 spawnPos = formationCenter +
                                   new Vector3(offsetX, 0, offsetZ);

                // Ruotiamo il nemico verso il player (Z-)
                Quaternion rotation = Quaternion.LookRotation(-player.forward);

                Instantiate(enemyPrefab, spawnPos, rotation, transform);
            }
        }
    }
}