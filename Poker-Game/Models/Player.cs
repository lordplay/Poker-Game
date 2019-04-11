using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker_Game.Models
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }
        public string Name { get; set; }

        public virtual Hand Hand { get; set; }

        public string Wtf { get; set; }

        public string WhatDoIHave()
        {
            List<Func<Boolean>> funcs = new List<Func<bool>>();
            funcs.Add(RoyalFlush);
            funcs.Add(StraightFlush);
            funcs.Add(FourOfAKind);
            funcs.Add(FullHouse);
            funcs.Add(Flush);
            funcs.Add(Straight);
            funcs.Add(ToAK);
            funcs.Add(TwoPair);
            funcs.Add(OnePair);
            funcs.Add(HighCard);

            foreach (var item in funcs)
            {
                if (item() == true)
                {
                    Wtf = item.Method.Name;
                    return Wtf;
                }
            }
            return "Nada";
        }

        public bool StraightFlush()
        {
            Card card = new Card();
            card = Hand.Cards.FirstOrDefault();
            foreach (Card item in Hand.Cards)
            {
                if (item.Naipe != card.Naipe)
                {
                    return false;
                }
            }

            List<Card> temp = Hand.Cards.OrderBy(x => x.Sequence).ToList();
            if (temp.Exists(x => x.Sequence == EnumSequence.As))
            {
                return true;
            }

            return false;
        }

        public bool Straight()
        {
            List<Card> temp = Hand.Cards.OrderBy(x => x.Sequence).ToList();
            List<int> tempo = new List<int>();

            for (int i = 0; i < temp.Count() - 1; i++)
            {
                if (Convert.ToInt32(temp[i].Sequence) + 1 != Convert.ToInt32(temp[i + 1].Sequence))
                    return false;
            }
            return true;
        }

        public bool ToAK()
        {
            var result = from x in Hand.Cards
                         group x by x.Sequence into cards
                         select new { carta = cards.Key, count = cards.Count() };
            int teste = result.Select(x => x.count).Max();
            if (teste == 3)
            {
                return true;
            }

            return false;
        }
        public bool OnePair()
        {
            var result = from x in Hand.Cards
                         group x by x.Sequence into cards
                         select new { carta = cards.Key, count = cards.Count() };
            int cont = result.Select(x => x.count).Max();
            if (cont == 2)
            {
                return true;
            }

            return false;
        }

        public bool TwoPair()
        {
            var retorno = from x in Hand.Cards
                          group x by x.Sequence into cards
                          select new { carta = cards.Key, count = cards.Count() };

            var result = retorno.Where(x => x.count == 2).ToList();
            if (result.Count == 2)
            {
                return true;
            }

            return false;
        }
        public bool HighCard()
        {
            Hand.Cards.Select(x => x.Sequence).Max();
            return true;
        }

        public bool FourOfAKind()
        {
            var result = from x in Hand.Cards
                         group x by x.Sequence into cards
                         select new { carta = cards.Key, cont = cards.Count() };
            int cont = result.Select(x => x.cont).Max();

            if (cont == 4)
            {
                return true;
            }

            return false;
        }

        public bool Flush()
        {
            Card card = Hand.Cards.FirstOrDefault();
            foreach (Card item in Hand.Cards)
            {
                if (item.Naipe != card.Naipe)
                {
                    return false;
                }
            }
            return true;
        }

        public bool FullHouse()
        {
            var result = from x in Hand.Cards
                         group x by x.Sequence into cards
                         select new { carta = cards.Key, count = cards.Count() };
            var cont = result.Select(x => x.count).ToList();
            if (cont.Contains(3) && cont.Contains(2))
                return true;
            return false;
        }

        public bool RoyalFlush()
        {
            var temp = Hand.Cards.OrderBy(x => x.Sequence).ToArray();
            if (temp.Select(x => x.Naipe).Distinct().Count() > 1)
                return false;

            for (int i = 10, c = 0; i < 15; i++, c++)
            {
                if (temp[c].Sequence != (EnumSequence)i)
                    return false;
            }
            return true;
        }

    }
}