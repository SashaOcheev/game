using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipBehavior : MonoBehaviour
{
    public void Flip(Field[] fields, List<Field> currentFields, Direct direct)
    {
        var position = GetPosition(currentFields);
    }

    private Position GetPosition(List<Field> currentFields)
    {
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
}
