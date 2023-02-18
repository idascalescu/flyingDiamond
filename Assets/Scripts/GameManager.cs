using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player = GameObject.FindGameObjectWithTag("Player");

    void Start()
    {
        DontDestroyOnLoad(player);
    }
}
