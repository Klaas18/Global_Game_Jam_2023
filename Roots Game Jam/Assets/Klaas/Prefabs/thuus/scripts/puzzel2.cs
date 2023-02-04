using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzel2 : MonoBehaviour
{
    public gamemaster bos;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Root")
        {
            bos.puzzle2Points++;
        }
        
}
    
}
