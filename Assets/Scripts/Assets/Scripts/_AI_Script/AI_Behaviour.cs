using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AI_Behaviour : MonoBehaviour
{
    Random Rand = new Random();

    public AI.AI_State state;   

    public Rock_Paper_Scissors rps;
    public Four_Directions_State four_points;

    public Rock_Paper_Scissors.Signs hand;
    public Four_Directions_State.Directions dir;

    private Turn_Script AI_Script;

    public static double seed;

    // A small function for reseting the 'A.I'
    private void Reset()
    {
        state = AI.AI_State.RPS;
    }

    void Awake()
    {
        // Seed for random number generator
        seed = System.DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        Random.InitState((int)seed);

        AI_Script = GetComponent<Turn_Script>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
       if (AI_Script.rock_paper_scissor)
       {
            state = AI.AI_State.RPS;
       }
       if (AI_Script.directions_state)
        {
            state = AI.AI_State.ACHI_MITE_HOI;
        }
        State_Change();
    }

    void State_Change()
    {
        switch (state)
        {
            case AI.AI_State.RPS:
                hand = rps.RandomSigns();
                break;
            case AI.AI_State.ACHI_MITE_HOI:
                four_points.RandomDirection();
                break;
            default:
                break;
        }
    }
}
