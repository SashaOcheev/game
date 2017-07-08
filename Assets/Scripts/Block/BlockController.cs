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
            _allowedDirectsCalculator = GetComponent<AllowedDirectsCalculator>();

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
                
            }
        }
    }
}