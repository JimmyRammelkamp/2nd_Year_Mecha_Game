using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFireScript : MonoBehaviour
{
    public GameObject camera;
    public Transform projectileprefab;

    public float fireRate = 0.3f;
    float nextFire = 0.0f;

    float ammo;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        ammo = this.GetComponentInParent<PlayerController>().ammo;
        if ( (Input.GetButton("Fire1") && ammo > 0 && Time.time > nextFire) || (Input.GetButtonDown("Fire1") && ammo > 0) )
        {
            nextFire = Time.time + fireRate; 
            Instantiate(projectileprefab, transform.position, transform.rotation);
            this.GetComponentInParent<PlayerController>().ammo -= 1;
        }
    }
}
