using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poker_Game.Models.Services
{
    public class CheatMode
    {
        public List<Card> RoyalFlush()
        {
            List<Card> cards = new List<Card>();

            for (int i = 10; i < 15; i++)
            {
                cards.Add(new Card { Naipe = EnumNaipe.Copas, Sequence = (EnumSequence)i });
            }
            return cards;
        }

        public List<Card> ToK()
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < 3; i++)
            {
                cards.Add(new Card { Naipe = (EnumNaipe)i, Sequence = EnumSequence.Ten });
            }
            cards.Add(new Card { Naipe = EnumNaipe.Copas, Sequence = EnumSequence.As });
            cards.Add(new Card { Naipe = EnumNaipe.Copas, Sequence = EnumSequence.Dama });
            return cards;
        }

        internal List<Card> Straight()
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                cards.Add(new Card { Naipe = EnumNaipe.Copas, Sequence = (EnumSequence)i });
            }
            return cards;
        }

        internal List<Card> FourOfAKind()
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                cards.Add(new Card { Naipe = (EnumNaipe)i, Sequence = EnumSequence.Ten });
            }
            cards.Add(new Card { Naipe = EnumNaipe.Copas, Sequence = EnumSequence.Dama });
            return cards;
        }
    }
}