﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_References : MonoBehaviour {

    public string playerTag;
    public static string _playerTag;

    public string enemyTag;
    public static string _enemyTag;

    public static GameObject _player;

    void OnEnable()
    {
        if (playerTag == "")
        {
            Debug.LogWarning("Please type in the Name of the Player Tag in the GameManager References Script.");
        }
        if (enemyTag == "")
        {
            Debug.LogWarning("Player type in the Name of the Enemy Tag in the GameManager References Script.");
        }

        _playerTag = playerTag;
        _enemyTag = enemyTag;

        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }
}
