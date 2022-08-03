using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lightmanage : MonoBehaviour
{
    [SerializeField] GameObject monster;
    [SerializeField] GameObject lanterns;
    [SerializeField] Light playerLight;
    private Light lanternLight;
    public static bool genOn;
    
    
    // Start is called before the first frame update
    void Start()
    {
        monster.SetActive(false);
        playerLight.enabled = false;
        genOn = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        lanternManage();
        
    }

    private void lanternManage()
    {
        if (!genOn)
        {
            for(int i = 0; i < lanterns.transform.childCount; i++)
            {
                lanternLight = lanterns.transform.GetChild(i).GetComponentInChildren<Light>();
                lanternLight.enabled = false;
            }
            
            playerLight.enabled = true;
            //monster spawns
            monster.SetActive(true);
        }
        else
        {
            
            monster.SetActive(false);
            playerLight.enabled = false;
            for (int x = 0; x < lanterns.transform.childCount; x++)
            {
                lanternLight = lanterns.transform.GetChild(x).GetComponentInChildren<Light>();
                lanternLight.enabled = true;
            }
        }
    }

    public static void lightsOff()
    {
        genOn = false;
    }

    public static void turnOn()
    {
        genOn = true;
    }

}
