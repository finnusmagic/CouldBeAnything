﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_RagdollActivation : MonoBehaviour {

    Enemy_Master enemyMaster;
    Collider myCollider;
    Rigidbody myRigidbody;

	void OnEnable()
    {
        SetInitialReferences();
        enemyMaster.EventEnemyDie += ActivateRagdoll;
    }

    void OnDisable()
    {
        enemyMaster.EventEnemyDie -= ActivateRagdoll;
    }

	void SetInitialReferences()
    {
        enemyMaster = transform.root.GetComponent<Enemy_Master>();

        if (GetComponent<Collider>() != null)
        {
            myCollider = GetComponent<Collider>();
        }

        if (GetComponent<Rigidbody>() != null)
        {
            myRigidbody = GetComponent<Rigidbody>();
        }
    }

    void ActivateRagdoll()
    {
        if (myRigidbody != null)
        {
            myRigidbody.isKinematic = false;
            myRigidbody.useGravity = true;
        }

        if (myCollider != null)
        {
            myCollider.isTrigger = false;
            myCollider.enabled = true;
        }
    }
}
