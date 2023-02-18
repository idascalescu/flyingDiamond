using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private float speedX;

    public GameObject player;

    Vector3 translation = new Vector3(0.0f, 1.2f, -9.0f);
    private Vector3 offset;
    
    [SerializeField]
    float smooth = 1.0f;
    [SerializeField]
    float tiltAngle = 9.0f;

    void Start()
    {
        offset = new Vector3(0.0f, 3.5f, -9.0f);
    }

    void Update()
    {
        SpinView(); 
    }

    public void SpinView()
    {
        transform.position = player.transform.position + offset;
        if (player.transform.position.x > 1)
        {
            float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;// Smoothly tilts a transform towards a target rotation.
            Quaternion target = Quaternion.Euler(0.0f, tiltAroundY, 0.0f);// Rotate the cube by converting the angles into a quaternion.
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);// Dampen towards the target rotation.
        }
        /*if (player.transform.position.y < 476.959f)
        {
            float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle * 1.2f;// Smoothly tilts a transform towards a target rotation.
            Quaternion target = Quaternion.Euler(tiltAroundX, 0.0f, 0.0f);// Rotate the cube by converting the angles into a quaternion.
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);// Dampen towards the target rotation.
        }
        if(player.transform.position.y < 475.0f)
        {
            transform.Translate(translation / -2 * (Time.deltaTime), relativeTo: Space.World);
        }*/
    }
}
