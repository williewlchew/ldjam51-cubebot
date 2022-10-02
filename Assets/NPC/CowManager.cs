using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowManager : MonoBehaviour
{
    public ObstacleInterface _obstacleInterface;

    void OnEnable ()
    {
        PhaseTrigger.ChangePhase1 += ChangeCowPhase1;
    }
    void OnDisable ()
    {
        PhaseTrigger.ChangePhase1 -= ChangeCowPhase1;
    }

    void ChangeCowPhase1()
    {
        _obstacleInterface.ChangeSpriteColor();
        _obstacleInterface.UnObstruct();
    }
}
