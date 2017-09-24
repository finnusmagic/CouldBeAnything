using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_TogglePause : MonoBehaviour {

    GameManagerMaster gameManagerMaster;

    bool isPaused;

	void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.MenuToggleEvent += TogglePause;
        gameManagerMaster.InventoryUIToggleEvent += TogglePause;
    }

    void OnDisable()
    {
        gameManagerMaster.MenuToggleEvent -= TogglePause;
        gameManagerMaster.InventoryUIToggleEvent -= TogglePause;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManagerMaster>();
    }

    void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
