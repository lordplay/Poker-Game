using System.Collections.Generic;

namespace Poker_Game.Models
{
    public class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }
        public virtual List<Card> Cards { get; set; }
    }
}