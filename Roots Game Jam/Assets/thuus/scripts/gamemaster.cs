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

    IEnumerator Order()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    void Update()
    {

        if (puzzle2Points >= maxpuzzlepoints)
        {
            
            animate.SetBool("bush",true);
                Order();
            Debug.Log("destroyed");


        }
    }

}
