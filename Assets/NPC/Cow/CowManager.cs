using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowManager : MonoBehaviour
{
    void OnEnable()
    {
        GameManagerMain.DimensionOne += ChangeCowPhase1;
        GameManagerMain.DimensionTwo += ChangeCowPhase2;
        GameManagerMain.DimensionThree += ChangeCowPhase3;
    }
    void OnDisable()
    {
        GameManagerMain.DimensionOne -= ChangeCowPhase1;
        GameManagerMain.DimensionTwo -= ChangeCowPhase2;
        GameManagerMain.DimensionThree -= ChangeCowPhase3;
    }

    void ChangeCowPhase1()
    {
        
    }

    void ChangeCowPhase2()
    {
        
    }

    void ChangeCowPhase3()
    {
        
    }
}
