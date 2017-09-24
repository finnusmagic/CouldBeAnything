using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Sounds : MonoBehaviour {

    Item_Master itemMaster;
    public float defaultVolume;
    public AudioClip throwSound;
    public AudioClip pickupSound;

	void OnEnable() 
	{
        SetInitialReferences();
        itemMaster.EventObjectThrow += PlayThrowSound;
        itemMaster.EventObjectPickup += PlayPickupSound;
	}

	void OnDisable() 
	{
        itemMaster.EventObjectThrow -= PlayThrowSound;
        itemMaster.EventObjectPickup -= PlayPickupSound;
    }

	void SetInitialReferences() 
	{
        itemMaster = GetComponent<Item_Master>();
	}

    void PlayThrowSound()
    {
        if (throwSound != null)
        {
            AudioSource.PlayClipAtPoint(throwSound, transform.position, defaultVolume);
        }
    }

    void PlayPickupSound()
    {
        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position, defaultVolume);
        }
    }
}
