using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_behaviour : MonoBehaviour
{
    private First_Person_Camera playerScript;
    private AI_Behaviour aiScript;

    public GameObject player;
    public GameObject ai;

    // Variable for those who win
    int player_win;
    int ai_win;

    // The pointer
    public bool player_isPointing;
    public bool ai_isPointing;

    private void Awake()
    {
        playerScript = player.GetComponent<First_Person_Camera>();
        aiScript = ai.GetComponent<AI_Behaviour>();

        player_win = 0;
        ai_win = 0;
        player_isPointing = false;
        ai_isPointing = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RockPaperScissors()
    {
        // If the Player wins
        if (playerScript.player_hands == HandSigns.Signs.ROCK && aiScript.ai_hands == HandSigns.Signs.SCISSORS ||
            playerScript.player_hands == HandSigns.Signs.SCISSORS && aiScript.ai_hands == HandSigns.Signs.PAPER ||
            playerScript.player_hands == HandSigns.Signs.PAPER && aiScript.ai_hands == HandSigns.Signs.ROCK)
        {
            Debug.Log(playerScript.player_hands);
            Debug.Log(aiScript.ai_hands);

            // Player becomes the pointer
            player_isPointing = true;

            // AI becomes the looker
            ai_isPointing = false;
        }
        // If the AI wins
        else if (aiScript.ai_hands == HandSigns.Signs.ROCK && playerScript.player_hands == HandSigns.Signs.SCISSORS ||
            aiScript.ai_hands == HandSigns.Signs.SCISSORS && playerScript.player_hands == HandSigns.Signs.PAPER ||
            aiScript.ai_hands == HandSigns.Signs.PAPER && playerScript.player_hands == HandSigns.Signs.ROCK)
        {
            Debug.Log(aiScript.ai_hands);
            Debug.Log(playerScript.player_hands);

            // AI points. Player looks
            ai_isPointing = true;
            player_isPointing = false;
        }
        // In all other cases, it's a draw.
        else
        {
            // Both don't win, they continue doing Rock Paper Scissors.
        }
    }

    void LookOverThere()
    {
        // Player is the pointer and wins
        if (playerScript.player_directions == Directions.Points.UP && aiScript.ai_points != Directions.Points.DOWN ||
            playerScript.player_directions == Directions.Points.DOWN && aiScript.ai_points != Directions.Points.UP ||
            playerScript.player_directions == Directions.Points.LEFT && aiScript.ai_points != Directions.Points.LEFT ||
            playerScript.player_directions == Directions.Points.RIGHT && aiScript.ai_points != Directions.Points.RIGHT)
        {
            Debug.Log(playerScript.player_directions);
            Debug.Log(aiScript.ai_points);

            // Player wins the round
            // UI opens
        }
        // AI is the pointer and wins
        if (aiScript.ai_points == Directions.Points.UP && playerScript.player_directions != Directions.Points.DOWN ||
            aiScript.ai_points == Directions.Points.DOWN && playerScript.player_directions != Directions.Points.UP ||
            aiScript.ai_points == Directions.Points.LEFT && playerScript.player_directions != Directions.Points.LEFT ||
            aiScript.ai_points == Directions.Points.RIGHT && playerScript.player_directions != Directions.Points.RIGHT)
        {
            Debug.Log(playerScript.player_directions);
            Debug.Log(aiScript.ai_points);

            // AI wins the round
            // UI opens
        }
        // In all other cases, it's a draw.
        else
        {
            // Both don't win, they continue doing ACHI MITE HOI
        }
    }

    // For deciding who wins
    void choosePointer()
    {
        // If Player won rock paper scissors
        if (player_isPointing && !ai_isPointing)
        {
            // Tells player to use the Oculus controller
            // AI is told to rotate.
        }

        // If Ai won the rock paper scissors
        if (!player_isPointing && ai_isPointing)
        {
            // Is told to look in the opposite direction the opponent points via UI
            // AI is set to pointing, or a display tells the player what direction the AI points in
        }
    }
}
