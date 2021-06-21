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
   
    public partial class PionCustomControl : UserControl
    {
        
        private DateleNouluiJoc DatePiesa;
        public DateleNouluiJoc Info { get { return DatePiesa; } }

        public int BoardSizeL ;
        public int BoardSizeC;
        public Piece[] pieceIdBoard;
        public PictureBox[] pieceBorder;
        public bool FirstMouseClick;
        public int LastX, LastY;
        private int count = 0;
        private int countt = 0;
        private int negativecount = 0;
        static int pornit = 0;
        private Color Culoarea;
        public PionCustomControl()
        {
            InitializeComponent();
            DatePiesa.Save = false;
            BoardSizeL = CalculeazaMarime(Global.GlobalMarimeLinii);
            BoardSizeC = CalculeazaMarime(Global.GlobalMarimeColoane);
            pieceIdBoard = new Piece[BoardSizeC*BoardSizeL];
            pieceBorder = new PictureBox[BoardSizeC * BoardSizeL];
            FirstMouseClick = false;
            Culoarea=Color.Yellow;

            panel2.Size = new Size(BoardSizeC*84,BoardSizeL * 84);
            panel1.Size = new Size(BoardSizeC * 84 + 117, BoardSizeL * 84 + 117);
            groupBox1.Location = new Point(BoardSizeC * 84 + 125, groupBox1.Location.Y);
            groupBox2.Location = new Point(BoardSizeC * 84 + 125, groupBox2.Location.Y);
            groupBox3.Location = new Point(BoardSizeC * 84 + 125, groupBox3.Location.Y);
            button1.Location = new Point(button1.Location.X, BoardSizeL * 84 + 125);
            button2.Location = new Point(button2.Location.X, BoardSizeL * 84 + 125);
            button3.Location = new Point(button3.Location.X, BoardSizeL * 84 + 116);
            CreareMarcajeLaterale(BoardSizeL,BoardSizeC);

            panel2.BackgroundImage = Image.FromFile(@"C:\Users\rebeg\source\repos\Chess\Resources\board 10x10.png");
            panel2.BackgroundImageLayout = ImageLayout.None;
            
                

            for (int i = 0; i < BoardSizeC*BoardSizeL; i++)
            {
                CreatePiece(i, this);

                pieceIdBoard[i].PieceName = "-";
                pieceIdBoard[i].PiecePosition = i;
                pieceIdBoard[i].BackColor = Color.Transparent;
                pieceIdBoard[i].PieceValue = 0;
                pieceIdBoard[i].Enumarare = 0;
                pieceIdBoard[i].Capturare = 0;
            }

        }

        private void CreareMarcajeLaterale(int boardSizeL,int boardSizeC)
        {
            for (int i = 1; i <= boardSizeL; i++)
            {
                Label l = new Label();
                panel1.Controls.Add(l);
                l.AutoSize = true;
                l.Size = new Size(13, 13);
                l.Name = "panell" + (boardSizeL - i + 1);
                l.Text = (boardSizeL - i + 1).ToString();
                l.Location = new Point(25, 98 + 84 * (i - 1));
            }
            for (int i = 1; i <= boardSizeC; i++)
            { 
                Label l1 = new Label();
                panel1.Controls.Add(l1);
                l1.AutoSize = true;
                l1.Size = new Size(13, 13);
                l1.Name = "panel1" + (boardSizeC - i + 1);
                l1.Text = Char.ToString((char)(96 + i)) ;
                l1.Location = new Point(85 + 84 * (i - 1),boardSizeL*84+74);
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

        private void CreatePiece(int index, PionCustomControl form)
        {
            pieceBorder[index] = new PictureBox
            {
                Location = new Point((index % BoardSizeC) * 84, BoardSizeL*84 - (84 * (index / BoardSizeC + 1))),
                Size = new Size(84, 84),
                BackColor = Color.Transparent
            };
            form.panel2.Controls.Add(pieceBorder[index]);
            pieceIdBoard[index] = new Piece
            {
                Location = new Point((index % BoardSizeC) * 84, BoardSizeL*84 - (84 * (index / BoardSizeC + 1))),
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
                if (piece.PiecePosition < BoardSizeC * 2)
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
                    label1.Text = "Selectați modul în care se va deplasa pionul";
                    FirstMouseClick = true;
                    LastX = piece.Location.X;
                    LastY = piece.Location.Y;
                }
                else
                    MessageBox.Show("Piesa de start trebuie să fie așezată pe primele 2 rânduri ale tabelei");
            }
            else
            if (e.Button == MouseButtons.Left)
            {
                if (pieceIdBoard[piece.PiecePosition].Enumarare != 0)
                {
                    MessageBox.Show("Nu aveți voie să selectați de 2 ori aceeași căsuță!");
                    return;
                }
                if ((Math.Abs(piece.Location.X - LastX)/84 == 1 && Math.Abs(piece.Location.Y - LastY)/84 == 1) ||
                    (Math.Abs(piece.Location.X - LastX)/84 == 0 && Math.Abs(piece.Location.Y - LastY)/84 == 1) ||
                    (Math.Abs(piece.Location.X - LastX)/84 == 1 && Math.Abs(piece.Location.Y - LastY)/84 == 0))
                {
                    if (Culoarea == Color.Yellow)
                        pieceIdBoard[piece.PiecePosition].Enumarare = ++count;
                    else
                        pieceIdBoard[piece.PiecePosition].Enumarare = --negativecount;
                    pieceIdBoard[piece.PiecePosition].BackColor = Culoarea;
                    LastX = piece.Location.X;
                    LastY = piece.Location.Y;
                    
                }
                else
                {
                    MessageBox.Show("Căsuța selectată trebuie să fie legată de căsuța precedent selectată", "Eroare");
                }

            }
            else
                if(e.Button == MouseButtons.Right && pornit == 1)
            {
                if( pieceIdBoard[piece.PiecePosition].Capturare!=0|| pieceIdBoard[piece.PiecePosition].Enumarare == 1)
                {
                    MessageBox.Show("Nu aveți voie să selectați de 2 ori aceeași căsuță!");
                    return;
                }
                pieceIdBoard[piece.PiecePosition].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                pieceIdBoard[piece.PiecePosition].BackColor = Color.FromArgb(255, 213, 0);
                pieceIdBoard[piece.PiecePosition].Capturare = ++countt;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int i, j;
            string[] a= new string[count];
            string[] b = new string[0 - negativecount+1];
            if (count >= 2)
            {
                for (i = 1; i <= count; i++)

                    for (j = 1; j < BoardSizeC * BoardSizeL; j++)
                    {
                        if (pieceIdBoard[j].Enumarare == i)
                        {
                            a[i - 1] = ((char)('a' + (pieceIdBoard[j].Location.X / 84))).ToString() + (BoardSizeL - pieceIdBoard[j].Location.Y / 84).ToString();
                            break;
                        }
                    }
                DatePiesa.MutarilePiesei1 = a;
                for (j = 1; j < BoardSizeC * BoardSizeL; j++)
                    if (pieceIdBoard[j].Enumarare == 1)
                    {
                        b[0] = ((char)('a' + (pieceIdBoard[j].Location.X / 84))).ToString() + (BoardSizeL - pieceIdBoard[j].Location.Y / 84).ToString();
                        break;
                    }
                for (i = -1; i >= negativecount; i--)

                    for (j = 1; j < BoardSizeC * BoardSizeL; j++)
                    {
                        if (pieceIdBoard[j].Enumarare == i)
                        {
                            b[(0-i)] = ((char)('a' + (pieceIdBoard[j].Location.X / 84))).ToString() + (BoardSizeL - pieceIdBoard[j].Location.Y / 84).ToString();
                            break;
                        }
                    }
                DatePiesa.MutarilePiesei2 = b;
                DatePiesa.Save = true;
                DatePiesa.NumelePiesei = string.Copy("Pionul");
                RadioButton raspuns1 = RadioButtonHelper.GetCheckedRadio(groupBox1);
                RadioButton raspuns2 = RadioButtonHelper.GetCheckedRadio(groupBox2);
                RadioButton raspuns3 = RadioButtonHelper.GetCheckedRadio(groupBox3);
                if (raspuns1 == radioButton2)
                    DatePiesa.RaspunsIntrb1 = false;
                else
                    DatePiesa.RaspunsIntrb1 = true;
                if (raspuns2 == radioButton4)
                    DatePiesa.RaspunsIntrb2 = false;
                else
                    DatePiesa.RaspunsIntrb2 = true;
                if (raspuns3 == radioButton5)
                    DatePiesa.RaspunsIntrb3 = false;
                else
                    DatePiesa.RaspunsIntrb3 = true;

                if (DatePiesa.RaspunsIntrb3 == false)
                {
                    a = new string[countt+1];
                    for (j = 1; j < BoardSizeC * BoardSizeL; j++)
                        if (pieceIdBoard[j].Enumarare == 1)
                        {
                            a[0] = ((char)('a' + (pieceIdBoard[j].Location.X / 84))).ToString() + (BoardSizeL - pieceIdBoard[j].Location.Y / 84).ToString();
                            break;
                        }
                    for (i = 1; i <= countt; i++)

                        for (j = 1; j < BoardSizeC * BoardSizeL; j++)
                        {
                            if (pieceIdBoard[j].Capturare == i)
                            {
                                a[i ] = ((char)('a' + (pieceIdBoard[j].Location.X / 84))).ToString() + (BoardSizeL - pieceIdBoard[j].Location.Y / 84).ToString();
                                break;
                            }
                        }
                    DatePiesa.MutarilePieseiCaptura = a;
                }
               
            }
            else
                MessageBox.Show("Trebuie să aveți măcar o mutare selectată");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Selectați poziția de start a pionului";
            for (int i = 0; i < BoardSizeC * BoardSizeL; i++)
            {
                

                pieceIdBoard[i].PieceName = "-";
                pieceIdBoard[i].PiecePosition = i;
                pieceIdBoard[i].BackColor = Color.Transparent;
                pieceIdBoard[i].PieceValue = 0;
                pieceIdBoard[i].Enumarare = 0;
                pieceIdBoard[i].Capturare = 0;
                pieceIdBoard[i].Image = null; 
            }
            FirstMouseClick = false;
            radioButton1.Checked = false;
            radioButton3.Checked = false;
            radioButton2.Checked = true;
            radioButton4.Checked = true;
            DatePiesa.Save = false;
            count = 0;
            countt = 0;
            negativecount = 0;
            Culoarea = Color.Yellow;
            pornit = 0;
            radioButton6.Checked = true;
            radioButton5.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int l;
            if (count<2)
            {
                MessageBox.Show("Trebuie să aveți măcar un traseu configurat pentru a putea să îl configurați și pe al doilea!");
            }
            else
            {
                for ( l = 0; l < BoardSizeC * BoardSizeL; l++)
                    if (pieceIdBoard[l].Enumarare == 1)
                        break;
                LastX = pieceIdBoard[l].Location.X;
                LastY = pieceIdBoard[l].Location.Y;
                Culoarea = Color.Cyan;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                MessageBox.Show("Selectați poziția de captură a piesei cu click dreapta", "Atenție");
                pornit = 1;
            }
            else
            {
                for (int i = 0; i < BoardSizeC * BoardSizeL; i++)
                {
                    if (pieceIdBoard[i].BackColor == Color.FromArgb(255, 213, 0))
                        pieceIdBoard[i].BackColor = Color.Transparent;
                    pieceIdBoard[i].BorderStyle = System.Windows.Forms.BorderStyle.None;
                    
                }
                pornit = 0;
            }
        }


    }
}
