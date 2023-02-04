using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SunFlower : MonoBehaviour
{
    [Header("Sun Energy To Give")]
    [Range(0,1)] public float sunEnergyAmount;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.CompareTag("Player"))
        //  {
        if (collision.CompareTag("Root"))
        {
            EnergyManager.energyManager.isUpdatingSunBar = true;
            EnergyManager.energyManager.sunEnergyAmount = sunEnergyAmount;
            sunEnergyAmount = 0;
            
            StartCoroutine(Wait());
        }
       // }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {   
        if (collision.CompareTag("Player"))
        {
            EnergyManager.energyManager.isUpdatingSunBar = false;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        print("Done Waiting");
        EnergyManager.energyManager.isUpdatingSunBar = false;
    }
}
