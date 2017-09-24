using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {

    GameManager_Master gameManagerMaster;
    Player_Master playerMaster;

    public int playerHealth;
    public Text healthText;

	void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            playerMaster.CallEventPlayerHealthDeduction(10);
        }
    }

	void OnEnable()
    {
        SetInitialReferences();
        SetUI();
        playerMaster.EventPlayerHealthDeduction += DeductHealth;
        playerMaster.EventPlayerHealthIncrease += IncreaseHealth;
    }

    void OnDisable()
    {
        playerMaster.EventPlayerHealthDeduction -= DeductHealth;
        playerMaster.EventPlayerHealthIncrease -= IncreaseHealth;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
        playerMaster = GetComponent<Player_Master>();
    }

    void DeductHealth (int healthChange)
    {
        playerHealth -= healthChange;

        if (playerHealth <= 0)
        {
            playerHealth = 0;
            gameManagerMaster.CallEventGameOver();
        }

        SetUI();
    }

    void IncreaseHealth (int healthChange)
    {
        playerHealth += healthChange;

        if (playerHealth > 100)
        {
            playerHealth = 100;
        }

        SetUI();
    }

    void SetUI()
    {
        if (healthText != null)
        {
            healthText.text = playerHealth.ToString();
        }
    }
}
