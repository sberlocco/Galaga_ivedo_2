using UnityEngine;

public class FormationManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int rows = 4;
    public int cols = 6;
    public float spacing = 1.5f;

    void Start()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Vector3 pos = new Vector3(
                    x * spacing - cols / 2f,
                    4 - y * spacing,
                    0
                );
                Instantiate(enemyPrefab, pos, Quaternion.identity);
            }
        }
    }
}