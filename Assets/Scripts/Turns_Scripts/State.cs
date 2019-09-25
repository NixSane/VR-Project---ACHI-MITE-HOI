using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
   public enum STATE
   {
        ROCK_PAPER_SCISSORS,
        LOOK_OVER_THERE
   }
}

public class HandSigns : State
{
    public enum Signs
    {
        ROCK,
        PAPER,
        SCISSORS,
        NONE
    }
}

public class Directions : State
{
    public enum Points
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        NONE
    }
}
