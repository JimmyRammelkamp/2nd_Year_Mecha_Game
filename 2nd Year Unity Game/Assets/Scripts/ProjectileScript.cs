using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float initialForce = 5000;
    public float speed = 100;

    public AudioClip hitSound;

    GameObject camera;
    RaycastHit hit;
    Ray ray;

    Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {

        ray = GameObject.Find("Main Camera").GetComponent<RayCast>().ray;

        camera = GameObject.Find("Main Camera");


        hit = camera.GetComponent<RayCast>().hit;

        Debug.Log("hitpoint" + hit.point);

        if (hit.point == new Vector3(0,0,0))
            direction = (ray.GetPoint(1000) - transform.position).normalized;

        else direction = (hit.point - transform.position).normalized;

        

        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision collision)
    {

        Destroy(gameObject);
        Debug.Log("projectile Collided");

        if(collision.transform.CompareTag("Enemy"))
        {
            GetComponent<AudioSource>().clip = hitSound;
            GetComponent<AudioSource>().Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}
