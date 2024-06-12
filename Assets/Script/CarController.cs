using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    public enum WheelType
    {
        Front,
        Rear
    }
    [System.Serializable]
    public struct Wheel
    {
        public WheelType type;
        public WheelCollider collider;  
        public Transform transform;
    }
    [SerializeField]
    private List<Wheel> wheels =  new List<Wheel> ();

    [SerializeField] private float speed = 50f;
    [SerializeField] private float steerSpeed = 30f;
    [SerializeField] private float maxSpeedrAngle = 30f;
    [SerializeField] private Vector3 centerOfMass;

    private float _moveInput;
    private float _steerInput;

    // Start is called before the first frame update
    void Start()
    {
        var rb=GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = Input.GetAxis("Vertical");
        _steerInput = Input.GetAxis("Horizontal");
        WheelAnimation();
    }
    private void LateUpdate()
    {
        Move();
        Steer();
        BreakeControl();
    }
    private void Move()
    {
        foreach(var wheel in wheels)
        {
            wheel.collider.motorTorque = _moveInput * speed;    
        }
    }
    private void Steer()
    {
        foreach(var wheel in wheels)
        {
            if (wheel.type == WheelType.Front)
            {
                float steerAngle = _steerInput * maxSpeedrAngle * steerSpeed;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, steerAngle, 0.5f);
            }
        }
    }
    private void WheelAnimation()
    {
        foreach(var wheel in wheels)
        {
            Vector3 pos;
            Quaternion rot;
            wheel.collider.GetWorldPose(out pos, out rot);
            wheel.transform.position = pos;
            wheel.transform.rotation = rot;
        }
    }
   public void BreakeControl()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            foreach(var wheel in wheels)
            {
                wheel.collider.brakeTorque = 2000;
            }
        }
        else
        {
            foreach(var wheel in wheels)
            {
                wheel.collider.brakeTorque = 0;
            }
        }
    }
}
