using UnityEngine;
using System.Collections;

// Makes objects float up & down
public class FloatingScript : MonoBehaviour
{
    // User Inputs
    [SerializeField]
    float amplitude = 0.5f;
    [SerializeField]
    float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector2();
    Vector3 tempPos = new Vector2();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
    // Refference : http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/
}