using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesManager : MonoBehaviour
{
    public BoxCollider _boxCollider;
    public NPCInterface _npcInterface;
    public Animator _animator;

    /* Phase control */

    void OnEnable()
    {
        GameManagerMain.DimensionOne += ChangeSpikesPhase1;
        GameManagerMain.DimensionTwo += ChangeSpikesPhase2;
        GameManagerMain.DimensionThree += ChangeSpikesPhase3;
    }
    void OnDisable()
    {
        GameManagerMain.DimensionOne -= ChangeSpikesPhase1;
        GameManagerMain.DimensionTwo -= ChangeSpikesPhase2;
        GameManagerMain.DimensionThree -= ChangeSpikesPhase3;
    }

    // become grass 
    void ChangeSpikesPhase1(){
        // switch to grass sprite
        _animator.SetInteger("CurrentState", 0);
        _npcInterface.ChangeColor(1);
        
        // disable collider
        _boxCollider.enabled = false;
    }

    void ChangeSpikesPhase2(){
        _npcInterface.ChangeColor(2);
    }
    
    // become spikes
    void ChangeSpikesPhase3(){
        // switch to grass sprite
        _animator.SetInteger("CurrentState", 1);
        _npcInterface.ChangeColor(3);

        // disable collider
        _boxCollider.enabled = true;
    }


}
