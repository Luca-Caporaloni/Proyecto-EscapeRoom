using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string mapSceneName= "Phsiquiatra";


    public GameObject mainMenuUI;
    public GameObject optionsMenuUI;
    public GameObject quitMenuUI;

    public Camera menuCamera;


    void Start()
    {
        menuCamera = Camera.main;
        mainMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        quitMenuUI.SetActive(false); 
        Cursor.lockState = CursorLockMode.None; // Liberar el cursor
        Cursor.visible = true; // Hacer el cursor visible   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ConfirmQuit();
        }
    }

    public void Play()
    {
        mainMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        SceneManager.LoadScene(mapSceneName);
    }

    public void Options()
    {
        mainMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);

    }

   public void Confirm()
    {
        optionsMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ConfirmQuit()
    {
        quitMenuUI.SetActive(true);
    }

    public void CancelQuit()
    {
        quitMenuUI.SetActive(false);
    }
}

