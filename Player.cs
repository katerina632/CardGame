using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Player
    {
        public Queue<Card> Cards { get; }
        public Player()
        {
            Cards = new Queue<Card>();
        }
        public void AddCard(Card c)
        {
            Cards.Enqueue(c);
        }

        public Card PeekCard()
        {
            return Cards.Peek();
        }

        public void DequeueCard()
        {
            Cards.Dequeue();
        }

        public void ShowCards()
        {
            if (Cards.Count == 0)
                throw new InvalidOperationException("\nQueue is empty!\n");

            int count = 0;
            foreach (Card c in Cards)
            {
                Console.Write($"{c.Suit} {c.Rank}\t");
                count++;
                if (count == 4)
                {
                    Console.WriteLine();
                    count = 0;
                }

            }
            Console.WriteLine();
            Console.WriteLine();
        }


    }
}
