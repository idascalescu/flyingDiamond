using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnERot : MonoBehaviour
{ 
    void Update()
    {
        if(Input.GetKey("e"))
        {
            transform.Rotate(0.0f, 0.0f, 5.0f);
        }
    }
}
