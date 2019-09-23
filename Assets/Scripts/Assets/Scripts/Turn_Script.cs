using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_Script : MonoBehaviour
{
    // The two objects needed for their scripts
    public Component Player;
    public Component AI_Opponent;

    // These get the scripts attached to the above GameObjects
    private Camera_Script playerCam;
    private Rock_Paper_Scissors.Signs player_state;

    private AI_Behaviour AI;
    private Rock_Paper_Scissors.Signs AI_signs;


    // Game conditions
    float timer;
    int player_win;
    int ai_win;

    // Game starts off as Rock, Paper, Scissors
    public bool rock_paper_scissor;
    public bool directions_state;

    void Awake()
    {
        Player = GetComponent<Component>();
        playerCam = Player.GetComponent<Camera_Script>();
        player_state = playerCam.player_RPS_state;

        AI_Opponent = GetComponent<Component>();
        AI = AI_Opponent.GetComponent<AI_Behaviour>();
        AI_signs = AI.hand;

        rock_paper_scissor = true;
        directions_state = false;
        reset();
    }


    // Start is called before the first frame update
    void Start()
    {
        timer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Rock, Paper Scissors to decide the winner and pointer
        if (player_win == 0 && ai_win == 0)
        {
            rock_paper_scissors_stage();
        }

        timer -= 0.01f * Time.deltaTime;
    }

    void reset()
    {
        rock_paper_scissor = true;
        directions_state = false;

        player_win = 0;
        ai_win = 0;
    }

    // Round 1 of the pointing game.
    void rock_paper_scissors_stage()
    {
        // For if the player wins
        if (playerCam.player_RPS_state == Rock_Paper_Scissors.Signs.ROCK && AI.hand == Rock_Paper_Scissors.Signs.SCISSORS)
        {
            player_win = 1;
        }
        if (playerCam.player_RPS_state == Rock_Paper_Scissors.Signs.SCISSORS && AI.hand == Rock_Paper_Scissors.Signs.PAPER)
        {
            player_win = 1;
        }
        if (playerCam.player_RPS_state == Rock_Paper_Scissors.Signs.PAPER && AI.hand == Rock_Paper_Scissors.Signs.ROCK)
        {
            player_win = 1;
        }

        // If the A.I wins
        if (AI.hand == Rock_Paper_Scissors.Signs.ROCK && playerCam.player_RPS_state == Rock_Paper_Scissors.Signs.SCISSORS)
        {
            ai_win = 1;
        }
        if (AI.hand == Rock_Paper_Scissors.Signs.SCISSORS && playerCam.player_RPS_state == Rock_Paper_Scissors.Signs.PAPER)
        {
            ai_win = 1;
        }
        if (AI.hand == Rock_Paper_Scissors.Signs.PAPER && playerCam.player_RPS_state == Rock_Paper_Scissors.Signs.ROCK)
        {
            ai_win = 1;
        }

        // But if both do the same, reset the scores and try again
        if (AI.hand == Rock_Paper_Scissors.Signs.ROCK && playerCam.player_RPS_state == Rock_Paper_Scissors.Signs.ROCK)
        {
            reset();
        }
        if (AI.hand == Rock_Paper_Scissors.Signs.SCISSORS && playerCam.player_RPS_state == Rock_Paper_Scissors.Signs.SCISSORS)
        {
            reset();
        }
        if (AI.hand == Rock_Paper_Scissors.Signs.PAPER && playerCam.player_RPS_state == Rock_Paper_Scissors.Signs.PAPER)
        {
            reset(); 
        }
    }

    // The one who wins points, the other looks in another direction
    void pointer()
    {
        if (player_win == 1 && ai_win == 0)
        {

        }
    }
}
