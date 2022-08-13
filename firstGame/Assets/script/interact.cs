using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    [SerializeField] Camera interactCam;
    [SerializeField] int range;
    [SerializeField] LayerMask interactLayer;
    [SerializeField] GameObject player;
    [SerializeField] GameObject textPrompt;
    [SerializeField] GameObject pickupText;
    [SerializeField] GameObject playerLight;

    private bool canInteract;
    public int dynamiteCount = 0;

    private void Start()
    {
        playerLight.SetActive(false);
        textPrompt.SetActive(false);
        pickupText.SetActive(false);
    }


    private void Update()
    {
        playerInteract();
    }

    

    private void playerInteract()
    {
        Ray interacting = new Ray(interactCam.transform.position, interactCam.transform.forward);
        canInteract = Physics.Raycast(interacting, out RaycastHit hitInfo, range, interactLayer);
        if (canInteract)
        {
            pickupText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (hitInfo.transform.gameObject.name == "generator")
                {
                    lightmanage.turnOn();
                }
                else if (hitInfo.transform.gameObject.name == "dynamite")
                {
                    hitInfo.transform.gameObject.SetActive(false);
                    dynamiteCount++;
                    if (dynamiteCount == 1)
                    {
                        Invoke("canTurnLightOff", 3);
                        Invoke("appearText", 4);
                        Invoke("lighterOn", 5);
                        Invoke("noText", 8);
                    }
                    else if (dynamiteCount == 2)
                    {
                        Invoke("canTurnLightOff", 6);
                        Invoke("lighterOn", 7);
                    }
                    else if (dynamiteCount == 3)
                    {
                        Invoke("canTurnLightOff", 2);
                        Invoke("lighterOn", 3);
                    }
                }
                else if (hitInfo.transform.gameObject.name == "gamedoneplane")
                {
                    if (dynamiteCount >= 3)
                        Debug.Log("Gameend");
                }
            }
            
            
        }
        else
        {
            pickupText.SetActive(false);
        }
    }

    private void canTurnLightOff()
    {
        lightmanage.lightsOff();
    }

    private void appearText()
    {
        textPrompt.SetActive(true);

    }

    private void noText()
    {
        textPrompt.SetActive(false);
    }

    private void lighterOn()
    {
        playerLight.SetActive(true);
    }
}
