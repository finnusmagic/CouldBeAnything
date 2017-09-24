using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour {

    Item_Master itemMaster;
    Transform myTransform;

    void OnEnable()
    {
        SetInititalReferences();
        itemMaster.EventPickupAction += CarryOutPickupActions;
    }

    void OnDisable()
    {
        itemMaster.EventPickupAction -= CarryOutPickupActions;
    }

    void SetInititalReferences()
    {
        itemMaster = GetComponent<Item_Master>();
    }


    void CarryOutPickupActions(Transform tParent)
    {
        transform.SetParent(tParent);
        itemMaster.CallEventObjectPickup();
        transform.gameObject.SetActive(false);
    }
}
