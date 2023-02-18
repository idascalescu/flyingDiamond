using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    [SerializeField]
    float rotSpeed;

    void Update()
    {
        transform.Rotate(0.0f, rotSpeed, 0.0f);
    }
}
