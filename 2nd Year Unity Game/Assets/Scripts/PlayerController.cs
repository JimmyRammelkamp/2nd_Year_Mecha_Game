using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float maxSpeed = 10f;
    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;
    [SerializeField]
    Transform playerInputSpace = default;
    Vector3 velocity, desiredVelocity;

    public float ammo = 100;
    public float health = 100;

    Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.z = Input.GetAxis("Vertical");
        playerInput.y = 0;
        if (Input.GetKey(KeyCode.LeftShift)) { playerInput.y = 1; }
        if (Input.GetKey(KeyCode.LeftControl)) { playerInput.y = -1; }
        playerInput = Vector3.ClampMagnitude(playerInput, 1f);
        if (playerInputSpace)
        {
            Vector3 forward = playerInputSpace.forward;
           // forward.y = 0f;
            forward.Normalize();
            Vector3 right = playerInputSpace.right;
           // right.y = 0f;
            right.Normalize();
            Vector3 up = playerInputSpace.up;
            //up.y = 0f;
            up.Normalize();
            desiredVelocity =
                (forward * playerInput.z + right * playerInput.x /*+ up * playerInput.y*/) /** maxSpeed*/;
            desiredVelocity = new Vector3(desiredVelocity.x, playerInput.y, desiredVelocity.z) * maxSpeed;
        }
        else
        {
            desiredVelocity =
                new Vector3(playerInput.x, playerInput.y, playerInput.z) * maxSpeed;
        }

        transform.rotation = Quaternion.Euler(0,Camera.main.transform.eulerAngles.y,0);

        velocity = body.velocity;
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        velocity.x =
             Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.y =
             Mathf.MoveTowards(velocity.y, desiredVelocity.y, maxSpeedChange);
        velocity.z =
            Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        body.velocity = velocity;
        Vector3 displacement = velocity * Time.deltaTime;
        transform.localPosition += displacement;

        if (health < 0) health = 0;
        if (health <= 0) Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            ammo += 10;
            Destroy(collision.gameObject);
        }
        
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyProjectile"))
        {
            health -= 10;

        }
    }

}
