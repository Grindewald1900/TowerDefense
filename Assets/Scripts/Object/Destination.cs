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
            PlayerStats.Instance.TakeDamage(1);
            other.gameObject.SetActive(false);
            if (InitConfig.SharedInstance.passCount == 10)
            {
                // Lose Game
                ObjectGenerater.SharedInstance.ResetGame();
                GoblinManager.SharedInstance.isGaming = false;
                ScreenTextManager.SharedInstance.MeshProHint.text = "You Lose!";
            }
        }
    }
}
