using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavDestinationReached : MonoBehaviour {


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
        enemyMaster.EventEnemyDie -= DisableThis;
    }

    void Update()
    {
        if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;
            CheckIfDestinationReached();
        }
    }

    void SetInitialReferences()
    {
        enemyMaster = GetComponent<Enemy_Master>();

        if (GetComponent<NavMeshAgent>() != null)
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        checkRate = Random.Range(0.3f, 0.4f);
    }

    void CheckIfDestinationReached()
    {
        if (enemyMaster.isOnRoot)
        {
            if(myNavMeshAgent.remainingDistance < myNavMeshAgent.stoppingDistance)
            {
                enemyMaster.isOnRoot = false;
                enemyMaster.CallEventEnemyReachedNavTarget();
            }
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
