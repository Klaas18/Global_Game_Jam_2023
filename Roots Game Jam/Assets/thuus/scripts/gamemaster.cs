using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemaster : MonoBehaviour
{
    public int maxpuzzlepoints;
    public int puzzle2Points;
    public Animator animate;

    void Start()
    {
        
    }

    
    void Update()
    {

        if (puzzle2Points >= maxpuzzlepoints)
        {
            
            animate.SetBool("bush",true);
            StartCoroutine(Waitbeforedestroy());
            
            Debug.Log("destroyed");


        }
    }
    IEnumerator Waitbeforedestroy()
    {
        yield return new WaitForSeconds(1.1f);
        Destroy(gameObject);
    }

}
