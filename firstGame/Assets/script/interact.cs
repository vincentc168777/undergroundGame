using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    [SerializeField] Camera interactCam;
    [SerializeField] int range;
    [SerializeField] LayerMask interactLayer;
    private bool canInteract;



    private void Update()
    {
        playerInteract();
    }

    

    private void playerInteract()
    {
        Ray interacting = new Ray(interactCam.transform.position, interactCam.transform.forward);
        canInteract = Physics.Raycast(interacting, range, interactLayer);
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            lightmanage.turnOn();
        }
    }
}
