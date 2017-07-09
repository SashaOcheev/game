using System;
using UnityEngine;

namespace Scripts.Block
{
    public class Block : MonoBehaviour
    {
        [SerializeField]
        private Position _currentPosition;
        private FlipBehavior _flipBehavior;

        public Position CurrentPosition
        {
            set
            {
                _currentPosition = value;
            }
        }

        #region MonoBehavior Members
        private void Start()
        {
            _flipBehavior = new FlipBehavior();
        }
        #endregion

        public void FlipRight()
        {
            _flipBehavior.FlipRight(ref _currentPosition, transform);
        }

        public void FlipLeft()
        {
            _flipBehavior.FlipLeft(ref _currentPosition, transform);
        }

        public void FlipDown()
        {
            _flipBehavior.FlipDown(ref _currentPosition, transform);
        }

        public void FlipUp()
        {
            _flipBehavior.FlipUp(ref _currentPosition, transform);
        }
    }
}
