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

        public void WhatInMyHand(List<Card> cards)
        {
            cards.AddRange(Hand.Cards);


        }

        public bool RoyalFlush(List<Card> cards)
        {

        }

    }
}