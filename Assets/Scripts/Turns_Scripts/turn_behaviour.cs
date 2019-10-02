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
    public int player_win;
    public int ai_win;

    // The pointer
    public bool player_isPointing;
    public bool ai_isPointing;

    private void Awake()
    {
        playerScript = player.GetComponent<First_Person_Camera>();
        aiScript = ai.GetComponent<AI_Behaviour>();

        player_win = 0;
        ai_win = 0;      
    }

    // Start is called before the first frame update
    void Start()
    {
        // Setting the player and Ai up.
        player_isPointing = false;
        ai_isPointing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player_win == 0 && ai_win == 0)
            RockPaperScissors();

        if (player_win > 0 || ai_win > 0)
            LookOverThere();

        // End the game if one of them win
        endGame();
    }

    void RockPaperScissors()
    {
        // If the Player wins
        if (playerScript.player_hands == HandSigns.Signs.ROCK && aiScript.ai_hands == HandSigns.Signs.SCISSORS ||
            playerScript.player_hands == HandSigns.Signs.SCISSORS && aiScript.ai_hands == HandSigns.Signs.PAPER ||
            playerScript.player_hands == HandSigns.Signs.PAPER && aiScript.ai_hands == HandSigns.Signs.ROCK && player_win == 0)
        {
            Debug.Log(playerScript.player_hands);
            Debug.Log(aiScript.ai_hands);

            // Player becomes the pointer
            player_isPointing = true;

            // AI becomes the looker
            ai_isPointing = false;

            player_win++;
        }

        // If the AI wins
        if (aiScript.ai_hands == HandSigns.Signs.ROCK && playerScript.player_hands == HandSigns.Signs.SCISSORS ||
            aiScript.ai_hands == HandSigns.Signs.SCISSORS && playerScript.player_hands == HandSigns.Signs.PAPER ||
            aiScript.ai_hands == HandSigns.Signs.PAPER && playerScript.player_hands == HandSigns.Signs.ROCK && ai_win == 0)
        {
            Debug.Log(aiScript.ai_hands);
            Debug.Log(playerScript.player_hands);

            // AI points. Player looks
            ai_isPointing = true;
            player_isPointing = false;

            ai_win++;
        }

        // If draw
        if (playerScript.player_hands == HandSigns.Signs.ROCK && aiScript.ai_hands == HandSigns.Signs.ROCK ||
            playerScript.player_hands == HandSigns.Signs.SCISSORS && aiScript.ai_hands == HandSigns.Signs.SCISSORS ||
            playerScript.player_hands == HandSigns.Signs.PAPER && aiScript.ai_hands == HandSigns.Signs.PAPER)
        {
            Restart_RPS();
        }
    }

    void LookOverThere()
    {
        // Player is the pointer and wins
        if (player_isPointing && playerScript.player_directions == Directions.Points.UP && aiScript.ai_points != Directions.Points.DOWN ||
            playerScript.player_directions == Directions.Points.DOWN && aiScript.ai_points != Directions.Points.UP ||
            playerScript.player_directions == Directions.Points.LEFT && aiScript.ai_points != Directions.Points.LEFT ||
            playerScript.player_directions == Directions.Points.RIGHT && aiScript.ai_points != Directions.Points.RIGHT && player_win == 1)
        {
            Debug.Log("Player Choose: " + playerScript.player_directions);
            Debug.Log("AI choose: " + aiScript.ai_points);

            player_win++;
        }


        // AI is the pointer and wins
        if (ai_isPointing && aiScript.ai_points == Directions.Points.UP && playerScript.player_directions != Directions.Points.DOWN ||
            aiScript.ai_points == Directions.Points.DOWN && playerScript.player_directions != Directions.Points.UP ||
            aiScript.ai_points == Directions.Points.LEFT && playerScript.player_directions != Directions.Points.LEFT ||
            aiScript.ai_points == Directions.Points.RIGHT && playerScript.player_directions != Directions.Points.RIGHT && ai_win == 1)
        {
            Debug.Log(playerScript.player_directions);
            Debug.Log(aiScript.ai_points);

            ai_win++;
        }
      
    }

    // This restarts the game at the Rock paper scissors point
    void Restart_RPS()
    {
        player_win = 0;
        ai_win = 0;
        aiScript.ai_hands = HandSigns.Signs.NONE;
        playerScript.player_hands = HandSigns.Signs.NONE;
        aiScript.rngDone = 0;
    }

    // Restarts the game at the pointing part of the game
    void Restart_Pointing()
    {

        aiScript.ai_points = Directions.Points.NONE;
        playerScript.player_directions = Directions.Points.NONE;
        aiScript.rngDone = 1;
    }


    void endGame()
    {
        if (player_win == 2)
        {
            playerScript.RPSCanvas.SetActive(false);
            playerScript.PointingCanvas.SetActive(false);
            playerScript.EndGameCanvas.SetActive(true);
        }

        if (ai_win == 2)
        {
            playerScript.RPSCanvas.SetActive(false);
            playerScript.PointingCanvas.SetActive(false);
            playerScript.EndGameCanvas.SetActive(true);
        }
    }

    public void replayGame()
    {
        // Reset the UI
        playerScript.RPSCanvas.SetActive(true);
        playerScript.PointingCanvas.SetActive(false);
        playerScript.EndGameCanvas.SetActive(false);

        // Win scores go back to zero
        player_win = 0;
        ai_win = 0;

        // No one points
        player_isPointing = false;
        ai_isPointing = false;

        playerScript.playerState = State.STATE.ROCK_PAPER_SCISSORS;
        aiScript.ai_State = State.STATE.ROCK_PAPER_SCISSORS;

        playerScript.transform.LookAt(ai.transform);
    }
}
