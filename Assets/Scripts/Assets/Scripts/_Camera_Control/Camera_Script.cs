using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    private Turn_Script turn_controller;

    // Start is called before the first frame update
    Vector3 camera_rotation;
    public float rotation_speed = 2.0f;
    public float cam_sensitivity = 0.25f;

    // For locking the cursor
    Cursor cursor = new Cursor();

    // State for rock paper scissors and  Four Directions State
    public Rock_Paper_Scissors.Signs player_RPS_state;
    public Four_Directions_State.Directions player_FD_state;
    

    // RayCast stuff
    Ray line;
    public Camera cam;
    RaycastHit hit;

    // The collision boxes for the player
    public GameObject[] box_colliders = new GameObject[4];

    private void Awake()
    {
        // So no warnings get thrown
        player_FD_state = Four_Directions_State.Directions.NONE;
        player_RPS_state = Rock_Paper_Scissors.Signs.NONE;
        line.origin = transform.position;
       
        turn_controller = GetComponent<Turn_Script>();
    }

    void Start()
    {
        turn_controller.rock_paper_scissor = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseLook();

        if (turn_controller.rock_paper_scissor)
        {
            RPS_controls();
        }

        if (turn_controller.directions_state)
        {
            RayCast();
        }
        
        // So the player can get out of the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Mouse look for the the Player
    private void mouseLook()
    {
        float mouse_x = Input.GetAxis("Mouse X");
        float mouse_y = Input.GetAxis("Mouse Y");

        camera_rotation.x += mouse_x;
        camera_rotation.y += -mouse_y;
       
        transform.eulerAngles = new Vector3(camera_rotation.y, camera_rotation.x, 0.0f);
    }

    // Ray cast for the Four Directions State
    private void RayCast()
    {
        // Some magic numbers to make sure the Ray is going in the Direction the camera is facing.
        line = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        Debug.DrawRay(line.origin, line.direction, Color.white);

        if (Physics.Raycast(line, out hit))
        {
            // The right Collision Box
            if (hit.collider == box_colliders[0])
            {
                player_FD_state = Four_Directions_State.Directions.RIGHT;
            }
            // The left Collision Box
            if (hit.collider == box_colliders[1])
            {
                player_FD_state = Four_Directions_State.Directions.LEFT;
            }
            // The up Collision Box
            if (hit.collider == box_colliders[2])
            {
                player_FD_state = Four_Directions_State.Directions.UP;
            }
            // The down Collision Box
            if (hit.collider == box_colliders[3])
            {
                player_FD_state = Four_Directions_State.Directions.DOWN;
            }
            else
            {
                player_FD_state = Four_Directions_State.Directions.NONE;
            }
        }
    }

    // Controls for the Rock, Paper, Scissors state
    private void RPS_controls()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player_RPS_state = Rock_Paper_Scissors.Signs.ROCK;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            player_RPS_state = Rock_Paper_Scissors.Signs.PAPER;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            player_RPS_state = Rock_Paper_Scissors.Signs.SCISSORS;
        }
        else
        {
            player_RPS_state = Rock_Paper_Scissors.Signs.NONE;
        }
    }
}
