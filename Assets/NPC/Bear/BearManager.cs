using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearManager : MonoBehaviour
{
    int phase;

    void OnEnable ()
    {
        PhaseTrigger.ChangePhase1 += ChangeBearPhase1;
    }
    void OnDisable ()
    {
        PhaseTrigger.ChangePhase1 -= ChangeBearPhase1;
    }

    void ChangeBearPhase1()
    {
        
    }
}
