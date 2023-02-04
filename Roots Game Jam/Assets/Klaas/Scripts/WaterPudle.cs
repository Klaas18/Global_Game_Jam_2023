using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPudle : MonoBehaviour
{
    [Header("Water Energy To Give")]
    [Range(0,2)]public float waterAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnergyManager.energyManager.isUpdatingWaterBar = true;
            EnergyManager.energyManager.waterEnergyAmount = waterAmount;
            waterAmount = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnergyManager.energyManager.isUpdatingWaterBar = false;
        }
    }
   
}
