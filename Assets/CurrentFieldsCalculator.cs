using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CurrentFieldsCalculator : MonoBehaviour
{
    public List<Field> CalculateCurrentFields(List<Field> fields)
    {
        return fields.Where(f => f.IsCurrent).ToList();
    }
}
