using System;
using System.Linq;
using System.Threading.Channels;
using DominoClasses;

namespace DominoTests
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Domino Test Methods
            // TestDominoConstructors();
            // TestDominoToString();
            // TestDominoPropertyGetters();
            // TestDominoPropertySetters();
            // TestDominoFlip();
            // TestDominoScore();
            // TestDominoIsDouble();
            // TestDominoPropertySettersWithExceptions();
            
            //Boneyard Test Methods
            // TestBoneyardConstructor();
            // TestBoneyardToString();
            // TestBoneyardGetters();
            // TestBoneyardSetters();
            // TestBoneyardShuffle();
            // TestBoneyardIsEmpty();
            // TestBoneyardDraw();
            
            //Train Tests
            // TestMexicanTrainConstructors();
            // TestMexicanTrainIsPlayable();
            // TestPlay();
            // TestIsOpen();
            // TestClose();
            TestPlayerTrainIsPlayable();
        }

        #region Domino Tests
        
        //Domino test Methods
        static void TestDominoConstructors()
        {
            Domino d1 = new Domino();
            Domino d2 = new Domino(12, 6);

            Console.WriteLine("Testing both constructors");
            Console.WriteLine("Default constructor.  Expecting default values (0, 0). " + d1.ToString());
            Console.WriteLine("Overloaded constructor.  Expecting 12, 6 " + d2.ToString());
            Console.WriteLine();
        }

        static void TestDominoToString()
        {
            Domino d1 = new Domino(12, 6);

            Console.WriteLine("Testing ToString");
            Console.WriteLine("Expecting 12, 6 " + d1.ToString());
            Console.WriteLine("Expecting 12, 6 " + d1);
            Console.WriteLine();
        }

        static void TestDominoPropertyGetters()
        {
            Domino d1 = new Domino(12, 6);

            Console.WriteLine("Testing getters");
            Console.WriteLine("Side 1.  Expecting 12. " + d1.Side1);
            Console.WriteLine("Side 2.  Expecting 6. " + d1.Side2);
            Console.WriteLine();
        }

        static void TestDominoPropertySetters()
        {
            Domino d1 = new Domino(12, 6);

            Console.WriteLine("Testing setters");
            d1.Side1 = 4;
            d1.Side2 = 5;
            Console.WriteLine("Expecting 4, 5 " + d1);
            Console.WriteLine();
        }

        static void TestDominoPropertySettersWithExceptions()
        {
            Domino d1 = new Domino(12, 6);

            Console.WriteLine("Testing invalid setter values");
            try
            {
                d1.Side1 = -1;
            }
            catch
            {
                Console.WriteLine("Threw an exception when Side1 is negative");
                Console.WriteLine("Side1 should still be 12 " + d1.Side1);
            }
            try
            {
                d1.Side1 = 13;
            }
            catch
            {
                Console.WriteLine("Threw an exception when Side1 is more than 12");
                Console.WriteLine("Side1 should still be 12 " + d1.Side1);
            }
            try
            {
                d1.Side2 = -1;
            }
            catch
            {
                Console.WriteLine("Threw an exception when Side2 is negative");
                Console.WriteLine("Side2 should still be 6 " + d1.Side2);
            }
            try
            {
                d1.Side2 = 13;
            }
            catch
            {
                Console.WriteLine("Threw an exception when Side2 is more than 12");
                Console.WriteLine("Side2 should still be 6 " + d1.Side2);
            }
            try
            {
                d1 = new Domino(-1, 15);
            }
            catch
            {
                Console.WriteLine("Constructor should also throw an exception when values are invalid");
                Console.WriteLine("d1 is now " + d1);
            }
            Console.WriteLine();
        }

        static void TestDominoScore()
        {
            Domino d1 = new Domino(12, 6);

            Console.WriteLine("Testing Score");
            Console.WriteLine("Score.  Expecting 18. " + d1.Score);
            Console.WriteLine();
        }

        static void TestDominoIsDouble()
        {
            Domino d1 = new Domino(12, 12);
            Domino d2 = new Domino(12, 6);

            Console.WriteLine("Testing IsDouble");
            Console.WriteLine("12 and 12.  Expecting true. " + d1.IsDouble());
            Console.WriteLine("12 and 6.  Expecting false. " + d2.IsDouble());
            Console.WriteLine();
        }

        static void TestDominoFlip()
        {
            Domino d1 = new Domino(12, 6);

            Console.WriteLine("Testing Flip");
            Console.WriteLine("Before.  Expecting 12, 6. " + d1);
            d1.Flip();
            Console.WriteLine("After.  Expecting 6, 12. " + d1);
            Console.WriteLine();
        }
        #endregion

        #region Boneyard Tests
        // Boneyard Test Methods
        static void TestBoneyardConstructor()
        {
            Boneyard b = new Boneyard(6);
            
            Console.WriteLine("Testing constructor");
            Console.WriteLine("Expecting 28 dominoes:");
            int count = 1;
            foreach (Domino d in b)
            {
                Console.WriteLine($"{count}: {d}");
                count++;
            }
        }

        static void TestBoneyardToString()
        {
            Boneyard b = new Boneyard(6);

            Console.WriteLine("Testing ToString");
            Console.WriteLine("Expecting 28 dominoes:");
            int count = 1;
            foreach (Domino d in b)
            {
                Console.WriteLine($"{count}: {d}");
                count++;
            }
        }

        static void TestBoneyardGetters()
        {
            Boneyard b = new Boneyard(6);

            Console.WriteLine("Testing getters");
            Console.Write("Expecting 28: ");
            Console.WriteLine(b.DominoesRemaining);
            Console.WriteLine("Expecting Side 1: 0  Side 2: 5");
            Console.WriteLine(b[5]);
        }

        static void TestBoneyardSetters()
        {
            Boneyard b = new Boneyard(6);

            b[5] = new Domino(3, 4);

            Console.WriteLine("Testing setters");
            Console.WriteLine("Expecting Side 1: 3  Side 2: 4");
            Console.WriteLine(b[5]);
        }

        static void TestBoneyardShuffle()
        {
            Boneyard b = new Boneyard(6);
            
            b.Shuffle();

            Console.WriteLine("Testing Shuffle");
            Console.WriteLine("Expecting domino at index 0 to rarely be Side 1: 0  Side 2: 0");
            Console.WriteLine($"Domino at index 0: {b[0]}");
        }

        static void TestBoneyardIsEmpty()
        {
            Boneyard b = new Boneyard(6);

            Console.WriteLine("Testing IsEmpty");
            Console.WriteLine("Expecting false: " + b.IsEmpty());

            for (int i = b.DominoesRemaining; i > 0; i--)
            {
                b.Draw();
            }

            Console.WriteLine("Expecting true: " + b.IsEmpty());
        
        }

        static void TestBoneyardDraw()
        {
            Boneyard boneyard = new Boneyard(6);

            boneyard.Draw();
            boneyard.Draw();
            
            Console.WriteLine("Testing Draw");

            Console.WriteLine("Expecting 26: " + boneyard.DominoesRemaining);
            
        }



        #endregion

        #region Train Tests

        //Also tests Add, Count, IsEmpty, LastDomino, toString and PlayableValue through the call to ToString
        static void TestMexicanTrainConstructors()
        {
            Domino d1 = new Domino(12, 6);
            MexicanTrain train2 = new MexicanTrain();
            MexicanTrain train = new MexicanTrain(6);
            Console.WriteLine("Testing is empty");
            Console.WriteLine("Expecting true: " + train.IsEmpty);
            train.Add(d1);

            Console.WriteLine("Testing constructor");
            Console.WriteLine("Expecting 1 domino in the train:");
            Console.WriteLine(train.ToString());
            Console.WriteLine("Expecting empty train:");
            Console.WriteLine(train2.ToString());
        }

        static void TestMexicanTrainIsPlayable()
        {
            Hand h = new Hand();
            Domino d1 = new Domino(12, 6);
            Domino d2 = new Domino(12, 12);
            MexicanTrain train = new MexicanTrain(6);
            train.Add(d1);

            Console.WriteLine("Expecting true (IsPlayable): ");
            Console.WriteLine(train.IsPlayable(h, d1, out bool mustFlip));
            Console.WriteLine("Expecting false (IsPlayable): ");
            Console.WriteLine(train.IsPlayable(h, d2, out mustFlip));
        }

        static void TestPlay()
        {
            Hand h = new Hand();
            Domino d1 = new Domino(12, 4);
            MexicanTrain train = new MexicanTrain(6);
            MexicanTrain train2 = new MexicanTrain(4);

            Console.WriteLine("Testing Play");
            Console.WriteLine("Expecting success:");
            train2.Play(h, d1);
            Console.WriteLine(train2.ToString());

            
            Console.WriteLine("Expecting error:");
            train.Play(h, d1);
        }

        static void TestIsOpen()
        {
            Hand h = new Hand();
            PlayerTrain train = new PlayerTrain(h, 6);
            
            Console.WriteLine("Testing IsOpen");
            Console.WriteLine("Expecting false: " + train.IsOpen);
            train.Open();
            Console.WriteLine("Expecting true: " + train.IsOpen);
        }

        static void TestClose()
        {
            Hand h = new Hand();
            PlayerTrain train = new PlayerTrain(h, 6);

            train.Open();
            Console.WriteLine("Testing Close");
            Console.WriteLine("Expecting Open (true): " + train.IsOpen);
            train.Close();
            Console.WriteLine("Expecting Closed (false): " + train.IsOpen);
        }

        static void TestPlayerTrainIsPlayable()
        {
            Hand h = new Hand();
            Domino d1 = new Domino(12, 6);
            PlayerTrain train = new PlayerTrain(h, 6);
            PlayerTrain train2 = new PlayerTrain(h, 4);
            bool mustFlip;
            
            Console.WriteLine("Testing IsPlayable");
            Console.WriteLine("Expecting true: " + train.IsPlayable(h, d1, out mustFlip));
            Console.WriteLine("Expecting false: " + train2.IsPlayable(h, d1, out mustFlip));
        }

        #endregion
    }
}
