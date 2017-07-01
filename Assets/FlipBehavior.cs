using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlipBehavior : MonoBehaviour
{
    private AllowedDirectsCalculator _allowedDirectsCalculator;

    private void Start()
    {
        _allowedDirectsCalculator = GetComponent<AllowedDirectsCalculator>();
    }

    public void Flip(Field[] fields, List<Field> currentFields, Direct direct)
    {
        var position = GetPosition(currentFields);
        var allowedDirects = _allowedDirectsCalculator.CalculateAllowedDirects(fields, currentFields, position);
        PrintCurrentAndAllowed(position, allowedDirects);
    }

    private Position GetPosition(List<Field> currentFields)
    {
        if (currentFields.Count < 1 || currentFields.Count > 2)
        {
            throw new System.Exception(String.Format("current fields count is {0}", currentFields.Count));
        }

        if (currentFields.Count == 1)
        {
            return Position.Y;
        }
        if (currentFields[0].Row == currentFields[1].Row)
        {
            return Position.X;
        }
        if (currentFields[0].Col == currentFields[1].Col)
        {
            return Position.Z;
        }
        throw new Exception("Undefined current fields position");
    }

    private void PrintCurrentAndAllowed(Position position, Dictionary<Direct, bool> allowedPositions)
    {
        var positionName = new Dictionary<Position, string>
        {
            { Position.X, "X" },
            { Position.Y, "Y" },
            { Position.Z, "Z" }
        };

        Dictionary<Direct, string> directName = new Dictionary<Direct, string>
        {
            { Direct.DOWN, "DOWN" },
            { Direct.UP, "UP" },
            { Direct.LEFT, "LEFT" },
            { Direct.RIGHT, "RIGHT" }
        };

        var allowedToStringList = allowedPositions.Where(x => x.Value).Select(x => directName[x.Key]).ToArray();

        var allowedString = String.Join(", ", allowedToStringList);

        Debug.LogFormat("Position = {0}, Allowed: {1}", positionName[position], allowedString);
    }
}
