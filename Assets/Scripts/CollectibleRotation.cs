using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleRotation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0.0f, 0.3f, 0.0f);
    }
}
