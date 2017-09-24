using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_NavWander : MonoBehaviour {

    Enemy_Master enemyMaster;
    NavMeshAgent myNavMeshAgent;
    float checkRate;
    float nextCheck;
    Transform myTransform;
    float wanderRange = 10f;
    NavMeshHit navHit;
    Vector3 wanderTarget;

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
            CheckIfShouldWander();
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
        myTransform = transform;
    }

    void CheckIfShouldWander()
    {
        if (enemyMaster.myTarget == null && !enemyMaster.isOnRoot && !enemyMaster.isNavPaused)
        {
            if (RandomWanderTarget(myTransform.position, wanderRange, out wanderTarget))
            {
                myNavMeshAgent.SetDestination(wanderTarget);
                enemyMaster.isOnRoot = true;
                enemyMaster.CallEventEnemyWalking();
            }
        }
    }

    bool RandomWanderTarget(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;

        if (NavMesh.SamplePosition(randomPoint, out navHit, 1.0f, NavMesh.AllAreas))
        {
            result = navHit.position;
            return true;
        }
        else
        {
            result = center;
            return false;
        }
    }

    void DisableThis()
    {
        this.enabled = false;
    }
}
