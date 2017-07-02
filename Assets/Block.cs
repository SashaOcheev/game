using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    GameState _gameState;
    CurrentFieldsCalculator _currentFieldsCalculator;

    private void Start()
    {
        _gameState = GetComponent<GameState>();

    }
}
