using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaterPudle : MonoBehaviour
{
    float yScale = 1;
    [Header("Resize Speed")]
    [Range(0, 2)] public float resizeSpeed;
    [Header("Water Energy To Give")]
    [Range(0, 2)] public float waterAmount;
    public bool canGiveWater = true;
    [Header("Sprite Renderer")]
    public SpriteRenderer waterSpriteRenderer;
    Color currentWaterColor;

    private void Awake()
    {
        waterSpriteRenderer = GetComponent<SpriteRenderer>();
        currentWaterColor = waterSpriteRenderer.color;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canGiveWater)
        {
            EnergyManager.energyManager.isUpdatingWaterBar = true;
            EnergyManager.energyManager.waterEnergyAmount = waterAmount;
            waterAmount = 0;

            collision.GetComponent<PlayerController>().speed = 0;
            StartCoroutine(StopPlayer(collision.GetComponent<PlayerController>()));
            canGiveWater = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            waterSpriteRenderer.color = currentWaterColor;
            currentWaterColor.a -= resizeSpeed * Time.deltaTime;          
            //yScale -= resizeSpeed *Time.deltaTime;
            //gameObject.transform.localScale = new Vector3(1, Mathf.Clamp(yScale,0,1), 1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EnergyManager.energyManager.isUpdatingWaterBar = false;
        }
    }

    IEnumerator StopPlayer(PlayerController playerController)
    {
        yield return new WaitForSeconds(1f);
        playerController.speed = 7;
    }
}
