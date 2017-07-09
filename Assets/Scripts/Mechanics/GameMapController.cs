using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Mechanics
{
    public class GameMapController : AbstractGameplayController
    {
        #region MonoBehavior Members
        private void Update()
        {
            OnKeyUp();
        }
        #endregion

        protected override void FlipOnAllowedDirect(Direct direct)
        {
            if (!_gameMap.AllowedDirects[direct])
            {
                return;
            }

            _gameMap.Flip(direct);
        }
    }
}
