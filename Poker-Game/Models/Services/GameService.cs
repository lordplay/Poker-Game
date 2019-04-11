using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Poker_Game.Models.Services
{
    public class GameService
    {
        List<Player> Players = new List<Player>();
        List<Card> Deck = new List<Card>();
        List<Card> Mesa = new List<Card>();

        public void Orquestrador()
        {
            //Criar jogadores
            CriarJogador();

            //Criar Deck
            CriarDeck();

            //Popular a mao dos jogadores
            StartHands();

            //CheatMode();

            VerificarCartasJogadores();

        }

        public void CheatMode()
        {
            int mode;
            Random random = new Random();
            var Cheat = new CheatMode();

            foreach (var player in Players)
            {
                mode = random.Next(1, 4);

                switch (mode)
                {
                    case 1:
                        player.Hand.Cards = Cheat.RoyalFlush();
                        break;
                    case 2:
                        player.Hand.Cards = Cheat.ToK();
                        break;
                    case 3:
                        player.Hand.Cards = Cheat.Straight();
                        break;
                    case 4:
                        player.Hand.Cards = Cheat.FourOfAKind();
                        break;
                    default:
                        break;
                }

            }

        }

        public void CriarJogador()
        {
            for (int i = 0; i < 4; i++)
            {
                Player player = new Player("Player " + i);
                Players.Add(player);
            }
        }

        public void CriarDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int x = 2; x <= 14; x++)
                {
                    Card card = new Card();
                    card.Naipe = (EnumNaipe)i;
                    card.Sequence = (EnumSequence)x;
                    Deck.Add(card);
                }
            }
        }

        //Popular cada mao de jogador com 2 cartas
        public void StartHands()
        {
            foreach (var player in Players)
            {
                for (int i = 0; i < 5; i++)
                {
                    player.Hand.Cards.Add(GetRandomCardFromDeck());
                }
            }
        }

        //
        public Card GetRandomCardFromDeck()
        {
            Random random = new Random();
            var index = random.Next(0, Deck.Count());
            var retorno = Deck[index];
            Deck.RemoveAt(index);
            return retorno;
        }

        //
        public void AdicionarCartasNaMesa()
        {
            Mesa.Add(GetRandomCardFromDeck());

        }

        public void VerificarCartasJogadores()
        {

            foreach (var player in Players)
            {
                player.WhatDoIHave();
                Debug.WriteLine(player.Name + " => " + player.Wtf);
            }

        }

    }

}