using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager energyManager;
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
        FillWaterBar();
        FillSunBar();
    }

    public void FillSunBar()
    {
        sunBar.fillAmount = currentSunEnergy;
        Mathf.Clamp(currentSunEnergy, 0, 1);
    }

    public void FillWaterBar()
    {
        waterBar.fillAmount = currentWaterEnergy;
        Mathf.Clamp(currentWaterEnergy, 0, 1);
    }

    public void UseWater()
    {

    }
}
