using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 100f; 
    public float rotationSpeed = 10f; 
    public float brakePower = 100f;
    public float stability = 0.1f; 

    public WheelCollider frontLeftWheel; 
    public WheelCollider frontRightWheel; 
    public WheelCollider backLeftWheel; 
    public WheelCollider backRightWheel; 

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical"); 
        
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);
        
        frontLeftWheel.motorTorque = vertical * speed;
        frontRightWheel.motorTorque = vertical * speed;
        backLeftWheel.motorTorque = vertical * speed;
        backRightWheel.motorTorque = vertical * speed;
        
        if (Input.GetKey(KeyCode.Space))
        {
            frontLeftWheel.brakeTorque = brakePower;
            frontRightWheel.brakeTorque = brakePower;
            backLeftWheel.brakeTorque = brakePower;
            backRightWheel.brakeTorque = brakePower;
        }
        else
        {
            frontLeftWheel.brakeTorque = 0;
            frontRightWheel.brakeTorque = 0;
            backLeftWheel.brakeTorque = 0;
            backRightWheel.brakeTorque = 0;
        }

       
        _rigidbody.AddForce(-transform.up * (_rigidbody.velocity.magnitude * stability));
    }
}

