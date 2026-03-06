using UnityEngine;

public class EnemyFormationLevel2 : MonoBehaviour
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
    public int rows = 4;
    public int columns = 6;

    public float spacingX = 2f;
    public float spacingZ = 2f;

    [Header("Position Settings")]
    public float distanceFromPlayer = 20f;

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

        Vector3 formationCenter = player.position + player.forward * distanceFromPlayer;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Zigzag: sposta le colonne dispari leggermente
                float zigzagOffset = (row % 2 == 0) ? 0f : spacingX / 2f;

                float offsetX = col * spacingX - ((columns - 1) * spacingX / 2f) + zigzagOffset;
                float offsetZ = -row * spacingZ;

                Vector3 spawnPos = formationCenter + new Vector3(offsetX, 0, offsetZ);
                Quaternion rotation = Quaternion.LookRotation(-player.forward);

                Instantiate(enemyPrefab, spawnPos, rotation, transform);
            }
        }
    }
}