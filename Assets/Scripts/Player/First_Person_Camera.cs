using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class First_Person_Camera : MonoBehaviour
{
    // For the Player's camera
    Vector3 camera_rotation;

    // Gets the turn_script
    public GameObject turnControl;
    private turn_behaviour playerTurn;

    // Raycast
    Ray line;

    // State
    public State.STATE playerState;
    public Directions.Points player_directions;
    public HandSigns.Signs player_hands;

    // Buttons from Rock, Paper, Scissors UI
    [Header("UI Commands")]
    private UI_Player uiCommands;
    private UI_Player PointerUI;
    public GameObject RPSCanvas;
    public GameObject PointingCanvas;
    public GameObject EndGameCanvas;
    

    // Pointer or Looker?

    // Array for collision check
    [Header("Collision Boxes for Raycast")]
    public GameObject[] boxes;

    private void Awake()
    {
        playerTurn = turnControl.GetComponent<turn_behaviour>();          
    }


    // Start is called before the first frame update
    void Start()
    {
        // Default Start
        playerState = State.STATE.ROCK_PAPER_SCISSORS;
        player_hands = HandSigns.Signs.NONE;
        player_directions = Directions.Points.NONE;

        boxes = new GameObject[4];
        boxes[0] = new GameObject("Up_Box");
        boxes[1] = new GameObject("Down_Box");
        boxes[2] = new GameObject("Right_Box");
        boxes[3] = new GameObject("Left_Box");
                
        line.origin = transform.position;       
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn.player_isPointing && !playerTurn.ai_isPointing ||
            !playerTurn.player_isPointing && playerTurn.ai_isPointing)
        {
            playerState = State.STATE.LOOK_OVER_THERE;
            RPSCanvas.SetActive(false);
        }

        if (playerState == State.STATE.LOOK_OVER_THERE && playerTurn.player_isPointing)
        {
            PointingCanvas.SetActive(true);
        }

        // If Player loses, Player his to look around via headset or mouse rotation/
        if (playerState == State.STATE.LOOK_OVER_THERE && playerTurn.ai_isPointing)
        {
            mouseLook();
            rayCast();
        }

        //if (playerTurn.player_win == 2 || playerTurn.ai_win == 2)
        //{
        //    RPSCanvas.SetActive(false);
        //    PointingCanvas.SetActive(false);
        //    EndGameCanvas.SetActive(true);
        //}

        // So the player can get out of the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Mouse look for the the Player
    private void mouseLook()
    {
        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_y = Input.GetAxis("Mouse Y");

        camera_rotation.x += mouse_x;
        camera_rotation.y += -mouse_y;
        camera_rotation.y = Mathf.Clamp(camera_rotation.y, -60.0f, 60.0f);

        transform.eulerAngles = new Vector3(camera_rotation.y, camera_rotation.x, 0.0f);
    }

    // If the player loss
    private void rayCast()
    {
        line = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        Debug.DrawRay(line.origin, line.direction, Color.cyan);
        RaycastHit hit;

        if (Physics.Raycast(line, out hit))
        {
            if (hit.collider == boxes[0].gameObject)
            {
                player_directions = Directions.Points.UP;
            }
            if (hit.collider == boxes[1].gameObject)
            {
                player_directions = Directions.Points.DOWN;
            }
            if (hit.collider == boxes[2].gameObject)
            {
                player_directions = Directions.Points.RIGHT;
            }
            if (hit.collider == boxes[3].gameObject)
            {
                player_directions = Directions.Points.LEFT;
            }
        }
    }

   // End Game UI
   public void closeGame()
   {
        Application.Quit();
   }

 

    // Public Directions commands for Pointing buttons
    public void pointUp()
    {
        player_directions = Directions.Points.UP;
    }
    public void pointDown()
    {
        player_directions = Directions.Points.DOWN;
    }

    public void pointRight()
    {
        player_directions = Directions.Points.RIGHT;
    }

    public void pointLeft()
    {
        player_directions = Directions.Points.LEFT;
    }


    // Rock Paper Scissors for player
    public void Rock()
    {
        player_hands = HandSigns.Signs.ROCK;
    }

    public void Paper()
    {
        player_hands = HandSigns.Signs.PAPER;
    }

    public void Scissors()
    {
        player_hands = HandSigns.Signs.SCISSORS;
    }
}
