using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 camera_rotation;
    public float rotation_speed = 2.0f;
    private Vector3 mouse;
    public float cam_sensitivity = 0.25f;

    // For locking the cursor
    Cursor cursor = new Cursor();

    // State for rock paper scissors and  Four Directions State
    Rock_Paper_Scissors player_RPS_state;
    Four_Directions_State.Directions player_FD_state;
    

    // RayCast stuff
    Ray line;
    public Camera cam;
    RaycastHit hit;

    // The collision boxes for the player
    public GameObject[] box_colliders = new GameObject[4];

    private void Awake()
    {
        player_FD_state = Four_Directions_State.Directions.NONE;
        line.origin = transform.position;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseLook();
        RayCast();
        
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
}
