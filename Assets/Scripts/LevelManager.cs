using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    void Update()
    {
        // Se il player è morto → Game Over
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            SceneManager.LoadScene("GameOver");
            return;
        }

        // Se non ci sono più nemici nella scena
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
                SceneManager.LoadScene("Level2");
        }
    }
}