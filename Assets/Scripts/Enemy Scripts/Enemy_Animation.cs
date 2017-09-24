﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animation : MonoBehaviour {

    Enemy_Master enemyMaster;
    Animator myAnimator;


	void OnEnable() 
	{
        SetInitialReferences();
        enemyMaster.EventEnemyDie += DisableAnimator;
        enemyMaster.EventEnemyWalking += SetAnimationToWalk;
        enemyMaster.EventEnemyReachedNavTarget += SetAnimationToIdle;
        enemyMaster.EventEnemyAttack += SetAnimationToAttack;
        enemyMaster.EventEnemyDeductHealth += SetAnimationToStruck;
    }

	void OnDisable() 
	{
        enemyMaster.EventEnemyDie -= DisableAnimator;
        enemyMaster.EventEnemyWalking -= SetAnimationToWalk;
        enemyMaster.EventEnemyReachedNavTarget -= SetAnimationToIdle;
        enemyMaster.EventEnemyAttack -= SetAnimationToAttack;
        enemyMaster.EventEnemyDeductHealth -= SetAnimationToStruck;
    }

	void SetInitialReferences() 
	{
        enemyMaster = GetComponent<Enemy_Master>();
        if (GetComponent<Animator>() != null)
        {
            myAnimator = GetComponent<Animator>();
        }
    }

    void SetAnimationToWalk()
    {
        if (myAnimator != null)
        {
            if (myAnimator.enabled)
            {
                myAnimator.SetBool("isPursuing", true);
            }
        }
    }

    void SetAnimationToIdle()
    {
        if (myAnimator != null)
        {
            if (myAnimator.enabled)
            {
                myAnimator.SetBool("isPursuing", false);
            }
        }
    }

    void SetAnimationToAttack()
    {
        if (myAnimator != null)
        {
            if (myAnimator.enabled)
            {
                myAnimator.SetTrigger("Attack");
            }
        }
    }

    void SetAnimationToStruck(int dummy)
    {
        if (myAnimator != null)
        {
            if (myAnimator.enabled)
            {
                myAnimator.SetTrigger("Struck");
            }
        }
    }

    void DisableAnimator()
    {
        if (myAnimator != null)
        {
            myAnimator.enabled = false;
        }
    }
}
