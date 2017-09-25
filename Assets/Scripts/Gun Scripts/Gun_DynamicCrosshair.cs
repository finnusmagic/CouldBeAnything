using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_DynamicCrosshair : MonoBehaviour {

    Gun_Master gunMaster;

    public Transform canvasDynamicCrosshair;
    public Animator crossHairAnimator;
    public string weaponCameraName;

    Transform playerTransform;
    Transform weaponCamera;
    float playerSpeed;
    float nextCaptureTime;
    float captureInterval = 0.5f;
    Vector3 lastPosition;

	void Start () 
	{
        SetInitialReferences();
	}
	
	void Update () 
	{
        CapturePlayerSpeed();
        ApplySpeedToAnimation();
	}

	void SetInitialReferences()
    {
        gunMaster = GetComponent<Gun_Master>();
        playerTransform = GameManager_References._player.transform;
        FindWeaponCamera(playerTransform);
        SetCameraOnDynamicCrosshairCanvas();
        SetPlaneDistanceOnDynamicCrosshairCanvas();
    }

    void CapturePlayerSpeed()
    {
        if(Time.time > nextCaptureTime)
        {
            nextCaptureTime = Time.time + captureInterval;
            playerSpeed = (playerTransform.position - lastPosition).magnitude / captureInterval;
            lastPosition = playerTransform.position;
            gunMaster.CallEventSpeedCaptured(playerSpeed);
        }
    }

    void ApplySpeedToAnimation()
    {
        if(crossHairAnimator != null)
        {
            crossHairAnimator.SetFloat("Speed", playerSpeed);
        }
    }

    void FindWeaponCamera(Transform transformToSearchThrough)
    {
        if(transformToSearchThrough != null)
        {
            if(transformToSearchThrough.name == weaponCameraName)
            {
                weaponCamera = transformToSearchThrough;
                return;
            }

            foreach (Transform child in transformToSearchThrough)
            {
                FindWeaponCamera(child);
            }
        }
    }

    void SetCameraOnDynamicCrosshairCanvas()
    {
        if(canvasDynamicCrosshair != null && weaponCamera != null)
        {
            canvasDynamicCrosshair.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
            canvasDynamicCrosshair.GetComponent<Canvas>().worldCamera = weaponCamera.GetComponent<Camera>();
        }
    }

    void SetPlaneDistanceOnDynamicCrosshairCanvas()
    {
        if(canvasDynamicCrosshair != null)
        {
            canvasDynamicCrosshair.GetComponent<Canvas>().planeDistance = 1;
        }
    }
}
