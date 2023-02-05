using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Vector2 point;
    public Quaternion rotation;

    public void SetPoint(Vector2 vec, Quaternion rot)
    {
        point = vec;
        rotation = rot;
    }
}
