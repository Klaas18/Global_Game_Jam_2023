using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
    [Header("Sun Energy To Give")]
    [Range(0,1)] public float sunEnergyAmount;


    private void OnTriggerEnter2D(Collider2D collision)
    {  
        if (collision.CompareTag("Player"))
        {
            EnergyManager.energyManager.isUpdatingSunBar = true;
            EnergyManager.energyManager.sunEnergyAmount = sunEnergyAmount;
            sunEnergyAmount = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnergyManager.energyManager.isUpdatingSunBar = false;
        }
    }


}
