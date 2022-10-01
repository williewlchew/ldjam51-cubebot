using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    public ObstacleInterface _obstacleInterface;

    void OnEnable ()
    {
        PhaseTrigger.ChangePhase += ChangeBridgePhase;
    }
    void OnDisable ()
    {
        PhaseTrigger.ChangePhase -= ChangeBridgePhase;
    }

    void ChangeBridgePhase()
    {
        _obstacleInterface.ChangeSpriteColor();
        _obstacleInterface.UnObstruct();
    }
}
