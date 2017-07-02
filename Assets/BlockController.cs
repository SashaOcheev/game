using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : Controller
{
    AllowedDirectsCalculator _allowedDirectsCalculator;
    GameState _gameState;
    Block _block;

    #region MonoBehavior Members
    void Start()
    {
        _gameState = GetComponent<GameState>();
        _allowedDirectsCalculator = GetComponent<AllowedDirectsCalculator>();
        _block = GetComponent<Block>();
    }
    #endregion

    protected override void FlipOnAllowedDirect(KeyCode keyCode)
    {
        
    }
}
