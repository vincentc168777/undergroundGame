using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodcreak : MonoBehaviour
{
    [SerializeField] AudioSource wood;
    
    private void OnCollisionEnter(Collision collision)
    {
            wood.Play();     
    }
}
