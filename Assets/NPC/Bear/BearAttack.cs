using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAttack : MonoBehaviour
{
    public BearManager _bearManager;
    public float attackWait = 1f;
    private bool inProximity = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            inProximity = true;
            _bearManager.attacking = true;
            StartCoroutine(AttackRoutine(other.gameObject.transform.position, attackWait));
            _bearManager._animator.SetInteger("CurrentAnimation", 20);
        }
    }

    void OnTriggerExit(Collider other)
    {
        inProximity = false;
        _bearManager.attacking = false;
        _bearManager._animator.SetInteger("CurrentAnimation", 0);
    }

    IEnumerator AttackRoutine(Vector3 target, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (inProximity == true){
            _bearManager.Attack(target);
        }
    }
}
