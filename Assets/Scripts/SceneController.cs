using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GoToPreferences()
    {
        SceneManager.LoadScene("Preferences");
    }
}