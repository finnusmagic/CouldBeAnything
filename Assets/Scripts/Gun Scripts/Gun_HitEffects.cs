using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_HitEffects : MonoBehaviour {

    Gun_Master gunMaster;

    public GameObject defaultHitEffect;
    public GameObject enemyHitEffect;

	void OnEnable()
    {
        SetInitialReferences();
        gunMaster.EventShotDefault += SpawnDefaultHitEffect;
        gunMaster.EventShotEnemy += SpawnEnemyHitEffect;
    }

    void OnDisable()
    {
        gunMaster.EventShotDefault -= SpawnDefaultHitEffect;
        gunMaster.EventShotEnemy -= SpawnEnemyHitEffect;
    }

	void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
    }

    void SpawnDefaultHitEffect(Vector3 hitPos, Transform hitTrans)
    {
        if (defaultHitEffect != null)
        {
            Instantiate(defaultHitEffect, hitPos, Quaternion.identity);
        }
    }

    void SpawnEnemyHitEffect(Vector3 hitPos, Transform hitTrans)
    {
        if(enemyHitEffect != null)
        {
            Instantiate(enemyHitEffect, hitPos, Quaternion.identity);
        }
    }
}
