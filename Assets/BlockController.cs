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
    private void Start()
    {
        _gameState = GetComponent<GameState>();
        _allowedDirectsCalculator = GetComponent<AllowedDirectsCalculator>();
        _block = GetComponent<Block>();
    }

    private void Update()
    {
        OnKeyUp();
    }
    #endregion

    protected override void FlipOnAllowedDirect(Direct direct)
    {
        switch (direct)
        {
            case Direct.LEFT:
                _block.FlipLeft();
                break;
            case Direct.RIGHT:
                _block.FlipRight();
                break;
            case Direct.UP:
                _block.FlipUp();
                break;
            case Direct.DOWN:
                _block.FlipDown();
                break;
        }
    }
}
