using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    [SerializeField] Camera interactCam;
    [SerializeField] int range;
    [SerializeField] LayerMask interactLayer;
    [SerializeField] GameObject player;
    private bool canInteract;
    public int dynamiteCount = 0;



    private void Update()
    {
        playerInteract();
    }

    

    private void playerInteract()
    {
        Ray interacting = new Ray(interactCam.transform.position, interactCam.transform.forward);
        canInteract = Physics.Raycast(interacting, out RaycastHit hitInfo, range, interactLayer);
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            if(hitInfo.transform.gameObject.name == "generator")
            {
                lightmanage.turnOn();
            }        
            else if(hitInfo.transform.gameObject.name == "dynamite")
            {
                hitInfo.transform.gameObject.SetActive(false);
                dynamiteCount++;
                lightmanage.lightsOff();
            }
            else if(hitInfo.transform.gameObject.name == "cavein")
            {
                if (dynamiteCount >= 3)
                    Debug.Log("Gameend");
            }
            
        }
    }

    
}
