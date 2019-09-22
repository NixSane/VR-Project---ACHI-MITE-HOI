using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AI_Behaviour : MonoBehaviour
{
    Random Rand = new Random();

    AI.AI_State state;
    int win = 0;

    public Rock_Paper_Scissors rps;
    public Four_Directions_State four_points;
    
    public float rotation;
    public float rotationSpeed = 10;

    public static double seed;

    // A small function for reseting the 'A.I'
    private void Reset()
    {
        win = 0;
        state = AI.AI_State.RPS;
        //Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
        //Quaternion rot = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        //transform.position = pos;
        //transform.rotation = rot;
    }

    void Awake()
    {
        // Seed for random number generator
        seed = System.DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        Random.InitState((int)seed);
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (win == 1)
            {
                state = AI.AI_State.ACHI_MITE_HOI;
            }
            else
            {
                Reset();
            }
            State_Change();
        }
    }

    void State_Change()
    {
        switch (state)
        {
            case AI.AI_State.RPS:
                rps.Update();
                break;
            case AI.AI_State.ACHI_MITE_HOI:
                four_points.Update();
                break;
            default:
                break;
        }
    }
}
