using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class Piece : PictureBox
    {
        public string PieceName { get; set; }
        public int PiecePosition { get; set; }
        public bool IsFirstMove { get; set; }
        public int PieceValue { get; set; }

        public int Enumarare { get; set; }

        public int Capturare { get; set; }

        public Piece()
        {
            PieceName = "-";
            PiecePosition = 0;
            IsFirstMove = true;
            PieceValue = 0;
            Enumarare = 0;
            Capturare = 0;
        }
    }
}
