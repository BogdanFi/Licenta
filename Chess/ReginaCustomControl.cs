using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.Properties;


namespace Chess
{

    public partial class ReginaCustomControl : UserControl
    {
       
        private DateleNouluiJoc DatePiesa;
        public DateleNouluiJoc Info { get { return DatePiesa; } }

        public int BoardSize;
        public Piece[] pieceIdBoard;
        public PictureBox[] pieceBorder;
        public bool FirstMouseClick;
        public int LastX, LastY;
        private int count = 0;

        public ReginaCustomControl()
        {
            InitializeComponent();
            DatePiesa.Save = false;
            BoardSize = CalculeazaMarime(Global.GlobalMarime);
            pieceIdBoard = new Piece[BoardSize * BoardSize];
            pieceBorder = new PictureBox[BoardSize * BoardSize];
            FirstMouseClick = false;

            panel2.Size = new Size(BoardSize * 84, BoardSize * 84);
            panel1.Size = new Size(BoardSize * 84 + 117, BoardSize * 84 + 117);
            groupBox1.Location = new Point(BoardSize * 84 + 125, groupBox1.Location.Y);
            groupBox2.Location = new Point(BoardSize * 84 + 125, groupBox2.Location.Y);
            button1.Location = new Point(button1.Location.X, BoardSize * 84 + 125);
            button2.Location = new Point(button2.Location.X, BoardSize * 84 + 125);
            CreareMarcajeLaterale(BoardSize);

            panel2.BackgroundImage = Image.FromFile(@"C:\Users\rebeg\source\repos\Chess\Resources\board 10x10.png");
            panel2.BackgroundImageLayout = ImageLayout.None;


            for (int i = 0; i < BoardSize * BoardSize; i++)
            {
                CreatePiece(i, this);

                pieceIdBoard[i].PieceName = "-";
                pieceIdBoard[i].PiecePosition = i;
                pieceIdBoard[i].BackColor = Color.Transparent;
                pieceIdBoard[i].PieceValue = 0;
                pieceIdBoard[i].Enumarare = 0;
            }

        }

        private void CreareMarcajeLaterale(int boardSize)
        {
            for (int i = 1; i <= boardSize; i++)
            {
                Label l = new Label();
                panel1.Controls.Add(l);
                l.AutoSize = true;
                l.Size = new Size(13, 13);
                l.Name = "panell" + (boardSize - i + 1);
                l.Text = (boardSize - i + 1).ToString();
                l.Location = new Point(25, 98 + 84 * (i - 1));

                Label l1 = new Label();
                panel1.Controls.Add(l1);
                l1.AutoSize = true;
                l1.Size = new Size(13, 13);
                l1.Name = "panel1" + (boardSize - i + 1);
                l1.Text = Char.ToString((char)(96 + i));
                l1.Location = new Point(85 + 84 * (i - 1), boardSize * 84 + 74);
            }
        }

        public int CalculeazaMarime(MarimeTable globalMarime)
        {
            if (globalMarime == MarimeTable.Patru)
                return 4;
            if (globalMarime == MarimeTable.Cinci)
                return 5;
            if (globalMarime == MarimeTable.Sase)
                return 6;
            if (globalMarime == MarimeTable.Sapte)
                return 7;
            if (globalMarime == MarimeTable.Opt)
                return 8;
            if (globalMarime == MarimeTable.Noua)
                return 9;
            return 10;
        }

        private void CreatePiece(int index, ReginaCustomControl form)
        {
            pieceBorder[index] = new PictureBox
            {
                Location = new Point((index % BoardSize) * 84, BoardSize * 84 - (84 * (index / BoardSize + 1))),
                Size = new Size(84, 84),
                BackColor = Color.Transparent
            };
            form.panel2.Controls.Add(pieceBorder[index]);
            pieceIdBoard[index] = new Piece
            {
                Location = new Point((index % BoardSize) * 84, BoardSize * 84 - (84 * (index / BoardSize + 1))),
                Size = new Size(84, 84),
            };


            pieceIdBoard[index].MouseClick += new MouseEventHandler(MouseClick);
            form.panel2.Controls.Add(pieceIdBoard[index]);
            pieceIdBoard[index].BackgroundImageLayout = ImageLayout.Center;
            pieceIdBoard[index].BringToFront();
            pieceIdBoard[index].BackColor = Color.Transparent;
        }


