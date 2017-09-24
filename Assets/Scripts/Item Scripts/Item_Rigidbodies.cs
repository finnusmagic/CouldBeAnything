﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Rigidbodies : MonoBehaviour {

    Item_Master itemMaster;

    public Rigidbody[] rigidBodies;


	void OnEnable() 
	{
        SetInitialReferences();
        CheckIfStartsInInventory();
        itemMaster.EventObjectThrow += SetIsKinematicToFalse;
        itemMaster.EventObjectPickup += SetIsKinematicToTrue;
    }

	void OnDisable() 
	{
        itemMaster.EventObjectThrow -= SetIsKinematicToFalse;
        itemMaster.EventObjectPickup -= SetIsKinematicToTrue;
    }

	void SetInitialReferences() 
	{
        itemMaster = GetComponent<Item_Master>();
	}

    void CheckIfStartsInInventory()
    {
        if (transform.root.CompareTag(GameManager_References._playerTag))
        {
            SetIsKinematicToTrue();
        }
    }

    void SetIsKinematicToTrue()
    {
        if (rigidBodies.Length > 0)
        {
            foreach (Rigidbody rBody in rigidBodies)
            {
                rBody.isKinematic = true;
            }
        }
    }

    void SetIsKinematicToFalse()
    {
        if (rigidBodies.Length > 0)
        {
            foreach (Rigidbody rBody in rigidBodies)
            {
                rBody.isKinematic = false;
            }
        }
    }
}
