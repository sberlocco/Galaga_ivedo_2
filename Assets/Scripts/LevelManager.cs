using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private bool isTransitioning = false;

    void Start()
    {
        isTransitioning = false;
    }

    void Update()
    {
        if (isTransitioning) return;

        Debug.Log("Player count: " + GameObject.FindGameObjectsWithTag("Player").Length);
        Debug.Log("Enemy count: " + GameObject.FindGameObjectsWithTag("Enemy").Length);

        if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            isTransitioning = true;

            Debug.Log("Carico GameOver...");
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
            else if (SceneManager.GetActiveScene().name == "Level3")
                SceneManager.LoadScene("Victory");
        }
    }
}