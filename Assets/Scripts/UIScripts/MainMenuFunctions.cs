using UnityEngine;

public class MainMenuFunctions : MonoBehaviour
{
    
    public void ChangeScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }   
}
