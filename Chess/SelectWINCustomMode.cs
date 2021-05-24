using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class SelectWINCustomMode : Form
    {
        private string[] piese ;
        static string piesa;
        public PictureBox[] pieceBorder;
        public Piece[] pieceIdBoard;

        GroupBox groupBox1 = new GroupBox();
        GroupBox groupBox2 = new GroupBox();
        GroupBox groupBox3 = new GroupBox();
        Panel panel2 = new Panel();
        Panel panel3 = new Panel();
        
        public SelectWINCustomMode()
        {
            InitializeComponent();
            panel2.Controls.Add(panel3);
            panel2.AutoScrollMinSize = new Size(0, 1200);
            
            DateleNouluiJoc[] a = SelectPropsCustomMode.Info;
            piese = new string[a.Length];
            for(int i=0;i<a.Length;i++)
            {
                piese.Append(a[i].NumelePiesei);
                if (String.Equals(a[i].NumelePiesei, "Pionul"))
                    button1.Visible = true;
                if (String.Equals(a[i].NumelePiesei, "Tura"))
                    button2.Visible = true;
                if (String.Equals(a[i].NumelePiesei, "Calul"))
                    button3.Visible = true;
                if (String.Equals(a[i].NumelePiesei, "Nebunul"))
                    button4.Visible = true;
                if (String.Equals(a[i].NumelePiesei, "Regina"))
                    button5.Visible = true;
                if (String.Equals(a[i].NumelePiesei, "Regele"))
                    button6.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            executa_Chestionar(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            executa_Chestionar(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            executa_Chestionar(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            executa_Chestionar(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            executa_Chestionar(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            executa_Chestionar(5);
        }

        private void executa_Chestionar(int i)
        {
            label1.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            if (i == 0)
                piesa = String.Copy("Pionul");
            if (i==1)
                piesa = String.Copy("Tura");
            if (i==2)
                piesa = String.Copy("Calul");
            if (i==3)
                piesa = String.Copy("Nebunul");
            if (i==4)
                piesa = String.Copy("Regina");
            if (i==5)
                piesa = String.Copy("Regele");


            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox1.Location = new System.Drawing.Point(650, 65);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(650, 100);
            groupBox1.TabStop = false;
            groupBox1.Text = piesa + " atacată determină sfârșitul partidei?";

            this.Controls.Add(groupBox1);



            groupBox2.Controls.Add(radioButton3);
            groupBox2.Controls.Add(radioButton4);
            groupBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox2.Location = new System.Drawing.Point(650, 195);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(650, 100);
            groupBox2.TabStop = false;
            groupBox2.Text = "Poziția " + piesa + " determină sfârșitul partidei?";

            this.Controls.Add(groupBox2);
            radioButton2_Click(this, new EventArgs());
        }


        private void radioButton1_Click(object sender, EventArgs e)
        {



            if (this.Controls.Contains(panel2))
            {
                this.Controls.Remove(panel2);
            }
            groupBox3.Controls.Add(radioButton5);
            groupBox3.Controls.Add(radioButton6);
            groupBox3.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox3.Location = new System.Drawing.Point(700, 195);
            groupBox3.Name = "groupBox2";
            groupBox3.Size = new System.Drawing.Size(650, 100);
            groupBox3.TabStop = false;
            groupBox3.Text = "Piesa atacată și adversarul mută?";

            this.Controls.Add(groupBox3);
            groupBox2.Location = new Point(650, 325);
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton4.Checked = false;
            radioButton3.Checked = true;
            
            
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            groupBox2.Location = new Point(650, 195);
            this.Controls.Remove(groupBox3);
            radioButton4_Click(sender, e);
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            radioButton4.Checked = true;
            radioButton3.Checked = false;
            
        }
        private void radioButton4_Click(object sender, EventArgs e)
        {
            groupBox2.Location = new Point(650, 195);
            this.Controls.Remove(groupBox3);
            radioButton1.Checked = false;
            radioButton2.Checked = true;
            radioButton4.Checked = true;
            radioButton3.Checked = false;
            this.Controls.Add(panel2);
            int BoardSizeL = CalculeazaMarime(Global.GlobalMarimeLinii);
            int BoardSizeC = CalculeazaMarime(Global.GlobalMarimeColoane);
            panel2.Location = new Point(607,300);
            panel3.Location = new System.Drawing.Point(43, 56);
            panel3.Size = new Size(BoardSizeC * 84, BoardSizeL * 84);
            panel2.Size = new Size(BoardSizeC * 84 + 117, BoardSizeL * 84 + 117);
            CreareMarcajeLaterale(BoardSizeL, BoardSizeC);
            panel3.BackgroundImage = Image.FromFile(@"C:\Users\rebeg\source\repos\Chess\Resources\board 10x10.png");
            panel3.BackgroundImageLayout = ImageLayout.None;

            pieceBorder = new PictureBox[BoardSizeC * BoardSizeL];
            pieceIdBoard = new Piece[BoardSizeC * BoardSizeL];
            for (int index = 0; index < BoardSizeC * BoardSizeL; index++)
            {
                
                pieceBorder[index] = new PictureBox
                {
                    Location = new Point((index % BoardSizeC) * 84, BoardSizeL * 84 - (84 * (index / BoardSizeC + 1))),
                    Size = new Size(84, 84),
                    BackColor = Color.Transparent
                };
                this.panel3.Controls.Add(pieceBorder[index]);
                pieceIdBoard[index] = new Piece
                {
                    Location = new Point((index % BoardSizeC) * 84, BoardSizeL * 84 - (84 * (index / BoardSizeC + 1))),
                    Size = new Size(84, 84),
                };
                pieceIdBoard[index].Click += new EventHandler(MouseClick);
                this.panel3.Controls.Add(pieceIdBoard[index]);
                pieceIdBoard[index].BackgroundImageLayout = ImageLayout.Center;
                pieceIdBoard[index].BringToFront();
                pieceIdBoard[index].BackColor = Color.Transparent;

                pieceIdBoard[index].PieceName = "-";
                pieceIdBoard[index].PiecePosition = index;
                pieceIdBoard[index].BackColor = Color.Transparent;
                pieceIdBoard[index].PieceValue = 0;
                pieceIdBoard[index].Enumarare = 0;

               
            }

        }
        private void radioButton3_Click(object sender, EventArgs e)
        {
            radioButton1_Click(sender, e);
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton4.Checked = false;
            radioButton3.Checked = true;
            this.Controls.Remove(panel2);
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
        private void CreareMarcajeLaterale(int boardSizeL, int boardSizeC)
        {
            for (int i = 1; i <= boardSizeL; i++)
            {
                Label l = new Label();
                panel2.Controls.Add(l);
                l.AutoSize = true;
                l.Size = new Size(13, 13);
                l.Name = "panell" + (boardSizeL - i + 1);
                l.Text = (boardSizeL - i + 1).ToString();
                l.Location = new Point(25, 98 + 84 * (i - 1));
            }
            for (int i = 1; i <= boardSizeC; i++)
            {
                Label l1 = new Label();
                panel2.Controls.Add(l1);
                l1.AutoSize = true;
                l1.Size = new Size(13, 13);
                l1.Name = "panel1" + (boardSizeC - i + 1);
                l1.Text = Char.ToString((char)(96 + i));
                l1.Location = new Point(85 + 84 * (i - 1), boardSizeL * 84 + 74);
            }
        }
        private void MouseClick(object sender, EventArgs e)
        {
            Piece piece = sender as Piece;
            pieceBorder[piece.PiecePosition].BackColor = Color.Yellow;
            pieceIdBoard[piece.PiecePosition].BackColor = Color.Yellow;
        }
    }
}
