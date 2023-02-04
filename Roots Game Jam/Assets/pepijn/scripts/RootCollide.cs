using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RootCollide : MonoBehaviour
{
    public GameObject col;


    public void OnTriggerStay2D(Collider2D collision)
    {   
        col = collision.gameObject;
        Debug.Log(col.gameObject.name + " layer: "+col.layer.ToString() );
    }
}