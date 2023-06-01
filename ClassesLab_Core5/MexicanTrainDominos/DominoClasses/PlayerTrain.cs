namespace DominoClasses
{
    public class PlayerTrain : Train
    {
        private Hand _hand;
        
        private bool isOpen;

        #region Constructors

        public PlayerTrain(Hand h)
        {
        }

        public PlayerTrain(Hand h, int engineValue)
        {
            _hand = h;
            this.engineValue = engineValue;
        }
        
        #endregion

        #region Properties

        public bool IsOpen
        {
            get => isOpen;
        }

        #endregion

        #region Methods

        public void Open()
        {
            isOpen = true;
        }

        public void Close()
        {
            isOpen = false;
        }

        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            if (h == _hand || this.isOpen)
            {
                return this.IsPlayable(d, out mustFlip);
            }

            mustFlip = false;
            return false;
        }

        #endregion
    }
}