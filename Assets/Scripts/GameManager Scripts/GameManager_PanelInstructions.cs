using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_PanelInstructions : MonoBehaviour {

    public GameObject panelInstructions;
    GameManager_Master gameManagerMaster;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.GameOverEvent += TurnOffPanelIntructions;
    }

    void OnDisable()
    {
        gameManagerMaster.GameOverEvent -= TurnOffPanelIntructions;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();
    }

    void TurnOffPanelIntructions()
    {
        if (panelInstructions != null)
        {
            panelInstructions.SetActive(false);
        }
    }
}
