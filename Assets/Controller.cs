using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    protected Dictionary<KeyCode, Direct> _keyCodeDirectMap;

    protected void Init()
    {
        _keyCodeDirectMap = new Dictionary<KeyCode, Direct>
        {
            { KeyCode.UpArrow, Direct.UP },
            { KeyCode.DownArrow, Direct.DOWN },
            { KeyCode.LeftArrow, Direct.LEFT },
            { KeyCode.RightArrow, Direct.RIGHT }
        };
    }

    protected void OnKeyUp()
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

    abstract protected void FlipOnAllowedDirect(KeyCode keyCode);
}
