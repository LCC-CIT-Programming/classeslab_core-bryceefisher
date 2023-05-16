using System;
using System.Linq;
using DominoClasses;

namespace DominoTests
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Test Methods
            
            // TestDominoConstructors();
            // TestDominoToString();
            // TestDominoPropertyGetters();
            // TestDominoPropertySetters();
            // TestDominoFlip();
            // TestDominoScore();
            // TestDominoIsDouble();
            // TestDominoPropertySettersWithExceptions();
            // TestBoneyardConstructor();
            // TestBoneyardToString();
            // TestBoneyardGetters();
            // TestBoneyardSetters();
            // TestBoneyardShuffle();
            // TestBoneyardIsEmpty();
            TestBoneyardDraw();
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

            Console.WriteLine(b.ToString());
        }

        static void TestBoneyardToString()
        {
            Boneyard b = new Boneyard(6);
            Console.WriteLine(b.ToString());
        }

        static void TestBoneyardGetters()
        {
            Boneyard b = new Boneyard(6);

            Console.WriteLine(b.DominoesRemaining);
            Console.WriteLine(b[5]);
        }

        static void TestBoneyardSetters()
        {
            Boneyard b = new Boneyard(6);

            b[5] = new Domino(3, 4);

            Console.WriteLine(b[5]);
        }

        static void TestBoneyardShuffle()
        {
            Boneyard b = new Boneyard(6);
            
            b.Shuffle();

            Console.WriteLine(b.ToString());
        }

        static void TestBoneyardIsEmpty()
        {
            Boneyard b = new Boneyard(6);

            for (int i = b.DominoesRemaining; i > 0; i--)
            {
                b.Draw();
            }

            Console.WriteLine(b.DominoesRemaining);
            Console.WriteLine(b.IsEmpty());
        
        }

        static void TestBoneyardDraw()
        {
            Boneyard boneyard = new Boneyard(6);

            Console.WriteLine(boneyard.Draw());
            Console.WriteLine(boneyard.Draw());
            
        }



        #endregion
    }
}
