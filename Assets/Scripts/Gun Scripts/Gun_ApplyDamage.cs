using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_ApplyDamage : MonoBehaviour {

    Gun_Master gunMaster;

    public int damage = 10;

	void OnEnable()
    {
        SetInitialReferences();
        gunMaster.EventShotEnemy += ApplyDamage;
    }

    void OnDisable()
    {
        gunMaster.EventShotEnemy -= ApplyDamage;
    }

	void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
    }

    void ApplyDamage(Vector3 hitPos, Transform hitTransform)
    {
        if(hitTransform.GetComponent<Enemy_TakeDamage>() != null)
        {
            hitTransform.GetComponent<Enemy_TakeDamage>().ProcessDamage(damage);
        }
    }
}
