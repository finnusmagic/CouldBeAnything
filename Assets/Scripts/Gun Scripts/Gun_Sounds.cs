using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Sounds : MonoBehaviour {

    Gun_Master gunMaster;
    Transform myTransform;

    public float shootVolume;
    public float reloadVolume;

    public AudioClip[] shootSound;
    public AudioClip reloadSound;

	void OnEnable()
    {
        SetInitialReferences();
        gunMaster.EventPlayerInput += PlayShootSound;
    }

    void OnDisable()
    {
        gunMaster.EventPlayerInput -= PlayShootSound;
    }

	void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
        myTransform = transform;
    }

    void PlayShootSound()
    {
        if(shootSound.Length > 0)
        {
            int index = Random.Range(0, shootSound.Length);
            AudioSource.PlayClipAtPoint(shootSound[index], myTransform.position, shootVolume);
        }
    }

    public void PlayReloadSound()
    {
        if (reloadSound != null)
        {
            AudioSource.PlayClipAtPoint(reloadSound, myTransform.position, reloadVolume);
        }
    }
}
