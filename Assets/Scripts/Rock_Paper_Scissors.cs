using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Rock_Paper_Scissors : MonoBehaviour
{
    enum Signs
    {
        ROCK,
        PAPER,
        SCISSORS
    }

    void Hand_Signs(Signs hand_signs)
    {
        switch (hand_signs)
        {
            case Signs.ROCK:
                //DO SOMETHING FOR ROCK
                transform.Rotate(0.0f, -90.0f, 0.0f);
                break;
            case Signs.PAPER:
                //DO SOMETHING FOR PAPER
                transform.Rotate(10.0f, 45.0f, 0.0f);
                break;
            case Signs.SCISSORS:
                //DO SOMETHING FOR SCISSORS
                transform.Rotate(0.0f, 0.0f, 45.0f);
                break;
        }
    }

    public void Update()
    {
        Signs sign = (Signs)UnityEngine.Random.Range(0, 2);
        Hand_Signs(sign);
    }
}

