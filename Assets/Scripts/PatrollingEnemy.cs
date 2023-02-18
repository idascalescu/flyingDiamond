using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    [SerializeField]
    Transform pointA;
    [SerializeField]
    Transform pointB;
  
    [SerializeField]
    float speed;

    int counter;

    private Vector3 forceVector;
    private Vector3 forceVectorMirrored;

    void Start()
    {
        counter = 0;

        forceVector = Vector3.Normalize(pointB.position - pointA.position) * speed;
        forceVectorMirrored = new Vector3(-2.0f * forceVector.x, forceVector.y, -2.0f * forceVector.z);
    }
 
    void Update()
    {
        float delta = Mathf.Cos(counter * speed) * 0.5f + 0.5f;
        transform.position = pointA.position * (1 - delta) + pointB.position * delta;

        counter++;
    }
}
