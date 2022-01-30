using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{

    public GameObject crosshair;

    public float raydistance = 1000;

    LineRenderer line;

    public RaycastHit hit;

    public Ray ray;

    public float raylength = 1000;

    // Start is called before the first frame update
    void Start()
    {

        line = GetComponent<LineRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
       
        ray = Camera.main.ScreenPointToRay(crosshair.transform.position);

        

        if (Physics.Raycast(ray, out hit))
        {
            line.SetPosition(0, ray.origin);
            line.SetPosition(1, hit.point);

            if (hit.transform.CompareTag("Enemy"))
            {
                //Debug.Log("Targeting enemy");
                hit.transform.gameObject.SendMessage("Targeted",SendMessageOptions.DontRequireReceiver);

                crosshair.SendMessage("Spin",SendMessageOptions.DontRequireReceiver);
            }
           
        }
        
    }
}
