using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject theObject;
    private bool passed = false;
    
    void OnTriggerExit(Collider other)
    {
        if(!passed){
            theObject.transform.position = teleportTarget.transform.position;
            passed = true;
        }
    }
}
