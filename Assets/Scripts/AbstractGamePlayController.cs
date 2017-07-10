using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Mechanics;
using System;

namespace Scripts
{
    public abstract class AbstractGameplayController : MonoBehaviour
    {
        protected GameMap _gameMap;

        #region MonoBehavior members
        private void Start()
        {

        }
        #endregion

        protected void OnKeyUp()
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                FlipIfAllow(Direct.Up);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                FlipIfAllow(Direct.Down);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                FlipIfAllow(Direct.Left);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                FlipIfAllow(Direct.Right);
            }
        }

        protected void FlipIfAllow(Direct direct)
        {
            if (_gameMap.AllowedDirects[direct])
            {
                FlipOnAllowedDirect(direct);
            }
        }

        abstract protected void FlipOnAllowedDirect(Direct direct);
    }
}
