using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{
    public void ClickGas()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ClickPengaturan()
    {
        SceneManager.LoadScene("");
    }
    public void ClickExit()
    {
        Application.Quit();
    }
}
