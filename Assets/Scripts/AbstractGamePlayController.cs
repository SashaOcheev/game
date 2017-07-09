using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scripts.Mechanics;

namespace Scripts
{
    public abstract class AbstractGameplayController : MonoBehaviour
    {
        protected GameMap _gameMap;

        #region MonoBehaviour members
        private void Start()
        {
            _gameMap = GetComponent<GameMap>();
        }
        #endregion

        protected void OnKeyUp()
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                FlipOnAllowedDirect(Direct.UP);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                FlipOnAllowedDirect(Direct.DOWN);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                FlipOnAllowedDirect(Direct.LEFT);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                FlipOnAllowedDirect(Direct.RIGHT);
            }
        }

        abstract protected void FlipOnAllowedDirect(Direct direct);
    }
}
