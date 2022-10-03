using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public GameManagerMain gameManagerMain;
    public GameObject blocker;
    public GameObject blocker2;
    public BoxCollider _boxCollider;
    public Transform target;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            blocker.SetActive(false);
            blocker2.SetActive(false);
            gameManagerMain.KeyAcquired();
            _boxCollider.enabled = false;
            StartCoroutine(MoveRoutine(target.position, 10));
        }
    }

    IEnumerator MoveRoutine(Vector3 target, float seconds)
    {
        while (!AtCurrentGoal(target)) {
            transform.position = Vector3.MoveTowards(transform.position, target, 10 * Time.deltaTime);
            yield return null;
        }
    }
    
    private bool AtCurrentGoal(Vector3 goal)
    {
        float dist = Vector3.Distance(goal, transform.position);
        if(dist < 1f)
        {
            return true;
        }
        else {
            return false;
        }
    }
}
