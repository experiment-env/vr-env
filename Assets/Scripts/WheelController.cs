using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider rearRight;
    [SerializeField] private WheelCollider rearLeft;

    private float acceleration = 300f;
    private float breakForce = 0f;
    public float maxSpeed = 15f;

    public float speed = 0.0f; 

    private void FixedUpdate()
    {
        speed = GetComponent<Rigidbody>().velocity.sqrMagnitude;
        if(speed < maxSpeed){
            frontRight.motorTorque = acceleration;
            frontLeft.motorTorque = acceleration;
        } else {
            frontRight.motorTorque = 0f;
            frontLeft.motorTorque = 0f;
        }

        frontRight.brakeTorque = breakForce;
        frontLeft.brakeTorque = breakForce;


    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
