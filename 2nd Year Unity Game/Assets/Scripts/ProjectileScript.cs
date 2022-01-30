using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float initialForce = 5000;
    public float speed = 100;

    RaycastHit hit;
    Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {

        


        GameObject camera = GameObject.Find("Main Camera");

        hit = camera.GetComponent<RayCast>().hit;

        direction = (hit.point - transform.position).normalized;

        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Debug.Log("projectile Collided");
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
