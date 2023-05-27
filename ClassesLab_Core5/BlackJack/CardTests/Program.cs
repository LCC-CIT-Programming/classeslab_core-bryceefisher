using System;
using CardClasses;

namespace CardTests
{
    class Program
    {
        static void Main(string[] args)
        {
            // calling test methods in main
            // TestCardConstructors();
            // TestCardToString();
            // TestCardPropertyGetters();
            // TestCardPropertySetters();
            // TestCardPropertySettersWithExceptions();

            // Card c2 = new Card(1, 4);
            // TestHasMatchingSuit(c2);
            // TestHasMatchingValue(c2);

            // TestIsAce();
            // TestIsFaceCard();
            // TestIsRed();
            // TestIsBlack();
            // TestIsClub();
            // TestIsDiamond();
            // TestIsHeart();
            // TestIsSpade();
            // TestDeckConstructor();
            // TestDeckShuffle();
            // TestDeckDeal();
            
            // Hand tests
            // TestHandConstructors();
            // TestHandGetter();
            // TestHandAddCard();
            // TestHandHasCard();
            // TestHandIndexOf();
            
            //BJHand Tests
            // TestBJHandConstructors();
            // TestBJHandGetters();
            
            

        }

        #region Card Tests

        //test methods
        static void TestCardConstructors()
        {
            Card c1 = new Card();
            Card c2 = new Card(12, 3);

            Console.WriteLine("Testing both constructors");
            Console.WriteLine("(Default constructor) Expecting: default values (0, 0): " + c1.ToString());
            Console.WriteLine("(Overloaded constructor) Expecting: Queen of Hearts: " + c2.ToString());
            Console.WriteLine();
        }

        static void TestCardToString()
        {
            Card d1 = new Card(12, 3);

            Console.WriteLine("Testing ToString");
            Console.WriteLine("(Expecting: Queen of Hearts): " + d1.ToString());
            Console.WriteLine("(Expecting: Queen of Hearts): " + d1);
            Console.WriteLine();
        }

        //
        static void TestCardPropertyGetters()
        {
            Card c1 = new Card(1, 2);

            Console.WriteLine("Testing getters");
            Console.WriteLine("Expecting 1. " + c1.Value);
            Console.WriteLine("Expecting 2. " + c1.Suit);
            Console.WriteLine();
        }

        //
        static void TestCardPropertySetters()
        {
            Card c1 = new Card(1, 4);

            Console.WriteLine("Testing setters");
            c1.Value = 1;
            c1.Suit = 4;
            Console.WriteLine("(Expecting Ace of Spades): " + c1);
            Console.WriteLine();
        }

        static void TestCardPropertySettersWithExceptions()
        {
            Card c1 = new Card(5, 4);

            Console.WriteLine("Testing invalid setter values");
            try
            {
                c1.Value = -1;
            }
            catch
            {
                Console.WriteLine("Threw an exception when Value is negative");
                Console.WriteLine("(c1.Value should still be 5): " + c1.Value);
            }

            try
            {
                c1.Suit = 13;
            }
            catch
            {
                Console.WriteLine("Threw an exception when Suit is more than 4");
                Console.WriteLine("(c1.Suit should still be 4): " + c1.Suit);
            }
        }

        static void TestHasMatchingSuit(Card other)
        {
            Card c1 = new Card(1, 4);

            Console.WriteLine("Testing HasMatchingSuit");
            Console.WriteLine("(Expecting Matching Suit): ");
            Console.WriteLine(c1.HasMatchingSuit(other) ? "Matching suit" : "Not matching suit");
        }

        static void TestHasMatchingValue(Card other)
        {
            Card c1 = new Card(1, 4);

            Console.WriteLine("Testing HasMatchingValue");
            Console.WriteLine("(Expecting Matching Value): ");
            Console.WriteLine(c1.HasMatchingSuit(other) ? "Matching Value" : "Not matching Value");
        }

