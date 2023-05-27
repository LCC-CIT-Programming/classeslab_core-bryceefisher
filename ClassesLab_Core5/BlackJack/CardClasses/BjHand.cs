namespace CardClasses
{
    //inherit from Hand
    public class BjHand : Hand
    {

        #region Constructors

        //default constructor
        public BjHand() : base()
        {
        }
        //overloaded constructor, inherits from Hand
        public BjHand(Deck d, int numCards) : base(d, numCards)
        {
        }

        #endregion
        #region Properties

        //Getter to check if hand has an ace
        public bool HasAce => HasCard(1);

        //Getter to check if hands value is over 21
        public bool IsBusted
        {
            get
            {
                if (this.Score > 21)
                {
                    return true;
                }

                return false;
            }
        }
        //Getter to return the score of the hand
        public int Score
        {
            get
            {
                int score = 0;

                foreach (Card card in Cards)
                {
                    if (card.IsFaceCard())
                    {
                        score += 10;
                    }
                    else
                    {
                        score += card.Value;
                    }
                }
                if (this.HasAce && score <= 11)
                {
                    score += 10;
                }

                return score;
            }
        }
        
        //Getter to return value at index 
        public Card this[int i]
        {
            //return donimo at index i
            get => Cards[i];
        }
        #endregion
    }
}