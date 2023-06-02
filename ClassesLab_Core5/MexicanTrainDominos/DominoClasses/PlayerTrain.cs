namespace DominoClasses
{
    public class PlayerTrain : Train
    {
        // Instance variables
        private Hand _hand;
        
        private bool isOpen;

        #region Constructors

        //default constructor requires a hand
        public PlayerTrain(Hand h)
        {
        }

        //overloaded constructor requires a hand and an engine value
        public PlayerTrain(Hand h, int engineValue)
        {
            _hand = h;
            this.engineValue = engineValue;
        }
        
        #endregion

        #region Properties

        //returns true if the train is open, false if it is closed
        public bool IsOpen
        {
            get => isOpen;
        }

        #endregion

        #region Methods

        //opens the train
        public void Open()
        {
            isOpen = true;
        }

        //closes the train
        public void Close()
        {
            isOpen = false;
        }

        //overrides the IsPlayable method from the abstract Train class 
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