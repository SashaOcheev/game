using Scripts.Mechanics;
using UnityEngine;

namespace Scripts.Block
{
    public class BlockController : AbstractGameplayController
    {
        Block _block;

        #region MonoBehavior Members
        private void Start()
        {
            _gameMap = GetComponent<GameMap>();
            _block = FindObjectOfType<Block>();
            _block.CurrentPosition = _gameMap.CurrentPosition;
        }

        private void Update()
        {
            OnKeyUp();
        }
        #endregion

        protected override void FlipOnAllowedDirect(Direct direct)
        {
            switch (direct)
            {
                case Direct.Left:
                    _block.FlipLeft();
                    break;
                case Direct.Right:
                    _block.FlipRight();
                    break;
                case Direct.Up:
                    _block.FlipUp();
                    break;
                case Direct.Down:
                    _block.FlipDown();
                    break;
            }
        }
    }
}