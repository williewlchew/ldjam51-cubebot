using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseTrigger: MonoBehaviour
{
    public delegate void PhaseChangeEvent ();
    public static event PhaseChangeEvent ChangePhase1;
    public static event PhaseChangeEvent ChangePhase2;
    public static event PhaseChangeEvent ChangePhase3;


    // temp
    void OnEnable()
    {
        ChangePhase1();
    }

    public void ChangePhase(int phase)
    {
        
    }
}
