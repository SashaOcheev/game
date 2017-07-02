using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    Dictionary<KeyCode, Direct> _keyCodeDirectMap;
    AllowedDirectsCalculator _allowedDirectsCalculator;
    FlipBehavior _flipBehavior;
    GameState _gameState;

    #region MonoBehavior Members
    private void Start()
    {
        _allowedDirectsCalculator = GetComponent<AllowedDirectsCalculator>();
        _flipBehavior = GetComponent<FlipBehavior>();
        _gameState = GetComponent<GameState>();

        _keyCodeDirectMap = new Dictionary<KeyCode, Direct>
        {
            { KeyCode.UpArrow, Direct.UP },
            { KeyCode.DownArrow, Direct.DOWN },
            { KeyCode.LeftArrow, Direct.LEFT },
            { KeyCode.RightArrow, Direct.RIGHT }
        };
    }

    private void Update()
    {
        OnKeyUp();
    }
    #endregion

    private void OnKeyUp()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            FlipOnAllowedDirect(KeyCode.UpArrow);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            FlipOnAllowedDirect(KeyCode.DownArrow);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            FlipOnAllowedDirect(KeyCode.LeftArrow);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            FlipOnAllowedDirect(KeyCode.RightArrow);
        }
    }

    private void FlipOnAllowedDirect(KeyCode keyCode)
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
