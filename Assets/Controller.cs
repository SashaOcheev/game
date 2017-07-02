using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    protected void OnKeyUp()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            FlipOnAllowedDirect(Direct.UP);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            FlipOnAllowedDirect(Direct.DOWN);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            FlipOnAllowedDirect(Direct.LEFT);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            FlipOnAllowedDirect(Direct.RIGHT);
        }
    }

    abstract protected void FlipOnAllowedDirect(Direct direct);
}
