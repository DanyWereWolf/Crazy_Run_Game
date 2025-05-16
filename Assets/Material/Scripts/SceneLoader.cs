using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void Start()
    {
       
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void Repeat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void NextLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex + 1);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        Application.Quit();
    }
}