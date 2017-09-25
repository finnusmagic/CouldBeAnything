﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_StandartInput : MonoBehaviour {

    Gun_Master gunMaster;
    float nextAttack;
    Transform myTransform;
    bool isBurstFireActive;

    public float attackRate = 0.5f;
    public bool isAutomatic;
    public bool hasBurstFire;

    public string attackButtonName;
    public string reloadButtonName;
    public string burstFireButtonName;

	void OnEnable()
    {
		
    }

    void OnDisable()
    {
        
    }

	void Start () 
	{
        SetInitialReferences();
	}
	
	void Update () 
	{
        CheckIfWeaponShouldAttack();
        CheckForReloadRequest();
        CheckForBurstFireToggle();
	}

	void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
        myTransform = transform;
        gunMaster.isGunLoaded = true;
    }

    void CheckIfWeaponShouldAttack()
    {
        if (Time.time > nextAttack && Time.timeScale > 0 && myTransform.root.CompareTag(GameManager_References._playerTag))
        {
            if (isAutomatic && !isBurstFireActive)
            {
                if (Input.GetButton(attackButtonName))
                {
                    AttemptAttack();
                }
            }
            else if (isAutomatic && isBurstFireActive)
            {
                if (Input.GetButtonDown(attackButtonName))
                {
                    StartCoroutine(RunBurstFire());
                }
            }
            else if(!isAutomatic)
            {
                if(Input.GetButtonDown(attackButtonName))
                {
                    AttemptAttack();
                }
            }
        }
    }

    void AttemptAttack()
    {
        nextAttack = Time.time + attackRate;

        if (gunMaster.isGunLoaded)
        {
            gunMaster.CallEventPlayerInput();
        }
        else
        {
            gunMaster.CallEventGunNotUsable();
        }
    }

    void CheckForReloadRequest()
    {
        if (Input.GetButtonDown(reloadButtonName) && Time.timeScale > 0 && myTransform.root.CompareTag(GameManager_References._playerTag))
        {
            gunMaster.CallEventRequestReload();
        }
    }

    void CheckForBurstFireToggle()
    {
        if (Input.GetButtonDown(burstFireButtonName) && Time.timeScale > 0 && myTransform.root.CompareTag(GameManager_References._playerTag))
        {
            isBurstFireActive = !isBurstFireActive;
            gunMaster.CallEventToggleBurstFire();
        }
    }

    IEnumerator RunBurstFire()
    {
        AttemptAttack();
        yield return new WaitForSeconds(attackRate);
        AttemptAttack();
        yield return new WaitForSeconds(attackRate);
        AttemptAttack();
    }
}
