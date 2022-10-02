using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearManager : MonoBehaviour
{
    public NPCInterface _npcInterface;
    public Transform[] patrolPoints2;

    public bool attacking;

    // temp
    public int currentPhase;
    private int currentPatrol2Point;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start() 
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update () 
    { 
        if (currentPhase == 1){
           
        }
        if (currentPhase == 2){
            if(AtCurrentGoal(patrolPoints2[currentPatrol2Point])){
                // wait
                currentPatrol2Point += 1;
                if(currentPatrol2Point == patrolPoints2.Length && !attacking){
                    currentPatrol2Point = 0;
                }
            }
            agent.destination = patrolPoints2[currentPatrol2Point].position;
            agent.isStopped = attacking;
        }
        if (currentPhase == 3){
           
        }
    }

    void OnEnable()
    {
        GameManagerMain.DimensionOne += ChangeBearPhase1;
        GameManagerMain.DimensionTwo += ChangeBearPhase2;
        GameManagerMain.DimensionThree += ChangeBearPhase3;
    }
    void OnDisable()
    {
        GameManagerMain.DimensionOne -= ChangeBearPhase1;
        GameManagerMain.DimensionTwo -= ChangeBearPhase2;
        GameManagerMain.DimensionThree -= ChangeBearPhase3;
    }

    /*  */
    void ChangeBearPhase1()
    {
       _npcInterface.ChangeColor(1);

        currentPhase = 1;
    }

    void ChangeBearPhase2()
    {
        currentPatrol2Point = 0;
        _npcInterface.ChangeColor(2);

        currentPhase = 2;
    }

    void ChangeBearPhase3()
    {
        _npcInterface.ChangeColor(2);

        currentPhase = 3;
    }

    /* Navagation */
    private void NextParolPoint()
    {
        
    }

    private bool AtCurrentGoal(Transform goal)
    {
        float dist = Vector3.Distance(goal.position, transform.position);
        if(dist < 1.0f)
        {
            return true;
        }
        else {
            return false;
        }
    }
}
