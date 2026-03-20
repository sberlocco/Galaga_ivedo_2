using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int lives = 1;
    public int score = 0;
    public Text livesText;
    public Text scoreText;

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void LoseLife()
    {
        lives--;
        UpdateUI();
        if (lives <= 0)
        {
            Debug.Log("GAME OVER");
            // Puoi aggiungere scene GameOver
        }
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }
}