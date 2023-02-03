using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    public LineRenderer lr;

    List<Vector2> points;

    void SetPoint(Vector2 point)
    {
        points.Add(point);
        lr.positionCount = points.Count;
        lr.SetPosition(points.Count - 1,point);
    }

    public void UpdateLine(Vector2 position)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            points.Add(position);
        }

        if (Vector2.Distance(points.Last(),position) > .1f)
        {
            SetPoint(position);
        }
    }
}