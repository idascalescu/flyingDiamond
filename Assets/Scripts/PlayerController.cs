using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float forceMagnitude;
    [SerializeField]
    float steeringSpeed;
    [SerializeField]
    float reverseSpeed;
    [SerializeField]
    float jumpPower;
    [SerializeField]
    float flyingSpeed;
    [SerializeField]
    float rotFlyingSpeed;
    [SerializeField]
    float _gravity;
    [SerializeField]
    float bounceForce;
    [SerializeField]
    float ascendingSpeed;

    Rigidbody rb;

    [HideInInspector]
    public bool isGrounded;

    [HideInInspector]
    public bool isFlying;
    [HideInInspector]
    public bool playerCanDoDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
        playerCanDoDamage = false;
        isFlying = false;
    }

    private void Update()
    {
        Jump();
        Flying();
    }

    private void FixedUpdate()
    {
        rb.AddForce(0.0f, -_gravity, 0.0f, ForceMode.Force);

        if (Input.GetKey("w"))
        {
            rb.AddForce(0.0f, 0.0f, forceMagnitude += Time.deltaTime, ForceMode.Force);
        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(0.0f, 0.0f, -forceMagnitude, ForceMode.Force);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(steeringSpeed / Time.deltaTime, 0.0f, 0.0f);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-steeringSpeed / Time.deltaTime, 0.0f, 0.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platforms"))
        {
            isGrounded = true;
            forceMagnitude = 0.11f;
            steeringSpeed = 0.11f;
        }

        if (collision.gameObject.CompareTag("ControllDeactivator"))
        {
            forceMagnitude = 0.0f;
            steeringSpeed = 0.0f;
        }

        /*if (collision.gameObject.CompareTag("BouncingPlatform"))
        {
            rb.AddForce(0.0f, jumpPower, bounceForce, ForceMode.Impulse);
        }
*/
        if(collision.gameObject.CompareTag("SpawningField"))
        {
            rb.position = new Vector3(0.0f, 1.41f, -946.8f);
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }

        if (collision.gameObject.CompareTag("Ramp"))
        {
            rb.AddForce(new Vector3(0.0f, 0.001f, 0.0f), ForceMode.Impulse);
        }

        if(collision.gameObject.CompareTag("Enemy") && playerCanDoDamage == true)
        {
            Destroy(collision.gameObject);
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EndLevel"))
        {
            SceneManager.LoadScene("Level1");
        }
    }

    private void Jump()
    {
        if (Input.GetKey("space") && isGrounded == true)
        {
            rb.AddForce(new Vector3(0.0f, jumpPower, 0.0f), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void Flying()
    {
        Quaternion onFlyingRotation = new Quaternion(0.0f, 0.0f, rotFlyingSpeed, 0.0f);

        if(Input.GetKey("e") && isGrounded == false)
        {
            /*transform.Rotate(0.0f, 0.0f, rotFlyingSpeed);*/
            rb.AddForce(new Vector3(0.0f, ascendingSpeed, flyingSpeed), ForceMode.Force);

            transform.rotation = onFlyingRotation;
            playerCanDoDamage = true;
            isFlying = true;
        }
    }
}
 