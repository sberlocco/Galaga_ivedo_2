using System.Collections;
using UnityEngine;

public class LevelStartDelay : MonoBehaviour
{
    public float startDelay = 3f;

    void Start()
    {
        StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        Time.timeScale = 0f;   // ferma il gioco
        yield return new WaitForSecondsRealtime(startDelay);
        Time.timeScale = 1f;   // fa ripartire il gioco
    }
}