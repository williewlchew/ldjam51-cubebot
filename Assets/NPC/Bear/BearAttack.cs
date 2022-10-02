using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAttack : MonoBehaviour
{
    public BearManager _bearManager;

    void OnTriggerStay(Collider other)
    {
        _bearManager.attacking = true;
        // update visuals for angry
        // wait
        // charge
    }

    void OnTriggerExit(Collider other)
    {
        _bearManager.attacking = false;
    }
}
