using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;

    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    private void OncollisionEnter(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platforms"))
        {
            Player.GetComponent<PlayerController>().isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision2D collider)
    {
        if (collider.collider.CompareTag("Platforms"))
        {
            Player.GetComponent<PlayerController>().isGrounded = false;
        }
    }
}
