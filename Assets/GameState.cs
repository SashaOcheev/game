using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private Field[] _fields;

    public List<Field> Fields
    {
        get
        {
            return _fields.ToList();
        }
    }

    #region MonoBehavior Members
    private void Start()
    {
        _fields = FindObjectsOfType<Field>();
    }
    #endregion
}
