using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Player : MonoBehaviour
{
    private First_Person_Camera player_state;
    public GameObject player;
    public AI_Behaviour ai_choice;
    public Text text;

    private GameObject slider;
   

    private void Awake()
    {
        ai_choice = GetComponent<AI_Behaviour>();
        text.text = "A.I choose: " + ai_choice.ai_hands.ToString();
    }

    private void Update()
    {
        text.text = "A.I choose: " + ai_choice.ai_hands.ToString();
    }
}
