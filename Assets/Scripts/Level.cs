using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("Game Over"));
    }

    private IEnumerator WaitAndLoad(string sceneName)
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
