using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DetectItem : MonoBehaviour {

    public LayerMask layerToDetect;
    public Transform rayTransformPivot;
    public string buttonPickup;

    Transform itemAvailableForPickup;
    RaycastHit hit;

    float detectRange = 3f;
    float detectRadius = 0.7f;
    bool itemInRange;

    float labelWidth = 200f;
    float labelHeight = 50f;

    void Update()
    {
        CastRayForDetectingItems();
        CheckForItemPickupAttempt();
    }

    void CastRayForDetectingItems()
    {
        if (Physics.SphereCast(rayTransformPivot.position, detectRadius, rayTransformPivot.forward, out hit, detectRange, layerToDetect))
        {
            itemAvailableForPickup = hit.transform;
            itemInRange = true;
        }
        else
        {
            itemInRange = false;
        }
    }

    void CheckForItemPickupAttempt()
    {
        if (Input.GetButtonDown(buttonPickup) && Time.timeScale > 0 && itemInRange && itemAvailableForPickup.root.tag != GameManager_References._playerTag)
        {
            itemAvailableForPickup.GetComponent<Item_Master>().CallEventPickupAction(rayTransformPivot);
        }
    }

    void OnGUI()
    {
        if (itemInRange && itemAvailableForPickup != null)
        {
            GUI.Label(new Rect(Screen.width / 2 - labelWidth / 2, Screen.height / 2, labelWidth, labelHeight), itemAvailableForPickup.name);
        }
    }
}
