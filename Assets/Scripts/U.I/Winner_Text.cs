using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winner_Text : MonoBehaviour
{
    public Text winnerText;
    public turn_behaviour turnManagerScript;

    private void Update()
    {
        if (turnManagerScript.ai_win == 2)
        {
            winnerText.text = "Winner is the A.I!!!";
        }
        if ( turnManagerScript.player_win == 2)
        {
            winnerText.text = "Winner is the Player!!!";
        }
    }
}
