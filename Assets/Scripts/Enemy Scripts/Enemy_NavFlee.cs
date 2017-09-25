using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavFlee : MonoBehaviour {

    public bool isFleeing;
    public Transform fleeTarget;
    public float fleeRange = 25;

    Enemy_Master enemyMaster;
    NavMeshAgent myNavMeshAgent;
    NavMeshHit navHit;

    Transform myTransform;
    Vector3 runPosition;
    Vector3 directionToPlayer;

    float checkRate;
    float nextCheck;

	void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyDie += DisableThis;
        enemyMaster.EventEnemySetNavTarget += SetFleeTarget;
        enemyMaster.EventEnemyHealthLow += ShouldFlee;
        enemyMaster.EventEnemyHealthRecovered += ShouldStopFleeing;
    }

    void OnDisable()
    {
        enemyMaster.EventEnemyDie -= DisableThis;
        enemyMaster.EventEnemySetNavTarget -= SetFleeTarget;
        enemyMaster.EventEnemyHealthLow -= ShouldFlee;
        enemyMaster.EventEnemyHealthRecovered -= ShouldStopFleeing;
    }
	
	void Update () 
	{
		if (Time.time > nextCheck)
        {
            nextCheck = Time.time + checkRate;

            CheckIfShouldFlee();
        }
	}

	void SetInitialReferences()
    {
        enemyMaster = GetComponent<Enemy_Master>();
        myTransform = transform;

        if(GetComponent<NavMeshAgent>() != null)
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
        }

        checkRate = Random.Range(0.3f, 0.4f);
    }

    void SetFleeTarget (Transform target)
    {
        fleeTarget = target;
    }

    void ShouldFlee()
    {
        isFleeing = true;

        if (GetComponent<Enemy_NavPursuit>() != null)
        {
            GetComponent<Enemy_NavPursuit>().enabled = false;
        }
    }

    void ShouldStopFleeing()
    {
        isFleeing = false;

        if(GetComponent<Enemy_NavPursuit>() != null)
        {
            GetComponent<Enemy_NavPursuit>().enabled = true;
        }
    }

    void CheckIfShouldFlee()
    {
        if (isFleeing)
        {
            if (fleeTarget != null && !enemyMaster.isOnRoot && !enemyMaster.isNavPaused)
            {
                if (FleeTarget(out runPosition) && Vector3.Distance(myTransform.position, fleeTarget.position) < fleeRange)
                {
                    myNavMeshAgent.SetDestination(runPosition);
                    enemyMaster.CallEventEnemyWalking();
                    enemyMaster.isOnRoot = true;
                }
            }
        }
    }

    bool FleeTarget(out Vector3 result)
    {
        directionToPlayer = myTransform.position - fleeTarget.position;
        Vector3 checkPos = myTransform.position + directionToPlayer;

        if (NavMesh.SamplePosition(checkPos, out navHit, 1.0f, NavMesh.AllAreas))
        {
            result = navHit.position;
            return true;
        }
        else
        {
            result = myTransform.position;
            return false;
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