        static void TestIsAce()
        {
            Card c1 = new Card(1, 4);

            Console.WriteLine("Testing IsAce");
            Console.WriteLine("(Expecting Ace): ");
            Console.WriteLine(c1.IsAce() ? "Ace" : "Not Ace");
        }

        static void TestIsFaceCard()
        {
            Card c1 = new Card(11, 4);

            Console.WriteLine("Testing IsFaceCard");
            Console.WriteLine("(Expecting Face Card): ");
            Console.WriteLine(c1.IsFaceCard() ? "Face Card" : "Not Face Card");
        }

        static void TestIsRed()
        {
            Card c1 = new Card(1, 3);

            Console.WriteLine("Testing IsRed");
            Console.WriteLine("(Expecting Red): ");
            Console.WriteLine(c1.IsRed() ? "Red" : "Not Red");
        }

        static void TestIsBlack()
        {
            Card c1 = new Card(1, 4);

            Console.WriteLine("Testing IsBlack");
            Console.WriteLine("(Expecting Black): ");
            Console.WriteLine(c1.IsBlack() ? "Black" : "Not Black");
        }

        static void TestIsClub()
        {
            Card c1 = new Card(1, 1);

            Console.WriteLine("Testing IsClub");
            Console.WriteLine("(Expecting Club): ");
            Console.WriteLine(c1.IsClub() ? "Club" : "Not Club");
        }

        static void TestIsDiamond()
        {
            Card c1 = new Card(1, 2);

            Console.WriteLine("Testing IsDiamond");
            Console.WriteLine("(Expecting Diamond): ");
            Console.WriteLine(c1.IsDiamond() ? "Diamond" : "Not Diamond");
        }

        static void TestIsHeart()
        {
            Card c1 = new Card(1, 3);

            Console.WriteLine("Testing IsHeart");
            Console.WriteLine("(Expecting Heart): ");
            Console.WriteLine(c1.IsHeart() ? "Heart" : "Not Heart");
        }

        static void TestIsSpade()
        {
            Card c1 = new Card(1, 4);

            Console.WriteLine("Testing IsSpade");
            Console.WriteLine("(Expecting Spade): ");
            Console.WriteLine(c1.IsSpade() ? "Spade" : "Not Spade");
        }

        #endregion

        #region Deck Tests

