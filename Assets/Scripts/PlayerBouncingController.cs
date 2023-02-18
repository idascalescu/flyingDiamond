using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBouncingController : MonoBehaviour
{
    Rigidbody rbd;

    [SerializeField]
    Transform pointG;

    /*Vector3[] PushingForces = new Vector3[5] = {new Vector3(0.3f, 0.0f, 0.2f), new Vector3(0.2f, 0.0f, 0.9f), new Vector3(0.1f, 0.0f, 0.5f), new Vector3(0.3f, 0.0f, 0.9f), new Vector3(0.6f, 0.0f, 0.9f)};*/
    Vector3 [] PushingForces = {new Vector3(0.01f, 0.0f, -0.001f), new Vector3(-0.01f, 0.0f, 0.002f), new Vector3(-0.1f, 0.0f, -0.003f), new Vector3(-0.003f, 0.0f, -0.001f), new Vector3(0.001f, 0.0f, 0.0f)};

    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        for (counter = 0; counter < 5; counter++)
        {
            rbd.AddForce(PushingForces[counter]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("IntroRspwnPoint"))
        {
            rbd.position = pointG.position;
        }
    }
}
