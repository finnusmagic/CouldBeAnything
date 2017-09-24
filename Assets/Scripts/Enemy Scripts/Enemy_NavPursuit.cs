using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavPursuit : MonoBehaviour {

    Enemy_Master enemyMaster;
    NavMeshAgent myNavMeshAgent;
    float checkRate;
    float nextCheck;


	void OnEnable() 
	{
        SetInitialReferences();
        enemyMaster.EventEnemyDie += DisableThis;
	}

	void OnDisable() 
	{
		
	}

    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            TryToChaseTarget();
        }
    }

    void SetInitialReferences() 
	{
        enemyMaster = GetComponent<Enemy_Master>();

        if (GetComponent<NavMeshAgent>() != null)
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        checkRate = Random.Range(0.1f, 0.2f);
	}

    void TryToChaseTarget()
    {
        if(enemyMaster.myTarget != null && myNavMeshAgent != null && !enemyMaster.isNavPaused)
        {
            myNavMeshAgent.SetDestination(enemyMaster.myTarget.position);

            if(myNavMeshAgent.remainingDistance > myNavMeshAgent.stoppingDistance)
            {
                enemyMaster.CallEventEnemyWalking();
                enemyMaster.isOnRoot = true;
            }
        }
    }

    void DisableThis()
    {
        if (myNavMeshAgent != null)
        {
            myNavMeshAgent.enabled = false;
        }

        this.enabled = false;
    }
}
