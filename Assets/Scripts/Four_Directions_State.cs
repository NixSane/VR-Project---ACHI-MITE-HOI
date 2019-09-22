using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Four_Directions_State : MonoBehaviour
{
    public enum Directions
    {
        UP,
        DOWN,
        RIGHT,
        LEFT,
        NONE
    }

    

    void Points(Directions ways)
    {
        switch (ways)
        {
            case Directions.UP:
                // Rotate block or head upwards
                transform.Translate(0.0f, 5.0f, 0.0f);
                break;
            case Directions.DOWN:
                // Rotate block or head down
                transform.Translate(0.0f, -5.0f, 0.0f);
                break;
            case Directions.RIGHT:
                // Rotate block or head to the Right
                transform.Translate(5.0f, 0.0f, 0.0f);
                break;
            case Directions.LEFT:
                // Rotate block or head to the left
                transform.Translate(-5.0f, 0.0f, 0.0f);
                break;
            default:
                break;
        }
    }

    public void Update()
    {
        Directions directions = (Directions)UnityEngine.Random.Range(0, 4);
        Points(directions);
    }



}

