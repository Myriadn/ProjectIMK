using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void RageQuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
