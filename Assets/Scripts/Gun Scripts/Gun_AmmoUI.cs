﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun_AmmoUI : MonoBehaviour {

    public InputField currentAmmoField;
    public InputField carriedAmmoField;

    Gun_Master gunMaster;

	void OnEnable()
    {
        SetInitialReferences();
        gunMaster.EventAmmoChanged += UpdateAmmoUI;
    }

    void OnDisable()
    {
        gunMaster.EventAmmoChanged -= UpdateAmmoUI;
    }

	void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
    }

    void UpdateAmmoUI(int currentAmmo, int carriedAmmo)
    {
        if(currentAmmoField != null)
        {
            currentAmmoField.text = currentAmmo.ToString();
        }

        if (carriedAmmoField != null)
        {
            carriedAmmoField.text = carriedAmmo.ToString();
        }
    }
}
