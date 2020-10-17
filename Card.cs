using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    enum Suit { Hearts = 0, Diamonds, Clubs, Spades };
    enum Rank { _6 = 0, _7, _8, _9, _10, _J, _Q, _K, _A };
    class Card: IComparable<Card>
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public int CompareTo(Card other)
        {
            return (((int)Rank).CompareTo((int)other.Rank));
        }
    }
}
