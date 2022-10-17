using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snooker
{
    internal class Versenyzo
    {
        //private-ek
        readonly int helyezes; 
        readonly string nev;
        string orszag;
        decimal nyeremeny;

        //a private-ekből csináltunk publikusakat
        public int Helyezes => helyezes;

        public string Nev => nev;

        public string Orszag { get => orszag; set => orszag = value; }
        public decimal Nyeremeny { get => nyeremeny; set => nyeremeny = value; }

        //konstruktor, lehetőség szerint a publikus tagnak adjuk meg
        public Versenyzo(int helyezes, string nev, string orszag, decimal nyeremeny)
        {
            this.helyezes = helyezes;
            this.nev = nev;
            Orszag = orszag;
            Nyeremeny = nyeremeny;
        }
    }
}
