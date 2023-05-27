using System;
using System.Threading;
using CardClasses;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            //display instructions
            DisplayInstructions();
            //set up game variables
            bool playAgain = true;
            int playerWins = 0;
            int dealerWins = 0;
            string choice;
            //do while loop to play again
            do
            {
                Console.Clear();
                //create deck and shuffle
                Deck d = new Deck();
                d.Shuffle();
                //deal cards
                BjHand player = new BjHand(d, 2);
                d.Deal();
                d.Deal();
                BjHand dealer = new BjHand(d, 2);
                d.Deal();
                d.Deal();
                //display cards
                Console.Write($"Player Cards: \n{player}");
                Console.Write($"Score: {player.Score}\n\n");
                Console.WriteLine($"Dealer Cards: \n{dealer[0]}\n");
                Thread.Sleep(1000);
                //do while loop to hit or stay
                do
                {
                    Console.Write("Would you like to hit?: (y/n): ");
                    choice = Console.ReadLine().ToLower();
                } while (!ValidatedChoice(choice) && player.Score < 21);

                Console.Clear();
                //while the player has not busted and has not chosen to stay
                while (!player.IsBusted && (choice == "y" || choice == "yes") && player.Score < 21)
                {
                    //deal a card
                    player.AddCard(d.Deal());
                    if (player.IsBusted)
                    {
                        Console.WriteLine("You busted!");
                        Console.WriteLine($"Player Cards: \n{player}");
                        Console.Write($"Score: {player.Score}\n\n");
                    }
                    //display cards
                    else
                    {
                        Console.Write($"Player Cards: \n{player}");
                        Console.Write($"Score: {player.Score}\n\n");
                        Console.WriteLine($"Dealer Cards: \n{dealer[0]}");
                        Thread.Sleep(3000);
                        Console.Write("Would you like to hit? (y/n): ");
                        choice = Console.ReadLine().ToLower();
                    }
                }
                
                Console.WriteLine($"Player Cards: \n{player}");
                Console.Write(player.Score);
                Console.WriteLine($"Dealer Cards: \n{dealer}");
                Console.Write(dealer.Score);
                Console.Clear();
                //while the player and dealer have not busted and have less than 17
                while (!player.IsBusted && dealer.Score < 17)
                {
                    dealer.AddCard(d.Deal());
                    Console.Write($"Player Cards: \n{player}");
                    Console.Write($"Score: {player.Score}\n\n");
                    Console.Write($"Dealer Cards: \n{dealer}");
                    Console.Write($"Score: {dealer.Score}\n\n");
                    Thread.Sleep(3000);
                    Console.Clear();
                }

                //determine winner
                DetermineWinner(player, dealer, ref playerWins, ref dealerWins);
                Console.Clear();
                //display wins
                Console.WriteLine($"Player Wins: {playerWins}");
                Console.WriteLine($"Dealer Wins: {dealerWins}");
                Thread.Sleep(3000);
                //ask to play again
                playAgain = PlayAgain();
            } while (playAgain);
        }

        #region Methods

        //method to display instructions
        static void DisplayInstructions()
        {
            string inst;

            Console.Write("Would you like to see instructions on how to play blackjack? (y/n): ");
            inst = Console.ReadLine().ToLower();

            if (inst == "y" || inst == "yes")
            {
                Console.WriteLine("Welcome to BlackJack!");
                Console.WriteLine("The goal of the game is to get as close to 21 as possible without going over.");
                Console.WriteLine(
                    "Face cards are worth 10 points, Aces are worth 1 or 11 points, and all other cards are worth their face value.");
                Console.WriteLine(
                    "The dealer will deal you two cards and deal himself two cards, one face up and one face down.");
                Console.WriteLine("You will then be asked if you want to hit or stay.");
                Console.WriteLine("If you hit, you will be dealt another card.");
                Console.WriteLine("If you stay, you will keep your current hand.");
                Console.WriteLine("If you go over 21, you bust and lose the game.");
                Console.WriteLine("If you stay, the dealer will then reveal his face down card.");
                Console.WriteLine("If the dealer has less than 17, he will hit until he has 17 or more.");
                Console.WriteLine("If the dealer has more than 21, he busts and you win the game.");
                Console.WriteLine("If the dealer has more than you, he wins the game.");
                Console.WriteLine("If you have more than the dealer, you win the game.");
                Console.WriteLine("If you and the dealer have the same score, you tie and the game ends in a draw.");
                Console.WriteLine("Good luck! \n");

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Good luck!");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        //method to determine winner
        static void DetermineWinner(BjHand player, BjHand dealer, ref int playerWins, ref int dealerWins)
        {
            if (player.IsBusted)
            {
                Console.WriteLine($"Player Score: {player.Score}");
                Console.WriteLine($"Dealer Score: {dealer.Score}");
                Console.WriteLine("You busted! Dealer wins!");
                dealerWins++;
            }
            else if (dealer.IsBusted)
            {
                Console.WriteLine($"Player Score: {player.Score}");
                Console.WriteLine($"Dealer Score: {dealer.Score}");
                Console.WriteLine("Dealer busted! You win!");
                playerWins++;
            }
            else if (player.Score > dealer.Score)
            {
                Console.WriteLine($"Player Score: {player.Score}");
                Console.WriteLine($"Dealer Score: {dealer.Score}");
                Console.WriteLine("You win!");
                playerWins++;
            }
            else if (dealer.Score > player.Score)
            {
                Console.WriteLine($"Player Score: {player.Score}");
                Console.WriteLine($"Dealer Score: {dealer.Score}");
                Console.WriteLine("Dealer wins!");
                dealerWins++;
            }
            else
            {
                Console.WriteLine($"Player Score: {player.Score}");
                Console.WriteLine($"Dealer Score: {dealer.Score}");
                Console.WriteLine("It's a tie!");
            }

            Thread.Sleep(3000);
        }

        //method to ask to play again
        static bool PlayAgain()
        {
            string choice;
            do
            {
                Console.WriteLine("Would you like to play again? (y/n): ");
                choice = Console.ReadLine().ToLower();
            } while (!ValidatedChoice(choice));


            return choice == "y" || choice == "yes" ? true : false;
        }
    
        //method to validate choice
        static bool ValidatedChoice(string choice)
        {
            return choice == "y" || choice == "yes" || choice == "n" || choice == "no";
        }

        #endregion
    }
}