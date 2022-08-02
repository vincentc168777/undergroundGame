using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemypathing : MonoBehaviour
{
    [SerializeField] NavMeshAgent enemyNav;
    [SerializeField] GameObject player;
    [SerializeField] Transform goLocation;
    private float dist;
    private bool canChoose;
    private int randNum;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>();
        canChoose = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        monsterPatrol();
    }

    private void monsterPatrol()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < 4)
        {
            canChoose = false;
            enemyNav.SetDestination(player.transform.position);
            enemyNav.stoppingDistance = 1.5f;
        }
        else
        {
            while (canChoose)
            {
                aNum();
                canChoose = false;
            }
            chooseLocation();
        }
        
    }

    private void aNum()
    {      
        randNum = Random.Range(0, goLocation.childCount);      
    } 

    private void chooseLocation()
    {
        enemyNav.stoppingDistance = 0f;
        Vector3 patrolPos = goLocation.GetChild(randNum).position;
        enemyNav.SetDestination(patrolPos);
        if (transform.position.x == patrolPos.x && transform.position.z == patrolPos.z)
        {
            canChoose = true;
        }
    }
}
