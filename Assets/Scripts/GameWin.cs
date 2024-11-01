using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PensiButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
