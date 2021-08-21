using System;
using System.IO;

namespace Blackjack_csharp
{
    public class Player
    {
        public String name;
        private Boolean playing;
        public int score;
        private CardStack cardStack;

        public Player(CardStack cardStack, int id)
        {
            name = "Player " + id.ToString();
            playing = false;
            score = 0;
            this.cardStack = cardStack;
        }

        private void Action()
        {
            String input;

            while (true)
            {
                try
                {
                    Console.WriteLine("Draw or pass? Enter 'd' or 'p' and press return.");
                    input = (Console.ReadLine()).ToUpper();
                    break;
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Invalid input.");
                }
            }

            switch (input)
            {
                case "D":
                    this.Evaluate(this.cardStack.Draw());
                    break;
                case "P":
                    this.playing = false;
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    this.Action();
                    break;
            }
        }

        private void Evaluate(Card card)
        {
            score += card.value;
            Console.WriteLine($"Score: {score}");
            if (score > 21)
            {
                Console.WriteLine("You've lost!");
                this.playing = false;
            }
        }

        public void Turn()
        {
            this.playing = true;

            Console.WriteLine(this.name);
            while (this.playing)
            {
                this.Action();
            }
        }


    }
}
