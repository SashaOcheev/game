using Scripts.Mechanics;

namespace Scripts.Block
{
    public class BlockController : AbstractGameplayController
    {
        AllowedDirectsCalculator _allowedDirectsCalculator;
        GameMap _gameMap;
        Block _block;

        #region MonoBehavior Members
        private void Start()
        {
            _gameMap = GetComponent<GameMap>();
            _block = FindObjectOfType<Block>();
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
                case Direct.LEFT:
                    _block.FlipLeft();
                    break;
                case Direct.RIGHT:
                    _block.FlipRight();
                    break;
                case Direct.UP:
                    _block.FlipUp();
                    break;
                case Direct.DOWN:
                    _block.FlipDown();
                    break;
            }
        }
    }
}