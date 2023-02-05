using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pauseTrigger : MonoBehaviour
{
    public GameObject pause;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !pause.activeSelf)
        {
            pause.SetActive(true);
            Time.timeScale = 0f;

        }    
    }
}
