using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_script : MonoBehaviour
{
    public GameObject cam;
    public RaycastHit hit;


    public GameObject[] boxes = new GameObject[4];

    Ray line;
    
    // Start is called before the first frame update
    void Start()
    {
        line.origin = cam.transform.position;
        Physics.Raycast(line);
       

    }

    // Update is called once per frame
    void Update()
    {
      

        line.origin = cam.transform.position;
        line.direction = cam.transform.forward;
        Debug.DrawRay(line.origin, line.direction, Color.white);

        if(Physics.Raycast(line, out hit))
        {
            print(hit.transform.name);
        }

        
    }

    void Box_Colliders()
    {
       
    }
}
