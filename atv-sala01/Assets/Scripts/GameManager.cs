using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) //s ninguém criou o singleton ainda, o código chama uma função para criar ele
            {
                SetupInstance();
            }
            return instance;
        }
    }

    public object LoadScene { get; set; }

    private void Awake() //quando o singleton nasce
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); //se ainda não tem o singleton, ele cria e não deixa ele ser destruído em novas cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static void SetupInstance() 
    {
        instance = FindObjectOfType<GameManager>();
        if (instance == null)
        {
            GameObject gameObj = new GameObject(); //Cria um novo GameObject
            gameObj.name = "Singleton"; //Dá o nome "Singleton" pra ele
            instance = gameObj.AddComponent<GameManager>(); //Coloca esse script nele
            DontDestroyOnLoad(gameObj); //E protege esse objeto pra não sumir quando você troca de fase.
        }
    }
    
    private IEnumerator LoadSplashScene() //esperar o tempo certo entre cada passo
    {
        // Carrega a cena Splash de forma aditiva (ela será sobreposta na cena atual)
        SceneManager.LoadScene("Splash", LoadSceneMode.Additive);

        // Espera 2 segundos para exibir a imagem
        yield return new WaitForSeconds(2f);

        // Carrega a cena MainMenu
        SceneManager.LoadScene("MainMenu");

        // Remove a cena Splash
        SceneManager.UnloadSceneAsync("Splash");
    }

    public void LoadScene1(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
