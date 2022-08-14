using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] string goToMenu;
    public static bool paused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                resumeGame();
            }
            else
            {
                
                pauseGame();
            }
        }
    }

    public void pauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void resumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(goToMenu);
        paused = false;
    }

    
    
}
