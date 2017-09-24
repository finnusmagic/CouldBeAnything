using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager_TogglePlayer : MonoBehaviour {

    public FirstPersonController playerController;
    GameManagerMaster gameManagerMaster;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.MenuToggleEvent += TogglePlayerController;
        gameManagerMaster.InventoryUIToggleEvent += TogglePlayerController;
    }

    void OnDisable()
    {
        gameManagerMaster.MenuToggleEvent -= TogglePlayerController;
        gameManagerMaster.InventoryUIToggleEvent -= TogglePlayerController;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManagerMaster>();
    }

    void TogglePlayerController()
    {
        if (playerController != null)
        {
            playerController.enabled = !playerController.enabled;
        }
    }
}
