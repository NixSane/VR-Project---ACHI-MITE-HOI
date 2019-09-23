using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AI : MonoBehaviour
{
    public enum AI_State
    {
        RPS,
        ACHI_MITE_HOI
    }

    public AI_State state = AI_State.RPS;

}

