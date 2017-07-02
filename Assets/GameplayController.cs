using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : Controller
{
    AllowedDirectsCalculator _allowedDirectsCalculator;
    FlipBehavior _flipBehavior;
    GameState _gameState;

    #region MonoBehavior Members
    private void Start()
    {
        _allowedDirectsCalculator = GetComponent<AllowedDirectsCalculator>();
        _flipBehavior = GetComponent<FlipBehavior>();
        _gameState = GetComponent<GameState>();

        Init();
    }

    private void Update()
    {
        OnKeyUp();
    }
    #endregion

    protected override void FlipOnAllowedDirect(KeyCode keyCode)
    {
        var direct = _keyCodeDirectMap[keyCode];

        var fields = _gameState.Fields;
        var allowedDirects = _allowedDirectsCalculator.CalculateAllowedDirects(fields);
        if (!allowedDirects[direct])
        {
            return;
        }

        _flipBehavior.Flip(fields, direct);
    }
}
