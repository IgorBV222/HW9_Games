using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HW9_Games
{
    internal class Gamers
    {
        static private int myRandom()
        {
            Random random = new Random();
            var currentTime = DateTime.Now.Millisecond;
            int Number = currentTime;
            Number *= Number;
            int _myRandom = 1 + random.Next(Number) % 100;
            return _myRandom;
        }
        public Gamers(string name)
        {
            this.name = name;
            coin = myRandom()*2;
            valor = myRandom();
            luck = myRandom()*3;
        }
        private string name;
        public string _name
        {
            get { return name; }
            set { name = value; }            
        }       
        private int coin;
        public int _coin
        {
            get { return coin; }
            set { coin = value; }
        }       
        private int valor;
        public int _valor
        {
            get { return valor; }
            set { valor = value; }
        }   
        private int luck;
        public int _luck
        {
            get { return luck; }
            set { luck = value; }
        }       
        public static bool operator > (Gamers player1, Gamers player2)
        {
            if ((player1._coin < player2._coin & player1._valor > player2._valor) |
                (player1._coin > player2._coin & player1._valor > player2._valor) |
                (player1._coin == player2._coin & player1._valor == player2._valor & player1._luck > player2._luck))
            {
                return true;
            }
            else
            {
               return false;
            }            
        }
        public static bool operator < (Gamers player1, Gamers player2)
        {
            if ((player1._coin == player2._coin & player1._valor < player2._valor) | 
                (player1._valor == player2._valor & player1._coin < player2._coin) |
                (player1._coin < player2._coin & player1._valor <player2._valor) |
                (player1._coin == player2._coin & player1._valor == player2._valor & player1._luck < player2._luck))
            {
                return true;
            }
            else
            {
               return false;
            }            
        }
        public static bool operator == (Gamers player1, Gamers player2)
        {
            if (player1._coin == player2._coin & player1._valor == player2._valor & player1._luck == player2._luck)
            {
                return true;    
            }
            else 
            { 
                return false; 
            }
        }
        public static bool operator !=(Gamers player1, Gamers player2)
        {
            if ((player1._coin != player2._coin) && (player1._valor != player2._valor) && (player1._luck != player2._luck))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static Gamers CreatePlayer()
        {            
            string name = Console.ReadLine();
            Gamers player = new Gamers(name);            
            return player;
        }
        public static List<Gamers> players = new List<Gamers>();
        public static List<Gamers> playersInput()
        {
            Console.WriteLine("Enter number of players: ");
            int numberOfPlayers = int.Parse(Console.ReadLine());
            List<Gamers> players = new List<Gamers>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
               Console.WriteLine($"Enter the name of the {i+1}-th player: ");
               players.Add(CreatePlayer());
               Console.WriteLine($"Player {players[i]._name}: Coins - {players[i]._coin}, Valor - {players[i]._valor}, Luck - {players[i]._luck}\n");
            }
            return players;
        }      

        private Gamers team1;
        private Gamers team2;
        public void CreateTeams()
        {
            int coinTeam1 = 0, coinTeam2 = 0, valorTeam1 = 0, valorTeam2 = 0, luckTeam1 = 1, luckTeam2 = 1;
            string nameTeam1 = "", nameTeam2 = "";
            List<Gamers> players = new List<Gamers>();
            players = playersInput();
            for (int i = 0; i < players.Count; i++)
            {
                if (i % 2 == 0)
                {
                    coinTeam1 += players[i]._coin;
                    valorTeam1 += players[i]._valor;
                    luckTeam1 *= players[i]._luck;
                    nameTeam1 += players[i]._name[0];
                }
                else
                {
                    coinTeam2 += players[i]._coin;
                    valorTeam2 += players[i]._valor;
                    luckTeam2 *= players[i]._luck;
                    nameTeam2 += players[i]._name[0];
                }
            }
            team1 = new Gamers(nameTeam1);
            team1._valor = valorTeam1;
            team1._coin = coinTeam1;
            team1._luck = luckTeam1;           
            team2 = new Gamers(nameTeam2);
            team2._valor = valorTeam2;
            team2._coin = coinTeam2;
            team2._luck = luckTeam2;           
        }
        public void collisionTeams()
        {
            CreateTeams();
            if (team1 > team2)
            {
                Console.WriteLine($"Team 1 '{team1._name}' won!");
                Console.WriteLine($"Team 1 '{team1._name}': Coins - {team1._coin}, Valor - {team1._valor}, Luck - {team1._luck}");
                Console.WriteLine($"Team 2 '{team2._name}': Coins - {team2._coin}, Valor - {team2._valor}, Luck - {team2._luck}");
            }
            else             
                if (team1 < team2)
            {
                Console.WriteLine($"Team 2 '{team2._name}' won!");
                Console.WriteLine($"Team 1 '{team1._name}': Coins - {team1._coin}, Valor - {team1._valor}, Luck - {team1._luck}");
                Console.WriteLine($"Team 2 '{team2._name}': Coins - {team2._coin}, Valor - {team2._valor}, Luck - {team2._luck}");
            }           
            else
                if(team1 == team2)
            {
                Console.WriteLine("Draw in the game!");
                Console.WriteLine($"Team 1 '{team1._name}': Coins - {team1._coin}, Valor - {team1._valor}, Luck - {team1._luck}");
                Console.WriteLine($"Team 2 '{team2._name}': Coins - {team2._coin}, Valor - {team2._valor}, Luck - {team2._luck}");
            }
            Console.ReadKey();
        }   
    }
}
