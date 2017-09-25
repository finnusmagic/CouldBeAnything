using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Reset : MonoBehaviour {

    Gun_Master gunMaster;
    Item_Master itemMaster;

	void OnEnable()
    {
        SetInitialReferences();

        if(itemMaster != null)
        {
            itemMaster.EventObjectThrow += ResetGun;
        }
    }

    void OnDisable()
    {
        if (itemMaster != null)
        {
            itemMaster.EventObjectThrow -= ResetGun;
        }
    }

	void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
        
        if(GetComponent<Item_Master>() != null)
        {
            itemMaster = GetComponent<Item_Master>();
        }
    }

    void ResetGun()
    {
        gunMaster.CallEventRequestGunReset();
    }
}
