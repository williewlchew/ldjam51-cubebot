using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAttack : MonoBehaviour
{
    public BearManager _bearManager;
    public float attackWait = 1f;
    private bool inProximity = false;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            inProximity = true;
            _bearManager.attacking = true;
            StartCoroutine(AttackRoutine(other.gameObject.transform.position, attackWait));
        }
        // update visuals for angry
        // wait
        // charge
    }

    void OnTriggerExit(Collider other)
    {
        inProximity = false;
        _bearManager.attacking = false;
    }

    IEnumerator AttackRoutine(Vector3 target, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (inProximity == true){
            _bearManager.Attack(target);
        }
    }
}
