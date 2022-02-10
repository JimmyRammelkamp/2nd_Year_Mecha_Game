using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 3;
    public float speed = 5;
    float health;

    Color orange = new Color(1.0f, 0.5f, 0f, 1.0f);
    public GameObject projectile;
    GameObject player;
    GameObject cone;
    bool activeCone;

    float targetX;
    float targetY;
    float targetZ;
    bool targetReached;
    bool changingPosition;
    Vector3 targetPosition;
    float targetArrivalTime;
    float waitTime;

    public float fireRate = 1f;
    public float nextFire = 1f;

    Vector3 refVelocity = Vector3.zero;

    Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        cone = transform.Find("TargetCone").gameObject;
        health = maxHealth;

        transform.rotation = Quaternion.Euler(0,0,0);

        changingPosition = true;
        targetReached = false;
        targetPosition =  GenerateTarget();
        Debug.Log(targetPosition);
    }

    void Targeted()
    {
        activeCone = true;
    }

    Vector3 GenerateTarget()
    {
        Vector3 playerPos = player.transform.position;

        targetX = Random.Range(4, 20);
        targetY = Random.Range(-3, 3);
        targetZ = Random.Range(4, 20);

        if(Random.value > 0.5)
        {
            targetX = -targetX;
        }
        if (Random.value > 0.5)
        {
            targetZ = -targetZ;
        }
        Vector3 target = new Vector3(targetX, targetY, targetZ);


        return playerPos + target;
    }
    

    // Update is called once per frame
    void Update()
    {
        Cone();
       
        
        
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            FireProjectile();
        }
       



        float smoothTime = 0.5f;

        if (targetReached == false)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref refVelocity, smoothTime, 50);
        }

        if ((transform.position - targetPosition).magnitude < .2)
        {
            targetReached = true;
           // Debug.Log("TargetReached");
            if(changingPosition == true)
            {
                targetArrivalTime = Time.time;
                changingPosition = false;
                waitTime = Random.Range(1, 3);
            }
        }

        if (targetReached == true && Time.time > targetArrivalTime + waitTime)
        {
           
            targetPosition = GenerateTarget();
            targetReached = false;
            changingPosition = true;
           
        }



        if (health <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().AddScore(10);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Projectile"))
        {
            health -= 1;
            Debug.Log("health:" + health);
        }
    }


    void FireProjectile()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }

    void Cone()
    {
        if (activeCone)
            cone.SetActive(true);
        else cone.SetActive(false);

        activeCone = false;


        if (health == maxHealth)
        {
            cone.GetComponent<Renderer>().material.SetColor("_WireColor", Color.green);
        }

        if (health < maxHealth && health >= maxHealth * 0.5)
        {
            //  Debug.Log(cone.GetComponent<Renderer>().material.shader.GetPropertyName(2));
            cone.GetComponent<Renderer>().material.SetColor("_WireColor", orange);
        }

        if (health < maxHealth * 0.5)
        {
            //  Debug.Log(cone.GetComponent<Renderer>().material.shader.GetPropertyName(2));
            cone.GetComponent<Renderer>().material.SetColor("_WireColor", Color.red);
        }
    }
}
