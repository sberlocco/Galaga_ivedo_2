using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager2 : MonoBehaviour
{
    void Update()
    {
        // Se non ci sono più nemici nella scena
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)

            SceneManager.LoadScene("Level3");
    }
}
