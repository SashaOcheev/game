using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private Field _currentField;
    private Field[] _fields;

    private void Start()
    {
        _fields = FindObjectsOfType<Field>();
        foreach (var field in _fields)
        {
            if (field.IsCurrent)
            {
                _currentField = field;
            }
        }
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
