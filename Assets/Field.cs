using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using UnityEngine;
using System;

public class Field : MonoBehaviour
{
    public bool HasStar = false;

    public bool IsCurrent = false;
    [SerializeField]
    private bool _isEnd = false;
    public bool GetIsOk()
    {
        return IsCurrent == _isEnd;
    }

    public int Size;
    public int Row;
    public int Col;
    private void Start()
    {
        Update();
        Row = Convert.ToInt32(transform.position.z) / Size;
        Col = Convert.ToInt32(transform.position.x) / Size;
    }

    [SerializeField]
    private bool _wasStateChange = true;
    public void MoveOn()
    {
        _wasStateChange = true;
        IsCurrent = true;
    }
    public void MoveFrom()
    {
        _wasStateChange = true;
        IsCurrent = false;
    }

    private void Update()
    {
        if (!_wasStateChange)
        {
            return;
        }

        ChangeColor();
        _wasStateChange = false;
    }

    private void ChangeColor()
    {
        if (IsCurrent && _isEnd)
        {
            SwitchColor(Color.yellow);
        }
        else if (IsCurrent)
        {
            SwitchColor(Color.red);
        }
        else if (_isEnd)
        {
            SwitchColor(Color.green);
        }
        else
        {
            SwitchColor(Color.white);
        }
    }

    private void SwitchColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}
