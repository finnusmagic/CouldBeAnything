using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_ToggleInventoryUI : MonoBehaviour {

    [Tooltip("Does this Gamemove has an Inventory? If so set this to true.")]
    public bool hasInventory;
    public GameObject inventoryUI;
    public string toggleInventoryButton;
    GameManager_Master gameManagerMaster;

    void Start()
    {
        SetInitialReferences();
    }

    void Update()
    {
        CheckForInventoryToggleUIRequest();
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManager_Master>();

        if (toggleInventoryButton == "")
        {
            Debug.LogWarning("The Inventory Toggle Button String has not been set in the Toggle Inventory UI Script.");
            this.enabled = false;
        }
    }

    void CheckForInventoryToggleUIRequest()
    {
        if (Input.GetButtonUp(toggleInventoryButton) && !gameManagerMaster.isMenuOn && !gameManagerMaster.isGameOver && hasInventory)
        {
            ToggleInventoryUI();
        }
    }

    public void ToggleInventoryUI()
    {
        if (inventoryUI != null)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            gameManagerMaster.isInventoryUIOn = !gameManagerMaster.isInventoryUIOn;
            gameManagerMaster.CallInventoryUIToggle();
        }
    }

}
