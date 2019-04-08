using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Poker_Game.Models
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.Hand = new Hand();
        }
        public string Name { get; set; }

        public virtual Hand Hand { get; set; }

        public bool Flush()
        {
            var card = new Card();
            card = Hand.Cards.FirstOrDefault();
            foreach (var item in Hand.Cards)
            {
                if (item.Naipe != card.Naipe)
                {
                    return false;
                }
            }

            var temp = Hand.Cards.OrderBy(x => x.Sequence).ToList();
            if (temp.Exists(x => x.Sequence == EnumSequence.As))
                return true;

            return false;
        }

        public bool Straight()
        {
            var temp = Hand.Cards.OrderBy(x => x.Sequence).ToList();
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
            var teste = result.Select(x => x.count).Max();
            if (teste == 3)
                return true;

            return false;
        }
        public bool onePair()
        {
            var result = from x in Hand.Cards
                         group x by x.Sequence into cards
                         select new { carta = cards.Key, count = cards.Count() };
            var cont = result.Select(x => x.count).Max();
            if (cont == 2)
                return true;

            return false;
        }

        public bool TwoPair()
        {
            var retorno = from x in Hand.Cards
                          group x by x.Sequence into cards
                          select new { carta = cards.Key, count = cards.Count() };

            var result = retorno.Where(x => x.count == 2).ToList();
            if (result.Count == 2)
                return true;
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
            var cont = result.Select(x => x.cont).Max();

            if (cont == 4)
                return true;
            return false;
        }

    }
}