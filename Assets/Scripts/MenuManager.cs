using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Scene da caricare")]
    public string firstLevelScene = "Level1"; // Nome della prima scena del gioco

    // Chiamato dal pulsante Start Game
    public void StartGame()
    {
        SceneManager.LoadScene(firstLevelScene);
    }

    // Chiamato dal pulsante Exit Game
    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // ferma play mode in editor
        #else
        Application.Quit(); // chiude build
        #endif
    }
}