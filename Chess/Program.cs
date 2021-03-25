using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    static class Global
    {
        private static CuloarePiesa _Culoare;
        private static MarimeTable _Marime;
        public static CuloarePiesa GlobalCuloare
        {
            get { return _Culoare; }
            set { _Culoare = value; }
        }

        public static MarimeTable GlobalMarime
        {
            get { return _Marime; }
            set { _Marime = value; }
        }
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
