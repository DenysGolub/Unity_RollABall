using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Restart");

    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("ToMain");
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
