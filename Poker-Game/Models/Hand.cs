using System.Collections.Generic;

namespace Poker_Game.Models
{
    public class Hand
    {
        public Hand()
        {
            this.Cards = new HashSet<Card>();
        }
        public virtual ICollection<Card> Cards { get; set; }
    }
}