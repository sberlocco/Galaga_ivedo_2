using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static bool isTransitioning = false; // static: condiviso tra tutte le istanze

    void OnEnable()
    {
        isTransitioning = false; // reset quando la scena si carica
    }

    void Update()
    {
        if (isTransitioning) return;

        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            isTransitioning = true;
            SceneManager.LoadScene("GameOver");
            return;
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            isTransitioning = true;
            if (SceneManager.GetActiveScene().name == "Level1")
                SceneManager.LoadScene("Level2");
            else if (SceneManager.GetActiveScene().name == "Level2")
                SceneManager.LoadScene("Level3");
        }
    }
}