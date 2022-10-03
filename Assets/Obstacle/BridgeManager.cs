using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    public ObstacleInterface _obstacleInterface;

    void OnEnable ()
    {
        GameManagerMain.DimensionOne += ChangeBridgePhase1;
        GameManagerMain.DimensionTwo += ChangeBridgePhase2;
        GameManagerMain.DimensionThree += ChangeBridgePhase3;
    }
    void OnDisable ()
    {
        GameManagerMain.DimensionOne -= ChangeBridgePhase1;
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
