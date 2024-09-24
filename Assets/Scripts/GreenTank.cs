using UnityEditor;
using System.Configuration;
using System.Collections;
using UnityEngine;

public class GreenTank : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Speed variables
    public float minSpeed = 5.0f;
    public float maxSpeed = 20.0f;
    public float acceleration = 5.0f;
    public float deceleration = 5.0f;
    //Direction variables 
    public float turnSpeed = 4.0f;

    private Rigidbody rb;
    private float currentSpeed = 0.0f;
    private float targetSpeed = 0.0f;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // public void stings
    }

    // Update is called once per frame
    void Update()
    {
        //we will move the vehicle
        if (Input.GetKey(KeyCode.UpArrow))
        {
            targetSpeed = maxSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            targetSpeed = minSpeed;

        }
        else
        {
            targetSpeed = maxSpeed;

        }
        


        transform.Translate(0, 0, 1);
    }
}
