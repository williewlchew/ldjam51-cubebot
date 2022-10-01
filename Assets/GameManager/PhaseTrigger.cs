using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseTrigger: MonoBehaviour
{
    public delegate void PhaseChangeEvent ();
    public static event PhaseChangeEvent ChangePhase;

    // Start is called before the first frame update
    void OnEnable()
    {
        ChangePhase();
    }
}
