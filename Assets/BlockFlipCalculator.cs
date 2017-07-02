using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFlipCalculator : MonoBehaviour
{
    GameState _gameState;
    PositionCalculator _positionCalculator;
    [SerializeField]
    private float speed;

    #region MonoBehaviour Members
    void Start()
    {
        _positionCalculator = GetComponent<PositionCalculator>();
        _gameState = GetComponent<GameState>();
    }
    #endregion

    //transform.Translate(Vector3.forward * speed * zPos * Time.deltaTime);
    public BlockFlipData FlipUp()
    {
        var position = _positionCalculator.CalculatePosition(_gameState.Fields);
        var result = new BlockFlipData();
        switch (position)
        {
            case Position.X:
                result.Rotation += new Vector3(-90f, 0f, 0f);
                result.Translation += new Vector3(0f, 0f, -1f);
                break;
            case Position.Y:

                break;
            case Position.Z:

                break;
        }

        return result;
    }

    public BlockFlipData FlipDown()
    {
        var position = _positionCalculator.CalculatePosition(_gameState.Fields);
        var result = new BlockFlipData();
        switch (position)
        {
            case Position.X:
                result.Rotation += new Vector3(90f, 0f, 0f);
                result.Translation += new Vector3(0f, 0f, 1f);
                break;
            case Position.Y:

                break;
            case Position.Z:

                break;
        }

        return result;
    }

    public BlockFlipData FlipLeft()
    {
        var position = _positionCalculator.CalculatePosition(_gameState.Fields);
        var result = new BlockFlipData();
        switch (position)
        {
            case Position.X:
                result.Rotation += new Vector3(0f, 0f, -90f);
                result.Translation += new Vector3(-1f, 0f, 0f);
                break;
            case Position.Y:

                break;
            case Position.Z:

                break;
        }

        return result;
    }

    public BlockFlipData FlipRight()
    {
        var position = _positionCalculator.CalculatePosition(_gameState.Fields);
        var result = new BlockFlipData();
        switch (position)
        {
            case Position.X:
                result.Rotation += new Vector3(0f, 0f, 90f);
                result.Translation += new Vector3(-1f, 0f, 0f);
                break;
            case Position.Y:

                break;
            case Position.Z:

                break;
        }

        return result;
    }
}
