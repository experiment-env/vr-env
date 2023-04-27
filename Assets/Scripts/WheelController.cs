using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider rearRight;
    [SerializeField] private WheelCollider rearLeft;


    public float acceleration = 15f;
    public float breakForce = 0f;

    public float speedOnKmh = 0.0f; 

    public void speedometer(){
         float wheelRadius = 0.035f;
         float wheelRpm = frontLeft.rpm; 
         float circumFerence = wheelRadius*2;
 
         circumFerence = 2.0f * 3.14f * wheelRadius; // Finding circumFerence 2 Pi R
         speedOnKmh = (circumFerence * wheelRpm)*60 / 1000; // finding kmh
    }



    private void FixedUpdate()
    {

        frontRight.motorTorque = acceleration;
        frontLeft.motorTorque = acceleration;

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
        speedometer();

    }
}
