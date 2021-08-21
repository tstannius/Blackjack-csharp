using System;
using System.IO;
using System.Collections.Generic;

namespace Blackjack_csharp
{
    public class Game
    {
        public List<Player> players;
        public CardStack cardStack;

        public Game()
        {
            players = new List<Player>();
            cardStack = new CardStack();
            cardStack.Shuffle();
        }

        private void Setup()
        {
            int playerCount = 0;

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter number of players (2-4) and press return.\n");
                    String input = Console.ReadLine();
                    playerCount = Int32.Parse(input);
                    break;
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Invalid input.");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid input.");
                }
            }

            if (playerCount < 2 || playerCount > 4)
            {
                Console.WriteLine("Invalid input.");
                this.Setup();
            }
            else
            {
                for (int i = 0; i < playerCount; i++)
                {
                    players.Add(new Player(cardStack, (i + 1)));
                }
            }
        }

        private void Run()
        {
            int winningScore = 0;
            String winner = "... no one! Everyone lost!";

            for (int i = 0; i < players.Count; i++)
            {
                players[i].Turn();
            }

            for (int i = 0; i < players.Count; i++)
            {
                Player p = players[i];
                if (p.score < 22 && p.score > winningScore)
                {
                    winningScore = p.score;
                    winner = p.name;
                }
            }

            Console.WriteLine($"The winner is {winner}");
        }

        public void Play()
        {
            this.Setup();
            this.Run();
        }
    }
}