        private void MouseClick(object sender, MouseEventArgs e)
        {
            Piece piece = sender as Piece;
            if (!FirstMouseClick)
            {
                Image imagn;
                if (Global.GlobalCuloare == CuloarePiesa.Negru)
                    imagn = Resources.BP;
                else
                    imagn = Resources.WP;
                pieceIdBoard[piece.PiecePosition].Image = imagn;
                pieceIdBoard[piece.PiecePosition].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                pieceIdBoard[piece.PiecePosition].PieceName = "Wp";
                pieceIdBoard[piece.PiecePosition].PieceValue = 10;
                pieceIdBoard[piece.PiecePosition].Enumarare = ++count;
                label1.Text = "Selectați modul în care se va deplasa regina";
                FirstMouseClick = true;
                LastX = piece.Location.X;
                LastY = piece.Location.Y;
            }
            else
            if (e.Button == MouseButtons.Left)
            {
                if ((Math.Abs(piece.Location.X - LastX) / 84 == 1 && Math.Abs(piece.Location.Y - LastY) / 84 == 1) ||
                    (Math.Abs(piece.Location.X - LastX) / 84 == 0 && Math.Abs(piece.Location.Y - LastY) / 84 == 1) ||
                    (Math.Abs(piece.Location.X - LastX) / 84 == 1 && Math.Abs(piece.Location.Y - LastY) / 84 == 0))
                {
                    pieceIdBoard[piece.PiecePosition].BackColor = Color.Yellow;
                    LastX = piece.Location.X;
                    LastY = piece.Location.Y;
                    pieceIdBoard[piece.PiecePosition].Enumarare = ++count;
                }
                else
                {
                    MessageBox.Show("Căsuța selectată trebuie să fie legată de căsuța precedent selectată", "Eroare");
                }

            }
            else
                if (e.Button == MouseButtons.Right)
            {
                pieceIdBoard[piece.PiecePosition].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                pieceIdBoard[piece.PiecePosition].BackColor = Color.FromArgb(255, 213, 0);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int i, j;
            string[] a = new string[count];
            if (count >= 2)
            {
                for (i = 1; i <= count; i++)

                    for (j = 1; j < BoardSize * BoardSize; j++)
                    {
                        if (pieceIdBoard[j].Enumarare == i)
                        {
                            a[i - 1] = ((char)('a' + (pieceIdBoard[j].Location.X / 84))).ToString() + (BoardSize - pieceIdBoard[j].Location.Y / 84).ToString();
                            break;
                        }
                    }
                DatePiesa.MutarilePiesei = a;
                DatePiesa.Save = true;
                RadioButton raspuns1 = RadioButtonHelper.GetCheckedRadio(groupBox1);
                RadioButton raspuns2 = RadioButtonHelper.GetCheckedRadio(groupBox2);
                if (raspuns1 == radioButton2)
                    DatePiesa.RaspunsIntrb1 = false;
                else
                    DatePiesa.RaspunsIntrb1 = true;
                if (raspuns2 == radioButton4)
                    DatePiesa.RaspunsIntrb2 = false;
                else
                    DatePiesa.RaspunsIntrb2 = true;

            }
            else
                MessageBox.Show("Trebuie să aveți măcar o mutare selectată");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Selectați poziția de start a reginei";
            for (int i = 0; i < BoardSize * BoardSize; i++)
            {


                pieceIdBoard[i].PieceName = "-";
                pieceIdBoard[i].PiecePosition = i;
                pieceIdBoard[i].BackColor = Color.Transparent;
                pieceIdBoard[i].PieceValue = 0;
                pieceIdBoard[i].Enumarare = 0;
                pieceIdBoard[i].Image = null;
            }
            FirstMouseClick = false;
            radioButton1.Checked = false;
            radioButton3.Checked = false;
            radioButton2.Checked = true;
            radioButton4.Checked = true;
            DatePiesa.Save = false;
        }


    }
}
