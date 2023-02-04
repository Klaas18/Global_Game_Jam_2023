using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemaster : MonoBehaviour
{
    public int maxpuzzlepoints;
    public int puzzle2Points;
    void Start()
    {
        
    }

    void Update()
    {

        if (puzzle2Points == maxpuzzlepoints)
        {
            Destroy(gameObject);
            Debug.Log("destroyed");
        }
    }
}
