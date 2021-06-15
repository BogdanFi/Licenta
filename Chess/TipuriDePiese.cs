using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    [Serializable]
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

    [Serializable]
    public struct DateCastigPartida
    {
        private string nume;
        private string[] mutari;
        private bool Raspuns1;
        private bool Raspuns11;
        private bool Raspuns2;
        private int coloane;
        private int randuri;
        private CuloarePiesa cul;

        public string NumePiesa { get { return nume; } set { nume = value; } }

        public string[] MutariPozitie { get { return mutari; } set { mutari = value; } }
        
        public bool RaspunsIntrebare1 { get { return Raspuns1; } set { Raspuns1 = value; } }

        public bool RaspunsIntrebare11 { get { return Raspuns11; } set { Raspuns11 = value; } }

        public bool RaspunsIntrebare2 { get { return Raspuns2; } set { Raspuns2 = value; } }
        public int NumarColoane { get { return coloane; } set { coloane = value; } }
        public int NumarRanduri { get { return randuri; } set { randuri = value; } }
        public CuloarePiesa Culoare { get { return cul; } set { cul = value; } }
       
    }
    public enum CuloarePiesa
    {
        Alb,
        Negru
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
