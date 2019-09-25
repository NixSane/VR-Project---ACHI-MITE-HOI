using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Behaviour : MonoBehaviour
{
    public State.STATE ai_State;
    public HandSigns.Signs ai_hands;
    public Directions.Points ai_points;

    private void Awake()
    {
        Random.InitState((int)Time.time);
    }


    // Start is called before the first frame update
    void Start()
    {
        ai_State = State.STATE.ROCK_PAPER_SCISSORS;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void randomNumber()
    {
        switch (ai_State)
        {
            case State.STATE.ROCK_PAPER_SCISSORS:
                ai_hands = (HandSigns.Signs)Random.Range(0, 2);
                break;
            case State.STATE.LOOK_OVER_THERE:
                ai_points = (Directions.Points)Random.Range(0, 3);
                break;
        }
    }
}
