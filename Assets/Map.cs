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
        _flipBehavior.Flip(_fields, _currentFields, Direct.DOWN);
    }

    // Update is called once per frame
    private void Update()
    {
        ControlCurrentField();
    }

    private void ControlCurrentField()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {

        }
        if (Input.GetKeyUp(KeyCode.S))
        {

        }
        if (Input.GetKeyUp(KeyCode.A))
        {

        }
        if (Input.GetKeyUp(KeyCode.D))
        {

        }
    }
}
