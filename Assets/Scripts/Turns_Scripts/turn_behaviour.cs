using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_behaviour : MonoBehaviour
{
    private First_Person_Camera playerScript;

    public GameObject player;

    private void Awake()
    {
        playerScript = player.GetComponent<First_Person_Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
