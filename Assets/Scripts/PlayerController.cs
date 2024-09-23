using UnityEditor;
using System.Configuration;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //we will move the vehicle
        transform.Translate(0, 0, 1);
    }
}
