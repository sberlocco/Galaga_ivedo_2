using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Update()
    {
        // Se non ci sono più nemici nella scena
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            // Carica scena successiva
            if (SceneManager.GetActiveScene().name == "Level1")
                SceneManager.LoadScene("Level2");
            else if (SceneManager.GetActiveScene().name == "Level2")
                SceneManager.LoadScene("Level3");
            else
                Debug.Log("Hai finito tutti i livelli!");
        }
    }
}