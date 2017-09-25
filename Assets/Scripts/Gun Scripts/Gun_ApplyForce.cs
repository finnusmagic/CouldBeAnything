using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_ApplyForce : MonoBehaviour {

    Gun_Master gunMaster;
    Transform myTransform;

    public float forceToApply = 300f;

	void OnEnable () 
	{
        SetInitialReferences();
        gunMaster.EventShotDefault += ApplyForce;
	}

	void OnDisable () 
	{
        gunMaster.EventShotDefault -= ApplyForce;
    }

	void SetInitialReferences () 
	{
        gunMaster = GetComponent<Gun_Master>();
        myTransform = transform;
	}

    void ApplyForce(Vector3 hitPos, Transform hitTrans)
    {
        if(hitTrans.GetComponent<Rigidbody>() != null)
        {
            hitTrans.GetComponent<Rigidbody>().AddForce(myTransform.forward * forceToApply, ForceMode.Impulse);
        }
    }
}
