using UnityEngine;

public class EnemyFormationLevel3_Triangle : MonoBehaviour
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

    [Header("Triangle Settings")]
    public int rows = 4;          // numero di righe del triangolo
    public float spacingX = 2f;   // distanza tra nemici orizzontale
    public float spacingZ = 2f;   // distanza tra righe (asse Z)

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
            int enemiesInRow = row + 1;  // numero nemici nella riga corrente
            float rowWidth = (enemiesInRow - 1) * spacingX;

            for (int col = 0; col < enemiesInRow; col++)
            {
                // centriamo i nemici rispetto al centro della formazione
                float offsetX = col * spacingX - rowWidth / 2f;
                float offsetZ = -row * spacingZ;

                Vector3 spawnPos = formationCenter + new Vector3(offsetX, 0, offsetZ);
                Quaternion rotation = Quaternion.LookRotation(-player.forward);

                Instantiate(enemyPrefab, spawnPos, rotation, transform);

                // aggiungi eventuale script sparo se mancante
                // se EnemyShooter già sul prefab, non serve
            }
        }
    }
}