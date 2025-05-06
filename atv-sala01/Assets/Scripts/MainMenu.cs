using UnityEngine;
using static GameManager;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
       GameManager.Instance.LoadGameGui();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("jogo encerrado");
    }
}
