using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    
    void OnTriggerEnter(Collider other)
    {
        car1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        car2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        car3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        car4.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    
    }
}
