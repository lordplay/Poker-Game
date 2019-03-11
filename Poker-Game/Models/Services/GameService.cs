using System;
using System.Collections.Generic;
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

            //Adicionar cartas na mesa 
            AdicionarCartasNaMesa();


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
                for (int i = 0; i < 2; i++)
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

            foreach (var player in Players)
            {
                //Verificar a mao de cada jogador
            }
        }

        public void VerificarCartasJogadores()
        {

        }

    }

}