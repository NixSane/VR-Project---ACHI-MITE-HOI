using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Player : MonoBehaviour
{
    private First_Person_Camera player_state;
    public GameObject player;
    

    private GameObject slider;
   

    private void Awake()
    {
        player_state = player.GetComponent<First_Person_Camera>();
        slider = GetComponent<GameObject>();
    }

    void Update()
    {      
       
    }
}
