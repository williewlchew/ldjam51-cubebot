using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearManager : MonoBehaviour
{
    public SphereCollider _bearAttack;
    public NPCInterface _npcInterface;
    public Animator _animator;
    public Transform[] patrolPoints2;

    public bool attacking;

    // temp
    public int currentPhase;
    private int currentPatrol2Point;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start() 
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        ChangeBearPhase1(); // temp
    }

    void Update () 
    { 
        // sleep
        if (currentPhase == 1){

        }

        // patrol around
        if (currentPhase == 2){
            // moving
            if(AtCurrentGoal(patrolPoints2[currentPatrol2Point].position)){
                currentPatrol2Point += 1;
                if(currentPatrol2Point == patrolPoints2.Length && !attacking){
                    currentPatrol2Point = 0;
                }
            }
            agent.destination = patrolPoints2[currentPatrol2Point].position;
            agent.isStopped = attacking;

            // visual
            if(!attacking){
                AnimateMovement(patrolPoints2[currentPatrol2Point].position);
            }
        }

        // go back to sleeping spot
        if (currentPhase == 3){
           agent.destination = patrolPoints2[0].position;
           if(AtCurrentGoal(patrolPoints2[0].position)){
                // visual
                _animator.SetInteger("CurrentAnimation", 0);
           }
           else if(!attacking){
                AnimateMovement(patrolPoints2[0].position);
           }

           if(attacking){
                _animator.SetInteger("CurrentAnimation", 20);
           }
        }
    }

    /* Phase control */

    void OnEnable()
    {
        GameManagerMain.DimensionOne += ChangeBearPhase1;
        GameManagerMain.DimensionTwo += ChangeBearPhase2;
        GameManagerMain.DimensionThree += ChangeBearPhase3;

        // get current phase
    }
    void OnDisable()
    {
        GameManagerMain.DimensionOne -= ChangeBearPhase1;
        GameManagerMain.DimensionTwo -= ChangeBearPhase2;
        GameManagerMain.DimensionThree -= ChangeBearPhase3;
    }

    void ChangeBearPhase1()
    {
        // nav
        agent.isStopped = true;

        // visual
        _npcInterface.ChangeColor(1);
        _animator.SetInteger("CurrentAnimation", 0);
        _animator.SetInteger("CurrentAnimation", 10);

        // attack
        _bearAttack.enabled = false;

        // phase
        currentPhase = 1;
    }

    void ChangeBearPhase2()
    {
        // nav
        currentPatrol2Point = 0;
        agent.isStopped = false;

        // attack
        _bearAttack.enabled = true;

        // visual
        _npcInterface.ChangeColor(2);
        _animator.SetInteger("CurrentAnimation", 0);

        // phase
        currentPhase = 2;
    }

    void ChangeBearPhase3()
    {
        // visual
        _npcInterface.ChangeColor(3);

        // phase
        currentPhase = 3;
    }

    /* Attack */
    public void Attack(Vector3 target)
    {
        _animator.SetInteger("CurrentAnimation", 21);
        StartCoroutine(AttackRoutine(target));
        _animator.SetInteger("CurrentAnimation", 0);
    }

    IEnumerator AttackRoutine(Vector3 target)
    {
        while (!AtCurrentGoal(target)) {
            transform.position = Vector3.MoveTowards(transform.position, target, 10 * Time.deltaTime);
            yield return null;
        }
        attacking = false;
    }


    /* Navagation */

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

    /* Visuals */

    private void AnimateMovement(Vector3 target){
        if(target.z > transform.position.z){
            _animator.SetInteger("CurrentAnimation", 2);
        }
        else{
            _animator.SetInteger("CurrentAnimation", 1);
        }
    }
}
