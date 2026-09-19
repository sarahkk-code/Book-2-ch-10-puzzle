using UnityEngine;
using TMPro;

public class ExitManager : MonoBehaviour
{
    public TMP_Text playerNameText;

    void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        playerNameText.text = "Player: " + playerName;
    }
}