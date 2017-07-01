using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private Field[] _fields;
    private List<Field> _currentFields;
    private FlipBehavior _flipBehavior;
    

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
    }

    private void Update()
    {
        ControlCurrentField();
    }

    private void ControlCurrentField()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            _flipBehavior.Flip(_fields, _currentFields, Direct.UP);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _flipBehavior.Flip(_fields, _currentFields, Direct.DOWN);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _flipBehavior.Flip(_fields, _currentFields, Direct.LEFT);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            _flipBehavior.Flip(_fields, _currentFields, Direct.RIGHT);
        }
    }
}
