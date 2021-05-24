using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public struct DateleNouluiJoc
    {
        private string nume;
        private string[] mutari;
        private string[] mutariCaptura;
        private bool Raspuns1;
        private bool Raspuns2;
        private bool Raspuns3;
        private bool save;

        public string NumelePiesei { get { return nume; } set { nume = value; } }
        public string[] MutarilePiesei { get { return mutari; } set { mutari = value; } }
        public string[] MutarilePieseiCaptura { get { return mutariCaptura; } set { mutariCaptura = value; } }
        public bool RaspunsIntrb1 { get { return Raspuns1; } set { Raspuns1 = value; } }
        public bool RaspunsIntrb2 { get { return Raspuns2; } set { Raspuns2 = value; } }
        public bool RaspunsIntrb3 { get { return Raspuns3; } set { Raspuns3 = value; } }
        public bool Save { get { return save; } set { save = value; } }
    }
    public enum CuloarePiesa
    {
        Alb,
        Negru
    }
    public enum TipJoc
    {
        Clasic,
        ReguliSchimbate
    }
    public enum MarimeTable
    {
        Patru,
        Cinci,
        Sase,
        Sapte,
        Opt,
        Noua,
        Zece
    }
}
