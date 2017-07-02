using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    private Color _color;

    #region MonoBehavior Members
    private void Start()
    {
        GetComponent<Renderer>().material.color = _color;
    }
    #endregion

    public void FlipUp()
    {
        
    }

    public void FlipDown()
    {
        
    }

    public void FlipLeft()
    {
        
    }

    public void FlipRight()
    {
        
    }
}
