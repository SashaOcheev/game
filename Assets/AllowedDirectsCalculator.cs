using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllowedDirectsCalculator : MonoBehaviour
{
    CurrentFieldsCalculator _currentFieldsCalculator;
    PositionCalculator _positionCalculator;

    #region MonoBehavior Members
    private void Start()
    {
        _currentFieldsCalculator = GetComponent<CurrentFieldsCalculator>();
        _positionCalculator = GetComponent<PositionCalculator>();
    }
    #endregion

    public Dictionary<Direct, bool> CalculateAllowedDirects(List<Field> fields)
    {
        var currentFields = _currentFieldsCalculator.CalculateCurrentFields(fields);
        var currentPosition = _positionCalculator.CalculatePosition(fields);

        if (currentPosition == Position.X)
        {
            return CalculateAllowedForX(fields, currentFields);
        }
        if (currentPosition == Position.Y)
        {
            return CalculateAllowedForY(fields, currentFields);
        }
        if (currentPosition == Position.Z)
        {
            return CalculateAllowedForZ(fields, currentFields);
        }
        throw new Exception("CalculateAllowedDirects: current fields has no position");
    }

    private Dictionary<Direct, bool> CalculateAllowedForX(List<Field> fields, List<Field> currentFields)
    {
        var allowedDirects = GetAllFalse();
        var left = currentFields.First();
        var right = currentFields.Last();
        if (left.Col > right.Col)
        {
            left = currentFields.Last();
            right = currentFields.First();
        }

        if (fields.Any(f => f.Col == left.Col - 1 && f.Row == left.Row))
        {
            allowedDirects[Direct.LEFT] = true;
        }
        if (fields.Any(f => f.Col == right.Col + 1 && f.Row == right.Row))
        {
            allowedDirects[Direct.RIGHT] = true;
        }
        if (fields.Any(f => f.Col == left.Col && f.Row == left.Row + 1)
            && fields.Any(f => f.Col == right.Col && f.Row == right.Row + 1))
        {
            allowedDirects[Direct.UP] = true;
        }
        if (fields.Any(f => f.Col == left.Col && f.Row == left.Row - 1)
            && fields.Any(f => f.Col == right.Col && f.Row == right.Row - 1))
        {
            allowedDirects[Direct.DOWN] = true;
        }

        return allowedDirects;
    }

    private Dictionary<Direct, bool> CalculateAllowedForY(List<Field> fields, List<Field> currentFields)
    {
        var allowedDirects = GetAllFalse();
        var field = currentFields.First();

        if (fields.Any(f => f.Row == field.Row + 1 && f.Col == field.Col)
            && fields.Any(f => f.Row == field.Row + 2 && f.Col == field.Col))
        {
            allowedDirects[Direct.UP] = true;
        }
        if (fields.Any(f => f.Row == field.Row - 1 && f.Col == field.Col)
            && fields.Any(f => f.Row == field.Row - 2 && f.Col == field.Col))
        {
            allowedDirects[Direct.DOWN] = true;
        }
        if (fields.Any(f => f.Row == field.Col - 1 && f.Col == field.Row)
            && fields.Any(f => f.Row == field.Col - 2 && f.Col == field.Row))
        {
            allowedDirects[Direct.LEFT] = true;
        }
        if (fields.Any(f => f.Row == field.Col + 1 && f.Col == field.Row)
            && fields.Any(f => f.Row == field.Col + 2 && f.Col == field.Row))
        {
            allowedDirects[Direct.RIGHT] = true;
        }

        return allowedDirects;
    }

    private Dictionary<Direct, bool> CalculateAllowedForZ(List<Field> fields, List<Field> currentFields)
    {
        var allowedDirects = GetAllFalse();
        var bottom = currentFields.First();
        var top = currentFields.Last();
        if (bottom.Row > top.Row)
        {
            bottom = currentFields.Last();
            top = currentFields.First();
        }

        if (fields.Any(f => f.Col == top.Col && f.Row == top.Row + 1))
        {
            allowedDirects[Direct.UP] = true;
        }
        if (fields.Any(f => f.Col == bottom.Col && f.Row == bottom.Row - 1))
        {
            allowedDirects[Direct.DOWN] = true;
        }
        if (fields.Any(f => f.Row == top.Row && f.Col == top.Col - 1)
            && fields.Any(f => f.Row == bottom.Row && f.Col == bottom.Col - 1))
        {
            allowedDirects[Direct.LEFT] = true;
        }
        if (fields.Any(f => f.Row == top.Row && f.Col == top.Col + 1)
            && fields.Any(f => f.Row == bottom.Row && f.Col == bottom.Col + 1))
        {
            allowedDirects[Direct.RIGHT] = true;
        }

        return allowedDirects;
    }

    private Dictionary<Direct, bool> GetAllFalse()
    {
        var result = new Dictionary<Direct, bool>
        {
            { Direct.LEFT, false },
            { Direct.RIGHT, false },
            { Direct.UP, false },
            { Direct.DOWN, false }
        };
        return result;
    }
}
