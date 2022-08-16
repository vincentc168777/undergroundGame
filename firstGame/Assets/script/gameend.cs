using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameend : MonoBehaviour
{
    [SerializeField] GameObject endText;

    // Start is called before the first frame update
    void Start()
    {
        endText.SetActive(false);
        Invoke("displayText", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("menu");
        }
    }

    void displayText()
    {
        endText.SetActive(true);
    }
}
