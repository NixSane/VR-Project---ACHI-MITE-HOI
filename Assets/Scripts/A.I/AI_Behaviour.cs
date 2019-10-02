using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Behaviour : MonoBehaviour
{
    public State.STATE ai_State;
    public HandSigns.Signs ai_hands;
    public Directions.Points ai_points;

    // Get the turn controller
    public GameObject turnControl;
    private turn_behaviour turn_Behaviour;

    // Variables to stop constant random number generation
    private First_Person_Camera playerTrigger;
    public GameObject player;
    public int rngDone;

    private void Awake()
    {
        Random.InitState((int)Time.time);
        playerTrigger = player.GetComponent<First_Person_Camera>();

        turn_Behaviour = turnControl.GetComponent<turn_behaviour>();

        rngDone = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        ai_State = State.STATE.ROCK_PAPER_SCISSORS;
        ai_hands = HandSigns.Signs.NONE;
        ai_points = Directions.Points.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        // By default, the A.I and player start off with rock paper scissors
        if (ai_State == State.STATE.ROCK_PAPER_SCISSORS && playerTrigger.playerState == State.STATE.ROCK_PAPER_SCISSORS)
        {
            if (playerTrigger.player_hands != HandSigns.Signs.NONE && rngDone == 0)
            {
                randomNumber();
                rngDone++;
            }
            
        }

        // AI is the pointer
        if (turn_Behaviour.ai_isPointing && !turn_Behaviour.player_isPointing)
        {
            ai_State = State.STATE.LOOK_OVER_THERE;

            if (ai_State == State.STATE.LOOK_OVER_THERE && rngDone != 2)
            {
                randomNumber();
                rngDone++;
            }
        }
        
        // A.I Loses
        if (turn_Behaviour.player_isPointing && !turn_Behaviour.ai_isPointing)
        {
            ai_State = State.STATE.LOOK_OVER_THERE;

            if (playerTrigger.player_directions != Directions.Points.NONE && rngDone != 2)
            {
                randomNumber();
                rngDone++;
            }
        }
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
