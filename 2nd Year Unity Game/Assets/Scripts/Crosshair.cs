using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float rotationSpeed = 100;

    float setAngle = 45;

    bool spin = false;

    RaycastHit hit;
    //Ray ray = new Ray(transform.position, transform.forward);

    // Start is called before the first frame update
    void Start()
    {
       
    }
    void Spin()
    {
        spin = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spin)
            transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        else transform.rotation = Quaternion.Euler(0, 0, 45);
        spin = false;
    }

}
