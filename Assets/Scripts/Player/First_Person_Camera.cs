using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class First_Person_Camera : MonoBehaviour
{
    // For the Player's camera
    Vector3 camera_rotation;

    // Raycast
    Ray line;

    // State
    public State.STATE playerState;
    public Directions.Points player_directions;
    public HandSigns.Signs player_hands;



    // Array for collision check
    [Header("Collision Boxes for Raycast")]
    public GameObject[] boxes;
   

    // Start is called before the first frame update
    void Start()
    {
        playerState = State.STATE.ROCK_PAPER_SCISSORS;

        boxes = new GameObject[4];

        line.origin = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseLook();

        if (playerState == State.STATE.LOOK_OVER_THERE)
        {
            rayCast();
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
        camera_rotation.y = Mathf.Clamp(camera_rotation.y, -60.0f, 60.0f);

        transform.eulerAngles = new Vector3(camera_rotation.y, camera_rotation.x, 0.0f);
    }

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
}
