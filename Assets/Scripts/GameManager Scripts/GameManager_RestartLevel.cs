using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_RestartLevel : MonoBehaviour {

    GameManagerMaster gameManagerMaster;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.RestartLevelEvent += RestartLevel;
    }

    void OnDisable()
    {
        gameManagerMaster.RestartLevelEvent -= RestartLevel;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManagerMaster>();
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
