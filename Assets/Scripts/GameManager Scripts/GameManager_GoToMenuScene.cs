using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_GoToMenuScene : MonoBehaviour {

    GameManagerMaster gameManagerMaster;

    void OnEnable()
    {
        SetInitialReferences();
        gameManagerMaster.GoToMenuSceneEvent += GoToMenuScene;
    }

    void OnDisable()
    {
        gameManagerMaster.GoToMenuSceneEvent -= GoToMenuScene;
    }

    void SetInitialReferences()
    {
        gameManagerMaster = GetComponent<GameManagerMaster>();
    }

    void GoToMenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
