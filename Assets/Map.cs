using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private Field[] _fields;
    private List<Field> _currentFields;
    private FlipBehavior _flipBehavior;
    private PositionCalculator _positionCalculator;
    private AllowedDirectsCalculator _allowedDirectsCalculator;
    private Position _currentPosition;

    private void Start()
    {
        _currentFields = new List<Field>();
        _fields = FindObjectsOfType<Field>();
        foreach (var field in _fields)
        {
            if (field.IsCurrent)
            {
                _currentFields.Add(field);
            }
        }
        _flipBehavior = GetComponent<FlipBehavior>();
        _allowedDirectsCalculator = GetComponent<AllowedDirectsCalculator>();
    }

    private void Update()
    {
        ControlCurrentField();
    }

    private void ControlCurrentField()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            _currentPosition = _positionCalculator.GetPosition(_currentFields);
            var allowedDirects = _allowedDirectsCalculator.CalculateAllowedDirects(_fields, _currentFields, _currentPosition);
            if (allowedDirects[Direct.UP])
            {
                _flipBehavior.Flip(_fields, _currentFields, Direct.UP, _currentPosition);
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _currentPosition = _positionCalculator.GetPosition(_currentFields);
            var allowedDirects = _allowedDirectsCalculator.CalculateAllowedDirects(_fields, _currentFields, _currentPosition);
            if (allowedDirects[Direct.DOWN])
            {
                _flipBehavior.Flip(_fields, _currentFields, Direct.DOWN, _currentPosition);
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _currentPosition = _positionCalculator.GetPosition(_currentFields);
            var allowedDirects = _allowedDirectsCalculator.CalculateAllowedDirects(_fields, _currentFields, _currentPosition);
            if (allowedDirects[Direct.LEFT])
            {
                _flipBehavior.Flip(_fields, _currentFields, Direct.LEFT, _currentPosition);
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _currentPosition = _positionCalculator.GetPosition(_currentFields);
            var allowedDirects = _allowedDirectsCalculator.CalculateAllowedDirects(_fields, _currentFields, _currentPosition);
            if (allowedDirects[Direct.RIGHT])
            {
                _flipBehavior.Flip(_fields, _currentFields, Direct.RIGHT, _currentPosition);
            }
        }
    }
}
