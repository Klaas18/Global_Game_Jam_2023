using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPudle : MonoBehaviour
{
    [Range(0,1)]public float waterAmount;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && EnergyManager.energyManager.currentWaterEnergy < 1)  //Checks If The Collider Is The Player And If Water Amount is smaller then 1
        {                     
               EnergyManager.energyManager.currentWaterEnergy += waterAmount * Time.deltaTime;  //Adds The Water To The WaterManager     
        }
      
    }
}
