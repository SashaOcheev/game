using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Mechanics
{
    public class GameMapController : AbstractGameplayController
    {
        #region MonoBehavior Members
        private void Start()
        {
            _gameMap = GetComponent<GameMap>();
        }

        private void Update()
        {
            OnKeyUp();
        }
        #endregion

        protected override void FlipOnAllowedDirect(Direct direct)
        {
            _gameMap.Flip(direct);
        }
    }
}
