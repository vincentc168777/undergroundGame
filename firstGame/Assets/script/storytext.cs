using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class storytext : MonoBehaviour
{
    [SerializeField] GameObject storyText;
    [SerializeField] GameObject skipText;
    // Start is called before the first frame update
    void Start()
    {
        storyText.SetActive(false);
        skipText.SetActive(false);
        Invoke("showText", 2);
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            noText();
            Invoke("loadGame", 1);
        }
    }
    private void loadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void showText()
    {
        storyText.SetActive(true);
        skipText.SetActive(true);

    }

    private void noText()
    {
        storyText.SetActive(false);
        skipText.SetActive(false);
    }
}
