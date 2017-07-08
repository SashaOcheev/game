using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Mechanics
{
    public class GameMapController : AbstractGameplayController
    {
        AllowedDirectsCalculator _allowedDirectsCalculator;
        GameMap _gameMap;

        #region MonoBehavior Members
        private void Start()
        {
            _allowedDirectsCalculator = GetComponent<AllowedDirectsCalculator>();
            _gameMap = GetComponent<GameMap>();
        }

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
