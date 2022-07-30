using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blowup : MonoBehaviour
{
    [SerializeField] Camera blowieCam;
    [SerializeField] int theRange;
    [SerializeField] LayerMask blowupLayer;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.childCount >= 5)
            canBlow();
        
    }

    private void canBlow()
    {
        Ray blow = new Ray(blowieCam.transform.position, blowieCam.transform.forward);
        if (Physics.Raycast(blow, theRange, blowupLayer) && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("game end");
        }
    }
}
