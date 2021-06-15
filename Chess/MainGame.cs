using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class MainGame : Form
    {
        static int numarPiesa=-1;
        static int cazuri = 0;
        private Piece[] pieceIdBoard;
        private PictureBox[] pieceBorder;
        private int value;
        private int ok = 0,i;
        DateCastigPartida DatePartidaCastig;
        DateleNouluiJoc[] DatelePieselor;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGame));
        public MainGame()
        {
            InitializeComponent();
            
        }
        public void SetValue (int value)
        {
            this.value = value; 
        }
        public int GetValue()
        {
            return this.value;
        }

        private void MainGame_Load(object sender, EventArgs e)
        {
            int i;
            if(value == 1)
            {
                DatePartidaCastig = Form1.DatePartida();
                DatelePieselor = Form1.DateJoc();
            }
            else
            {
                DatePartidaCastig = SelectWINCustomMode.Info;
                DatelePieselor = SelectPropsCustomMode.Info;
            }

            pieceIdBoard = new Piece[DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri];
            pieceBorder = new PictureBox[DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri];
            panel1.Size = new Size(DatePartidaCastig.NumarColoane * 84, DatePartidaCastig.NumarRanduri * 84);
            button1.Location = new Point(button1.Location.X,panel1.Location.Y+panel1.Size.Height+40);
            panel1.BackgroundImage = Image.FromFile(@"C:\Users\rebeg\source\repos\Chess\Resources\board 10x10.png");
            panel1.BackgroundImageLayout = ImageLayout.None;

            Point Locatie = new Point(panel1.Size.Width+panel1.Location.X + 40, 51);
            i = 0;
            while(DatelePieselor[i].NumelePiesei != null)
            {
                CreateButton(Locatie,DatelePieselor[i].NumelePiesei,i);
                Locatie = new Point(Locatie.X, Locatie.Y+70);
                i++;
            }
            for (i = 0; i < DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri; i++)
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

        private void CreateButton(Point Locatie,String NumePiesa,int i)
        {

            System.Windows.Forms.Button ButonDynamic;
            ButonDynamic = new Button();
            ButonDynamic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(30)))));
            ButonDynamic.FlatAppearance.BorderSize = 0;
            ButonDynamic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            ButonDynamic.Font = new System.Drawing.Font("MS PGothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ButonDynamic.ForeColor = System.Drawing.Color.White;
            ButonDynamic.Image = ((System.Drawing.Image)(resources.GetObject(NumePiesaafisaj(NumePiesa,DatePartidaCastig.Culoare))));
            ButonDynamic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ButonDynamic.Location = Locatie;
            ButonDynamic.Name = "button1";
            ButonDynamic.Size = new System.Drawing.Size(163, 52);
            ButonDynamic.TabIndex = 2;
            ButonDynamic.Text =String.Copy(NumePiesa);
            ButonDynamic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            ButonDynamic.UseVisualStyleBackColor = false;
            ButonDynamic.Click += (s, e) => { numarPiesa=i; };
            //ButonDynamic.Click += new EventHandler(ButonDynamic_Click);
            this.Controls.Add(ButonDynamic);
            //ButonDynamic.Click += new System.EventHandler(this.button1_Click);
        }
        private String NumePiesaafisaj (String nume,CuloarePiesa culoare)
        {
            
            if (String.Compare(nume, "Pionul") == 0)
                if (culoare == CuloarePiesa.Alb)
                    return "WP";
                else
                    return "BP";
            if (String.Compare(nume, "Calul") == 0)
                if (culoare == CuloarePiesa.Alb)
                    return "WN";
                else
                    return "BN";
            if (String.Compare(nume, "Nebunul") == 0)
                if (culoare == CuloarePiesa.Alb)
                    return "WB";
                else
                    return "BB";
            if (String.Compare(nume, "Regele") == 0)
                if (culoare == CuloarePiesa.Alb)
                    return "WK";
                else
                    return "BK";
            if (String.Compare(nume, "Regina") == 0)
                if (culoare == CuloarePiesa.Alb)
                    return "WQ";
                else
                    return "BQ";
            if (String.Compare(nume, "Tura") == 0)
                if (culoare == CuloarePiesa.Alb)
                    return "WR";
                else
                    return "BR";
            return "WP";
            
        }

        private void CreatePiece(int index, MainGame form)
        {
            pieceBorder[index] = new PictureBox
            {
                Location = new Point((index % DatePartidaCastig.NumarColoane) * 84, DatePartidaCastig.NumarRanduri * 84 - (84 * (index / DatePartidaCastig.NumarColoane + 1))),
                Size = new Size(84, 84),
                BackColor = Color.Transparent
            };
            form.panel1.Controls.Add(pieceBorder[index]);
            pieceIdBoard[index] = new Piece
            {
                Location = new Point((index % DatePartidaCastig.NumarColoane) * 84, DatePartidaCastig.NumarRanduri * 84 - (84 * (index / DatePartidaCastig.NumarColoane + 1))),
                Size = new Size(84, 84),
            };


            pieceIdBoard[index].Click += new EventHandler(Clicked);
            form.panel1.Controls.Add(pieceIdBoard[index]);
            pieceIdBoard[index].BackgroundImageLayout = ImageLayout.Center;
            pieceIdBoard[index].BringToFront();
            pieceIdBoard[index].BackColor = Color.Transparent;
        }

        private void Clicked(object sender, EventArgs e)
        {
            Piece piece = sender as Piece;
            if (cazuri == 0)
            {
                if (numarPiesa == -1)
                {
                    MessageBox.Show("Trebuie mai întâi să selectați o piesă din partea dreaptă");
                }
                else
                {
                    
                    if (piece.PiecePosition > 2 * DatePartidaCastig.NumarColoane)
                        MessageBox.Show("Puteți plasa piese doar pe primele 2 rânduri ale tablei de joc");
                    else
                    {
                        Image imagn = ((System.Drawing.Image)(resources.GetObject(NumePiesaafisaj(DatelePieselor[numarPiesa].NumelePiesei, DatePartidaCastig.Culoare)))); ;
                        pieceIdBoard[piece.PiecePosition].Image = imagn;
                        pieceIdBoard[piece.PiecePosition].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        pieceIdBoard[piece.PiecePosition].PieceName = NumePiesaafisaj(DatelePieselor[numarPiesa].NumelePiesei, DatePartidaCastig.Culoare);
                        pieceIdBoard[piece.PiecePosition].PieceValue = 10;
                    }
                }
            }
            if (cazuri == 1)
            {
                for (i = 0; i < DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri; i++)
                    if (String.Compare(NumePiesaImagine(pieceIdBoard[i].PieceName), DatePartidaCastig.NumePiesa) == 0)
                        break;
                if (piece.PiecePosition == i)
                    MessageBox.Show("Nu puteti selecta aceeași piesă pentru rocadă");
                else
                    if (piece.PiecePosition / DatePartidaCastig.NumarColoane != i / DatePartidaCastig.NumarColoane)
                    MessageBox.Show("Ambele piese trebuie să fie pe același nivel");
                    else
                    {
                        pieceIdBoard[piece.PiecePosition].BackColor = Color.Yellow;
                        pieceIdBoard[i].BackColor = Color.Yellow;
                        this.Refresh();
                        Thread.Sleep(2000);
                        pieceIdBoard[piece.PiecePosition].BackColor = Color.Transparent;
                        pieceIdBoard[i].BackColor = Color.Transparent;
                    }
            }
            if(cazuri == 2)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            System.Windows.Forms.Button Buton_Rocada;
            Buton_Rocada = new Button();
            if (ok == 0)
            {
                for (i = 0; i < DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri; i++)
                    if (String.Compare(NumePiesaImagine(pieceIdBoard[i].PieceName), DatePartidaCastig.NumePiesa) == 0)
                        ok = 1;
            }
            if (ok == 0)
                MessageBox.Show("Trebuie ca înainte de configurare să aveți măcar o piesă care determină finalul partidei: " + DatePartidaCastig.NumePiesa);
            else
            {
                if (ok == 1)
                {
                    cazuri = 1;
                    label1.Text = "Selectați rocada pe tabla de joc";
                    
                    Buton_Rocada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
                    Buton_Rocada.FlatAppearance.BorderSize = 0;
                    Buton_Rocada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    Buton_Rocada.ForeColor = System.Drawing.Color.White;
                    Buton_Rocada.Location = new System.Drawing.Point(button1.Location.X + 70 + button1.Size.Width, button1.Location.Y);
                    Buton_Rocada.Name = "Buton_Rocada";
                    Buton_Rocada.Size = new System.Drawing.Size(124, 33);
                    Buton_Rocada.TabIndex = 1;
                    Buton_Rocada.Text = "Rocadă";
                    Buton_Rocada.UseVisualStyleBackColor = false;
                    Buton_Rocada.Click += new System.EventHandler(this.Buton_Rocada_Click);
                    this.Controls.Add(Buton_Rocada);
                    ok = 2;
                }
                else
                {
                    if (ok == 2)
                    {
                        foreach (Control item in this.Controls)
                        {
                            if (item.Name == "Buton_Rocada")
                            {
                                this.Controls.Remove(item);
                                break; //important step
                            }
                        }
                        label1.Text = "Am ajuns";

                    }
                }
            }
        }

        private void Buton_Rocada_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selectați piesa care doriți să realizeze rocada cu: " + DatePartidaCastig.NumePiesa);
            cazuri = 1;
        }

        private String NumePiesaImagine(String nume)
        {

            if (String.Compare(nume, "WP") == 0 || String.Compare(nume, "BP") == 0)
                return "Pionul";
            if (String.Compare(nume, "WN") == 0 || String.Compare(nume, "BN") == 0)
                return "Calul";
            if (String.Compare(nume, "WB") == 0 || String.Compare(nume, "BB") == 0)
                return "Nebunul";
            if (String.Compare(nume, "WK") == 0 || String.Compare(nume, "BK") == 0)
                return "Regele";
            if (String.Compare(nume, "WQ") == 0 || String.Compare(nume, "BQ") == 0)
                return "Regina";
            if (String.Compare(nume, "WR") == 0 || String.Compare(nume, "BR") == 0)
                return "Tura";
            return "Pionul";

        }
    }
}
