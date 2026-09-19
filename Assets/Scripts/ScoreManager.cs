using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject saveScoreButton;

    private int currentScore;
    private int highScore;

    void Start()
    {
        currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        scoreText.text = "Your Score: " + currentScore +
                         "\nHighest Score: " + highScore;

        if (currentScore > highScore)
        {
            saveScoreButton.SetActive(true);
        }
        else
        {
            saveScoreButton.SetActive(false);
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("HighScore", currentScore);
        PlayerPrefs.Save();

        highScore = currentScore;

        scoreText.text = "Your Score: " + currentScore +
                         "\nHighest Score: " + highScore;

        saveScoreButton.SetActive(false);
    }
}