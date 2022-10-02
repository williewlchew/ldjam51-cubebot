using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    public ObstacleInterface _obstacleInterface;

    void OnEnable ()
    {
        PhaseTrigger.ChangePhase1 += ChangeBridgePhase1;
        PhaseTrigger.ChangePhase2 += ChangeBridgePhase2;
        PhaseTrigger.ChangePhase3 += ChangeBridgePhase3;
    }
    void OnDisable ()
    {
        PhaseTrigger.ChangePhase1 -= ChangeBridgePhase1;
    }

    void ChangeBridgePhase1()
    {
        _obstacleInterface.ChangeSpriteColor();
        _obstacleInterface.UnObstruct();
    }

    void ChangeBridgePhase2()
    {
        _obstacleInterface.ChangeSpriteColor();
        _obstacleInterface.UnObstruct();
    }

    void ChangeBridgePhase3()
    {
        _obstacleInterface.ChangeSpriteColor();
        _obstacleInterface.UnObstruct();
    }
}
