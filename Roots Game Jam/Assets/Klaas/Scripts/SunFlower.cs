using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
   [Range(0,1)] public float sunEnergyAmount;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && EnergyManager.energyManager.currentSunEnergy < 1)
        {
            EnergyManager.energyManager.currentSunEnergy += sunEnergyAmount * Time.deltaTime;
        }
    }
}
