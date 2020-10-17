using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Game
    {
        List<Player> players;
        Queue<Card> cardsDeck;

        public Game()
        {
            cardsDeck = new Queue<Card>();
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        cardsDeck.Enqueue(new Card((Suit)i, (Rank)j));
                    }
                }
            };

            players = new List<Player>();
        }

        public void AddPlayer(Player p)
        {
            players.Add(p);
            Console.WriteLine("Player has been added.");
            Console.WriteLine();
        }

        public void ShowCardsAllPlayers()
        {
            int count = 1;
            foreach (var item in players)
            {
                Console.WriteLine($"Player{count} cards: ");
                item.ShowCards();
                count++;
            }
        }



        public void Gameplay()
        {
            int index = 0;

            bool isWin = false;
            List<Card> tempCards = new List<Card>(players.Count);

            do
            {
                for (int i = 0; i < players.Count; i++)
                {
                    if (players[i].Cards.Count > 0)
                    {
                        Console.WriteLine($"Player{i + 1} put card:{players[i].Cards.Peek().Suit} {players[i].Cards.Peek().Rank}");
                        tempCards.Add(players[i].Cards.Dequeue());
                    }
                }

                for (int i = 0; i < tempCards.Count; i++)
                {
                    if (tempCards[i] != null && tempCards[index].CompareTo(tempCards[i]) < 0)
                        index = i;
                }

                Console.WriteLine($"Max card is {tempCards[index].Suit} {tempCards[index].Rank}. Player{index + 1} takes all cards!");
                for (int i = 0; i < tempCards.Count; i++)
                {
                    players[index].AddCard(tempCards[i]);
                }

                Console.WriteLine();
                Console.Write("The number of cards for each player: ");
                foreach (var item in players)
                {
                    Console.Write(item.Cards.Count + " ");
                }
                Console.WriteLine();

                tempCards.Clear();


                if (players[index].Cards.Count == 36)
                {
                    Console.WriteLine($"Player{index + 1} win!");
                    isWin = true;
                }


                index = 0;
                Console.WriteLine();
            } while (!isWin);
        }

        public void Shuffle()
        {
            if (cardsDeck.Count == 0)
                throw new InvalidOperationException("\nQueue is empty!\n");

            Random rand = new Random();
            int size = cardsDeck.Count();
            Card[] copyQueue = new Card[size];
            copyQueue = cardsDeck.ToArray();


            for (int i = copyQueue.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                var temp = copyQueue[j];
                copyQueue[j] = copyQueue[i];
                copyQueue[i] = temp;
            }

            cardsDeck.Clear();
            for (int i = 0; i < copyQueue.Length; i++)
            {
                cardsDeck.Enqueue(copyQueue[i]);
            }
            Console.WriteLine("The deck of cards was shuffled!");
            Console.WriteLine();
        }

        public void DistributeCards()
        {
            int remainder;


            if (cardsDeck.Count == 0)
                throw new InvalidOperationException("\nCarddeck is empty!\n");

            int cardInDeck = cardsDeck.Count / players.Count;
            if (cardsDeck.Count % players.Count == 0 && players.Count < 9)
            {
                for (int i = 0; i < cardInDeck; i++)
                {
                    foreach (Player player in players)
                    {
                        Card temp = cardsDeck.Dequeue();
                        player.AddCard(temp);

                    }
                }
                Console.WriteLine($"{cardInDeck} cards were dealt to the players.");
            }
            else if (cardsDeck.Count % players.Count != 0 && players.Count < 9)
            {
                cardInDeck = cardsDeck.Count / players.Count;
                remainder = cardsDeck.Count - cardInDeck * players.Count;

                for (int i = 0; i < cardInDeck; i++)
                {
                    foreach (Player player in players)
                    {
                        Card temp = cardsDeck.Dequeue();
                        player.AddCard(temp);
                    }
                }

                for (int i = 0; i < remainder; i++)
                {

                    foreach (Player player in players)
                    {
                        if (cardsDeck.Count == 0)
                            break;
                        Card temp = cardsDeck.Dequeue();
                        player.AddCard(temp);

                    }
                }
                int count = 1;

                foreach (var item in players)
                {
                    Console.WriteLine($"Player{count} received {item.Cards.Count()} cards.");
                    count++;
                }
            }
            else
                throw new InvalidOperationException("\nPlayers cannot be more than 9!\n");


            Console.WriteLine();
        }
    }
}
