using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllowedDirectsCalculator : MonoBehaviour
{
    public Dictionary<Direct, bool> CalculateAllowedDirects(Field[] fields, List<Field> currentFields, Position position)
    {
        if (currentFields.Count < 1 || currentFields.Count > 2)
        {
            throw new System.Exception(String.Format("current fields count is {0}", currentFields.Count));
        }

        if (position == Position.X)
        {
            return CalculateAllowedForXPosition(fields, currentFields);
        }
        if (position == Position.Y)
        {
            return CalculateAllowedForYPosition(fields, currentFields);
        }
        if (position == Position.Z)
        {
            return CalculateAllowedForZPosition(fields, currentFields);
        }
        throw new Exception("CalculateAllowedDirects: current fields has no position");
    }

    private Dictionary<Direct, bool> CalculateAllowedForXPosition(Field[] fields, List<Field> currentFields)
    {
        var allowedDirects = GetAllFalse();
        var left = fields[0];
        var right = fields[1];
        if (left.Col > right.Col)
        {
            left = fields[1];
            right = fields[0];
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

    private Dictionary<Direct, bool> CalculateAllowedForYPosition(Field[] fields, List<Field> currentFields)
    {
        var allowedDirects = GetAllFalse();
        var field = fields[0];

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

    private Dictionary<Direct, bool> CalculateAllowedForZPosition(Field[] fields, List<Field> currentFields)
    {
        var allowedDirects = GetAllFalse();
        var bottom = fields[0];
        var top = fields[1];
        if (bottom.Row > top.Row)
        {
            bottom = fields[1];
            top = fields[0];
        }

        if (fields.Any(f => f.Col == top.Col && f.Row == top.Row + 1))
        {
            allowedDirects[Direct.UP] = true;
        }
        if (fields.Any(f => f.Col == bottom.Col && f.Row == bottom.Row - 1))
        {
            allowedDirects[Direct.DOWN] = true;
        }
        if (fields.Any(f => f.Row == top.Row && f.Col == top.Row - 1)
            && fields.Any(f => f.Row == bottom.Row && f.Col == bottom.Row - 1))
        {
            allowedDirects[Direct.LEFT] = true;
        }
        if (fields.Any(f => f.Row == top.Row && f.Col == top.Row + 1)
            && fields.Any(f => f.Row == bottom.Row && f.Col == bottom.Row + 1))
        {
            allowedDirects[Direct.RIGHT] = true;
        }

        return allowedDirects;
    }

    private Dictionary<Direct, bool> GetAllFalse()
    {
        var result = new Dictionary<Direct, bool>();
        result[Direct.LEFT] = false;
        result[Direct.RIGHT] = false;
        result[Direct.UP] = false;
        result[Direct.DOWN] = false;
        return result;
    }
}
