using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9_Games
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gamers gamer;
            gamer = new Gamers(String.Empty);
            gamer.collisionTeams();            
        }       
    }
}
