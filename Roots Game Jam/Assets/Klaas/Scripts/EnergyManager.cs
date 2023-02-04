using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(EnergyManager))]
public class EnergyManager : MonoBehaviour
{
    public static EnergyManager energyManager;

    [Header("Energy Amounts")]
    public float sunEnergyAmount;
    public float waterEnergyAmount;

    [Header("Use Speed")]
    public int useSpeed;

    [Header("Bools")]
    public bool isUpdatingWaterBar = false;
    public bool isUpdatingSunBar = false;

    [Header("Water Energy")]
    [Range(0, 1)] public float currentWaterEnergy;
    public Image waterBar;

    [Header("Sun Energy")]
    [Range(0, 1)] public float currentSunEnergy;
    public Image sunBar;

    private void Awake()
    {
        energyManager = this;
    }
    public void Update()
    {

        if(isUpdatingSunBar) // When Its True it Will Absorbe The Given Sun Energy
        {
            GainSunEnergy();
        }
        if(isUpdatingWaterBar) // When Its True it Will Absorbe The Given Sun Energy
        {
            GainWaterEnergy();
        }

       if(Input.GetKey(KeyCode.H))// This If Statement Is just For Testing
        {
            UseWater();
            UseSun();
        }
        FillWaterBar();// These 2 Are Always Being Called So That The Updating For The UI Works Smoothly
        FillSunBar();//
    }

    public void FillSunBar()// Fills Up Your Sun Bar And Caps It Out if its Higher Then 1 or Lower then 0
    {
        sunBar.fillAmount = Mathf.Clamp(currentSunEnergy, 0, 1);

    }

    public void FillWaterBar() // Fills Up Your Water Bar And Caps It Out if its Higher Then 1 or Lower then 0
    {
        waterBar.fillAmount = Mathf.Clamp(currentWaterEnergy, 0, 1);

    }

    public void GainSunEnergy()// This gets used every Time You Absorbe Sun Energy and Updates Your Sun Energy
    {
        if (currentSunEnergy < 1 && sunEnergyAmount >= 0)
        {
            currentSunEnergy += sunEnergyAmount * Time.deltaTime;
            sunEnergyAmount -= Time.deltaTime;
        }
    }
    public void GainWaterEnergy()// This gets used every Time You Absorbe Water and Updates Your Water Energy
    {
        if(currentWaterEnergy < 1 && waterEnergyAmount >= 0)
        {
            currentWaterEnergy += waterEnergyAmount * Time.deltaTime;
            waterEnergyAmount -= Time.deltaTime;
        }
    }

    public void GainWaterPrecise(float i)
    {
            currentWaterEnergy = i;   
    }

    public float GetWater()
    {
        return currentWaterEnergy;
    }
    public void UseWater()  // Removes Some of your energy by the use of Time.deltatime
    {
        currentWaterEnergy -= Time.deltaTime /useSpeed;
    }
    public void UseSun()// Removes Some of your energy by the use of Time.deltatime
    {
        currentSunEnergy -= Time.deltaTime / useSpeed;
    }
}
