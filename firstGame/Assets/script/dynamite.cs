using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamite : MonoBehaviour
{
    [SerializeField] Camera dynaiteCam;
    [SerializeField] int pickRange;
    [SerializeField] LayerMask dynamiteLayer;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pickUp();
    }

    private void pickUp()
    {
        Ray dynamiteRay = new Ray(dynaiteCam.transform.position, dynaiteCam.transform.forward);
        if(Physics.Raycast(dynamiteRay, pickRange, dynamiteLayer) && Input.GetKeyDown(KeyCode.E))
        {
            transform.parent = player.transform;
            gameObject.SetActive(false);
        }
    }
}
