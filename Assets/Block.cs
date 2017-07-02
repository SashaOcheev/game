using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    BlockFlipCalculator _blockFlipCalculator;

    #region MonoBehavior Members
    private void Start()
    {
        _blockFlipCalculator = GetComponent<BlockFlipCalculator>();
    }
    #endregion

    public void FlipUp()
    {
        _blockFlipCalculator.FlipUp();
    }

    public void FlipDown()
    {
        _blockFlipCalculator.FlipDown();
    }

    public void FlipLeft()
    {
        _blockFlipCalculator.FlipLeft();
    }

    public void FlipRight()
    {
        _blockFlipCalculator.FlipRight();
    }
}
