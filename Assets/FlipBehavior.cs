using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlipBehavior : MonoBehaviour
{
    private CurrentFieldsCalculator _currentFieldsCalculator;
    private PositionCalculator _positionCalculator;

    #region MonoBehaviour Members
    private void Start()
    {
        _currentFieldsCalculator = GetComponent<CurrentFieldsCalculator>();
        _positionCalculator = GetComponent<PositionCalculator>();
    }
    #endregion

    public void Flip(List<Field> fields, Direct direct)
    {
        var oldCurrentFields = _currentFieldsCalculator.CalculateCurrentFields(fields);
        var position = _positionCalculator.CalculatePosition(fields);

        List<Field> newCurrentFields = new List<Field>();
        switch (position)
        {
            case Position.X:
                newCurrentFields = GetCurrentAfterFlipFromX(fields, oldCurrentFields, direct);
                break;
            case Position.Y:
                newCurrentFields = GetCurrentAfterFlipFromY(fields, oldCurrentFields, direct);
                break;
            case Position.Z:
                newCurrentFields = GetCurrentAfterFlipFromZ(fields, oldCurrentFields, direct);
                break;
        }

        MoveFromEachField(oldCurrentFields);
        MoveOnEachField(newCurrentFields);
    }

    private List<Field> GetCurrentAfterFlipFromX(List<Field> fields, List<Field> currentFields, Direct direct)
    {
        var left = currentFields.First(c => c.Col == currentFields.Min(cf => cf.Col));
        var right = currentFields.First(c => c.Col == currentFields.Max(cf => cf.Col));

        var newCurrentFields = new List<Field>();
        switch (direct)
        {
            case Direct.UP:
                newCurrentFields.AddRange(fields.Where(x => x.Col == left.Col && x.Row == left.Row + 1 ||
                    x.Col == right.Col && x.Row == right.Row + 1));
                break;
            case Direct.DOWN:
                newCurrentFields.AddRange(fields.Where(x => x.Col == left.Col && x.Row == left.Row - 1 ||
                    x.Col == right.Col && x.Row == right.Row - 1));
                break;
            case Direct.LEFT:
                newCurrentFields.AddRange(fields.Where(x => x.Col == left.Col - 1 && x.Row == left.Row));
                break;
            case Direct.RIGHT:
                newCurrentFields.AddRange(fields.Where(x => x.Col == right.Col + 1 && x.Row == right.Row));
                break;
        }
        return newCurrentFields;
    }

    private List<Field> GetCurrentAfterFlipFromZ(List<Field> fields, List<Field> currentFields, Direct direct)
    {
        var bottom = currentFields.First(c => c.Row == currentFields.Min(cf => cf.Row));
        var top = currentFields.First(c => c.Row == currentFields.Max(cf => cf.Row));

        var newCurrentFields = new List<Field>();
        switch (direct)
        {
            case Direct.UP:
                newCurrentFields.AddRange(fields.Where(x => x.Col == top.Col && x.Row == top.Row + 1));
                break;
            case Direct.DOWN:
                newCurrentFields.AddRange(fields.Where(x => x.Col == bottom.Col && x.Row == bottom.Row - 1));
                break;
            case Direct.LEFT:
                newCurrentFields.AddRange(fields.Where(x => x.Col == top.Col - 1 && x.Row == top.Row ||
                    x.Col == bottom.Col - 1 && x.Row == bottom.Row));
                break;
            case Direct.RIGHT:
                newCurrentFields.AddRange(fields.Where(x => x.Col == top.Col + 1 && x.Row == top.Row ||
                    x.Col == bottom.Col + 1 && x.Row == bottom.Row));
                break;
        }
        return newCurrentFields;
    }

    private List<Field> GetCurrentAfterFlipFromY(List<Field> fields, List<Field> currentFields, Direct direct)
    {
        var current = currentFields.First();

        var newCurrentFields = new List<Field>();
        switch (direct)
        {
            case Direct.UP:
                newCurrentFields.AddRange(fields.Where(x => x.Row == current.Row + 1 && x.Col == current.Col ||
                    x.Row == current.Row + 2 && x.Col == current.Col));
                break;
            case Direct.DOWN:
                newCurrentFields.AddRange(fields.Where(x => x.Row == current.Row - 1 && x.Col == current.Col ||
                    x.Row == current.Row - 2 && x.Col == current.Col));
                break;
            case Direct.LEFT:
                newCurrentFields.AddRange(fields.Where(x => x.Row == current.Row && x.Col == current.Col - 1 ||
                    x.Row == current.Row && x.Col == current.Col - 2));
                break;
            case Direct.RIGHT:
                newCurrentFields.AddRange(fields.Where(x => x.Row == current.Row && x.Col == current.Col + 1 ||
                    x.Row == current.Row && x.Col == current.Col + 2));
                break;
        }
        return newCurrentFields;
    }

    private void MoveFromEachField(List<Field> fields)
    {
        foreach (var field in fields)
        {
            field.MoveFrom();
        }
    }

    private void MoveOnEachField(List<Field> fields)
    {
        foreach (var field in fields)
        {
            field.MoveOn();
        }
    }
}
