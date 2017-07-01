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
    }

    public void Flip(Field[] fields, List<Field> currentFields, Direct direct, Position position)
    {
        switch (position)
        {
            case Position.X:
                FlipXPosition(fields, currentFields, direct);
                break;
            case Position.Y:
                FlipYPosition(fields, currentFields, direct);
                break;
            case Position.Z:
                FlipZPosition(fields, currentFields, direct);
                break;
        }
        foreach (var field in fields)
        {
            field.IsCurrent = currentFields.Contains(field);
        }
    }

    private void FlipXPosition(Field[] fields, List<Field> currentFields, Direct direct)
    {
        var left = currentFields.First(c => c.Col == currentFields.Min(cf => cf.Col));
        var right = currentFields.First(c => c.Col == currentFields.Max(cf => cf.Col));
        currentFields.Clear();

        switch (direct)
        {
            case Direct.UP:
                currentFields.AddRange(fields.Where(x => x.Col == left.Col && x.Row == left.Row + 1 ||
                    x.Col == right.Col && x.Row == right.Row + 1));
                break;
            case Direct.DOWN:
                currentFields.AddRange(fields.Where(x => x.Col == left.Col && x.Row == left.Row - 1 ||
                    x.Col == right.Col && x.Row == right.Row - 1));
                break;
            case Direct.LEFT:
                currentFields.AddRange(fields.Where(x => x.Col == left.Col - 1 && x.Row == left.Row));
                break;
            case Direct.RIGHT:
                currentFields.AddRange(fields.Where(x => x.Col == right.Col + 1 && x.Row == right.Row));
                break;
        }
    }

    private void FlipZPosition(Field[] fields, List<Field> currentFields, Direct direct)
    {
        var bottom = currentFields.First(c => c.Row == currentFields.Min(cf => cf.Row));
        var top = currentFields.First(c => c.Row == currentFields.Max(cf => cf.Row));
        currentFields.Clear();

        switch (direct)
        {
            case Direct.UP:
                currentFields.AddRange(fields.Where(x => x.Col == top.Col && x.Row == top.Row + 1));
                break;
            case Direct.DOWN:
                currentFields.AddRange(fields.Where(x => x.Col == bottom.Col && x.Row == bottom.Row - 1));
                break;
            case Direct.LEFT:
                currentFields.AddRange(fields.Where(x => x.Col == top.Col - 1 && x.Row == top.Row ||
                    x.Col == bottom.Col - 1 && x.Row == bottom.Row));
                break;
            case Direct.RIGHT:
                currentFields.AddRange(fields.Where(x => x.Col == top.Col + 1 && x.Row == top.Row ||
                    x.Col == bottom.Col + 1 && x.Row == bottom.Row));
                break;
        }
    }

    private void FlipYPosition(Field[] fields, List<Field> currentFields, Direct direct)
    {
        var current = currentFields.First();
        currentFields.Clear();

        switch (direct)
        {
            case Direct.UP:
                currentFields.AddRange(fields.Where(x => x.Row == current.Row + 1 && x.Col == current.Col ||
                    x.Row == current.Row + 2 && x.Col == current.Col));
                break;
            case Direct.DOWN:
                currentFields.AddRange(fields.Where(x => x.Row == current.Row - 1 && x.Col == current.Col ||
                    x.Row == current.Row - 2 && x.Col == current.Col));
                break;
            case Direct.LEFT:
                currentFields.AddRange(fields.Where(x => x.Row == current.Row && x.Col == current.Col - 1 ||
                    x.Row == current.Row && x.Col == current.Col - 2));
                break;
            case Direct.RIGHT:
                currentFields.AddRange(fields.Where(x => x.Row == current.Row && x.Col == current.Col + 1 ||
                    x.Row == current.Row && x.Col == current.Col + 2));
                break;
        }
    }
}
