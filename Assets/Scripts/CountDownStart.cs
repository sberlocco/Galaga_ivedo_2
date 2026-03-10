using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownStart : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        Time.timeScale = 0f;

        countdownText.text = "3";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "2";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "1";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.text = "";

        Time.timeScale = 1f;
    }
}