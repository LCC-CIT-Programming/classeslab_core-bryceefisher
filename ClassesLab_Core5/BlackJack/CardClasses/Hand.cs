using System.Collections.Generic;

namespace CardClasses
{
    public class Hand
    {
        protected List<Card> Cards;

        #region Constructors

        public Hand()
        {
            Cards = new List<Card>();
        }

        public Hand(Deck d, int numCards)
        {
            Cards = new List<Card>();
            
            for (int i = 0; i < numCards; i++)
            {
                Cards.Add(d[i]);
            }
        }

        #endregion

        #region Properties

        public int NumCards => Cards.Count;

        #endregion
        
        #region Methods

        public void AddCard(Card c)
        {
            Cards.Add(c);
        }

        public Card Discard(int index)
        {
            Card c = GetCard(index);
            Cards.Remove(c);
            return c;
        }

        public bool HasCard(Card c)
        {
            return Cards.Contains(c);
        }

        public bool HasCard(int value)
        {
            return IndexOf(value) != -1;
        }
        
        public Card GetCard(int index)
        {
            return Cards[index];
        }

        public bool HasCard(int value, int suit)
        {
            return IndexOf(value, suit) != -1;
        }

        public int IndexOf(Card c)
        {
            return Cards.IndexOf(c);
        }

        public int IndexOf(int value)
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Value == value)
                {
                    return i;
                }
            }

            return -1;
        }
        
        public int IndexOf(int value, int suit)
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Value == value && Cards[i].Suit == suit)
                {
                    return i;
                }
            }

            return -1;
        }

        
        public override string ToString()
        {
            //create a string variable
            string output = "";
            // go through every domino
            foreach (Card c in Cards)
                // convert the domino to a string
                output += (c.ToString() + "\n");
            return output;
        }
        

        #endregion
    }
}