        static void TestDeckConstructor()
        {
            Deck d = new Deck();

            Console.WriteLine("Testing deck of cards default constructor");
            Console.WriteLine("NumCards.  Expecting 52. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("ToString.  Expect a ton of cards in order.\n" + d.ToString());
            Console.WriteLine();
        }

        static void TestDeckShuffle()
        {
            Deck d = new Deck();
            d.Shuffle();
            Console.WriteLine("Testing deck of cards shuffle");
            Console.WriteLine("NumCards.  Expecting 52. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("First Card will rarely be the Ace of Clubs. " + d[0]);
            Console.WriteLine("ToString.  Expect a ton of cards in shuffled order.\n" + d.ToString());
            Console.WriteLine();
        }

        static void TestDeckDeal()
        {
            Deck d = new Deck();
            Card c = d.Deal();

            Console.WriteLine("Testing deck of cards deal");
            Console.WriteLine("NumCards.  Expecting 51. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
            Console.WriteLine("Dealt Card should be Ace of Clubs. " + c);

            // now let's deal them all and see what happens at the end
            for (int i = 1; i <= 51; i++)
                c = d.Deal();
            Console.WriteLine("Dealt all 52 cards");
            Console.WriteLine("NumCards.  Expecting 0. " + d.NumCards);
            Console.WriteLine("IsEmpty.   Expecting true. " + d.IsEmpty);
            Console.WriteLine("Last Card should be King of Spades. " + c);
            Console.WriteLine("Dealing again should return null. Expecting true. " + (d.Deal() == null));

            Console.WriteLine();
        }
        #endregion

        #region Hand Tests

        static void TestHandConstructors()
        {
            Deck d = new Deck();
            Hand h1 = new Hand();
            Hand h2 = new Hand(d, 5);

            Console.WriteLine("Testing hand constructors");
            Console.WriteLine("h1. Expecting 0 cards. " + h1);
            Console.WriteLine("h2. Expecting 5 cards. " + "\n" + h2);
            Console.WriteLine();
        }

        static void TestHandGetter()
        {
            Deck d = new Deck();
            
            Hand h = new Hand(d, 5);
            
            Console.WriteLine("Testing hand getters");
            Console.WriteLine("Expecting 5 cards. " + h.NumCards);
        }

        static void TestHandAddCard()
        {
            Deck d = new Deck();
            Hand h = new Hand();
            
            h.AddCard(d[0]);

            Console.WriteLine("Testing hand add card");
            Console.WriteLine("Expecting 1 card. " + h.NumCards);
            Console.WriteLine(h.ToString());
        }

        static void TestHandDiscard()
        {
            Deck d = new Deck();
            Hand h = new Hand(d, 5);
            
            h.Discard(0);

            Console.WriteLine("Testing hand discard");
            Console.WriteLine("Expecting 4 cards. " + h.NumCards);
            Console.WriteLine(h.ToString());
        }

        static void TestHandHasCard()
        {
            Deck d = new Deck();
            
            Hand h = new Hand(d, 5);
            
            Console.WriteLine("Testing hand has card (Card)");
            Console.WriteLine("Expecting true. " + h.HasCard(d[0]));
            Console.WriteLine("Testing hand has card (v, s)");
            Console.WriteLine("Expecting true. " + h.HasCard(1, 1));
            Console.WriteLine("Testing hand has card (v)");
            Console.WriteLine("Expecting false. " + h.HasCard(4));
        }

        static void TestHandIndexOf()
        {
            Deck d = new Deck();
            
            Hand h = new Hand(d, 5);
            
            Console.WriteLine("Testing hand index of (Card)");
            Console.WriteLine("Expecting 2. " + h.IndexOf(d[2]));
            Console.WriteLine("Testing hand index of (v, s)");
            Console.WriteLine("Expecting 4. " + h.IndexOf(2, 1));
            Console.WriteLine("Testing hand index of (v)");
            Console.WriteLine("Expecting 4. " + h.IndexOf(2));
            Console.WriteLine("Testing hand index of (Card) not in hand");
            Console.WriteLine("Expecting -1. " + h.IndexOf(d[51]));
            Console.WriteLine("Testing hand index of (v, s) not in hand");
            Console.WriteLine("Expecting -1. " + h.IndexOf(4, 4));
            Console.WriteLine("Testing hand index of (v) not in hand");
            Console.WriteLine("Expecting -1. " + h.IndexOf(4));
            
        }
        
        

        #endregion

        #region BjHand Tests

        static void TestBJHandConstructors()
        {
           Deck d = new Deck();
           
           BjHand bj1 = new BjHand();
           BjHand bj2 = new BjHand(d, 5);

           Console.WriteLine("Testing bjhand constructors");
           Console.WriteLine("bj1. Expecting 0 cards. " + bj1);
           Console.WriteLine("bj2. Expecting 5 cards. " + "\n" + bj2);
        }
        
        static void TestBJHandGetters()
        {
            Deck d = new Deck();
            
            BjHand bj = new BjHand(d, 5);

            Console.WriteLine("Testing bjhand getters");
            Console.WriteLine("Score: " + bj.Score);
            Console.WriteLine("IsBusted: " + bj.IsBusted);
            Console.WriteLine("HasAce: " + bj.HasAce);
            Console.WriteLine("Testing IsBusted");
            BjHand bj2 = new BjHand(d, 13);
            Console.WriteLine("Score: " + bj2.Score);
            Console.WriteLine("IsBusted: " + bj2.IsBusted);
        }

        #endregion
    }
}