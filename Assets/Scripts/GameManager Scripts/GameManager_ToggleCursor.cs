using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleCursor : MonoBehaviour {

    GameManager_Master gameManagerMaster;
    bool isCursorLocked = true;

	void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.MenuToggleEvent += ToggleCursorState;
        gameManagerMaster.InventoryUIToggleEvent += ToggleCursorState;
    }

    void OnDisable()
    {
        gameManagerMaster.MenuToggleEvent -= ToggleCursorState;
        gameManagerMaster.InventoryUIToggleEvent -= ToggleCursorState;
    }

    void Update()
    {
        CheckIfCursorShouldBeLocked();
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void ToggleCursorState()
    {
        isCursorLocked = !isCursorLocked;
    }

    void CheckIfCursorShouldBeLocked()
    {
        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
