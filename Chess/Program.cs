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
        private static MarimeTable _MarimeColoane;
        private static MarimeTable _MarimeLinii;
        public static CuloarePiesa GlobalCuloare
        {
            get { return _Culoare; }
            set { _Culoare = value; }
        }

        public static MarimeTable GlobalMarimeLinii
        {
            get { return _MarimeLinii; }
            set { _MarimeLinii = value; }
        }
        public static MarimeTable GlobalMarimeColoane
        {
            get { return _MarimeColoane; }
            set { _MarimeColoane = value; }
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
            //Application.Run(new ExportGame());
            Application.Run(new Form1());
        }
    }
}
