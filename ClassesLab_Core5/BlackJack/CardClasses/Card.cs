using System;

namespace CardClasses
{
    public class Card
    {
        //instance Variables
        private static string[] values =
            { "", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };

        private static string[] suits = { "", "Clubs", "Diamonds", "Hearts", "Spades" };
        private static Random generator = new Random();

        private int _value;
        private int _suit;

        #region Constructors

        

        
        //Constructors
        //default constructor
        public Card()
        {
        }

        //overloaded constructor
        public Card(int v, int s)
        {
            _value = v;
            _suit = s;
        }
        #endregion

        #region Properties
        
        //Properties
        public int Value
        {
            get { return _value; }
            set
            {
                if (value > 0 && value < 14)
                {
                    _value = value;
                }
                else
                {
                    throw new ArgumentException("Value must be between 1 and 13.");
                }
            }
        }

        public int Suit
        {
            get { return _suit; }

            set
            {
                if (value > 0 && value < 5)
                {
                    _suit = value;
                }
                else
                {
                    throw new ArgumentException("Suit must be between 1-4");
                }
            }
        }
        #endregion

        #region Methods
        
        // Class Methods

        public override string ToString()
        {
            return values[_value] + " of " + suits[_suit];
        }


        public bool IsBlack()
        {
            if (suits[_suit] == "Clubs" || suits[_suit] == "Spades")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsRed()
        {
            if (IsBlack())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsAce()
        {
            if (values[_value] == "Ace")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsClub()
        {
            if (suits[_suit] == "Clubs")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsDiamond()
        {
            if (suits[_suit] == "Diamonds")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHeart()
        {
            if (suits[_suit] == "Hearts")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsSpade()
        {
            if (suits[_suit] == "Spades")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFaceCard()
        {
            if (values[_value] == "Jack" || values[_value] == "Queen" || values[_value] == "King")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasMatchingSuit(Card other)
        {
            if (suits[_suit] == suits[other.Suit])
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasMatchingValue(Card other)
        {
            if (values[_value] == values[other.Value])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public override int GetHashCode()
        {
            return 13 + 7 * _value.GetHashCode() +
                   7 * _suit.GetHashCode();

        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Card other = (Card)obj;
                return other.Value == Value &&
                       other.Suit == Suit;
            }
        }
        
        #endregion
    }
}