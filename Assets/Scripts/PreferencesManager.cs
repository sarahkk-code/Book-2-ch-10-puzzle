using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PreferencesManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Dropdown piecesDropdown;
    public UnityEngine.UI.Slider timeSlider;

    public void StartGame()
    {
        PlayerPrefs.SetString("PlayerName", nameInput.text);
        PlayerPrefs.SetInt("PuzzlePieces", piecesDropdown.value);
        PlayerPrefs.SetFloat("GameTime", timeSlider.value);

        PlayerPrefs.Save();

        SceneManager.LoadScene("Game");
    }
}