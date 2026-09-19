using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;

    private float timeRemaining;

    void Start()
    {
        timeRemaining = PlayerPrefs.GetFloat("GameTime", 60f);
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                UpdateTimerDisplay();

                PlayerPrefs.SetInt("CurrentScore", 0);
                PlayerPrefs.Save();

                SceneManager.LoadScene("Exit");
                return;
            }

            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
    }

    public void StopGame()
    {
        int score = Mathf.CeilToInt(timeRemaining);

        PlayerPrefs.SetInt("CurrentScore", score);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Exit");
    }
}