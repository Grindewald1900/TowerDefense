using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " : " + other.gameObject.name);
        if (other.gameObject.name.Contains("Goblin(Clone)"))
        {
            InitConfig.SharedInstance.passCount += 1;
        }
    }
}
