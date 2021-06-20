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
        static int cazuri = 0,suma;
        private Piece[] pieceIdBoard;
        private PictureBox[] pieceBorder;
        private int value;
        private int ok = 0,i,verific=0;
        DateCastigPartida DatePartidaCastig;
        DateleNouluiJoc[] DatelePieselor;
        Image imagn;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGame));
        public string[] chessBoard;
        private bool PrimaApasareAPiesei;
        private int PozitiaDeStartAPiesei;
        List<Mutare> pozitii;
        Mutare LastMove;
        public bool CheckMate { get; set; }
        public MainGame()
        {
            InitializeComponent();
            PrimaApasareAPiesei = false;
            pozitii = new List<Mutare>();

        }
        public MainGame(MainGame m)
        {
            CheckMate = m.CheckMate;
            PrimaApasareAPiesei = m.PrimaApasareAPiesei;
            
            pieceIdBoard = new Piece[DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri];
            pieceBorder = new PictureBox[DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri];
            LastMove = new Mutare();
            

            for (int i = 0; i < DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri; i++)
            {
                pieceIdBoard[i] = new Piece
                {
                    PieceName = m.pieceIdBoard[i].PieceName,
                    PiecePosition = m.pieceIdBoard[i].PiecePosition,
                    IsFirstMove = m.pieceIdBoard[i].IsFirstMove,
                    PieceValue = m.pieceIdBoard[i].PieceValue
                };
            }
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
            CreareMarcajeLaterale(DatePartidaCastig.NumarRanduri, DatePartidaCastig.NumarColoane);

            Point Locatie = new Point(panel1.Size.Width+panel1.Location.X + 40, 51);
            i = 0;
            while (i < DatelePieselor.Length && DatelePieselor[i].NumelePiesei !=null)
                try
                {

                    CreateButton(Locatie, DatelePieselor[i].NumelePiesei, i);
                    Locatie = new Point(Locatie.X, Locatie.Y + 70);
                    i++;
                }
                catch (IndexOutOfRangeException ex)
                {
                    break;
                };
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
            ButonDynamic.Name = "button11";
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
                        imagn = ((System.Drawing.Image)(resources.GetObject(NumePiesaafisaj(DatelePieselor[numarPiesa].NumelePiesei, DatePartidaCastig.Culoare)))); ;
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
                if(!PrimaApasareAPiesei)
                {
                    pieceIdBoard[piece.PiecePosition].BackColor = Color.Yellow;
                    PrimaApasareAPiesei = true;
                    PozitiaDeStartAPiesei = piece.PiecePosition;
                    //pozitii = GetToateMutarilePosibilePlayer();
                    
                    pozitii = GetPozitiiDeplasarePiesa("WP", this);
                    Console.WriteLine(pozitii.Count);
                    foreach (Mutare a in pozitii)
                    {
                        Console.WriteLine(a.From);
                        Console.WriteLine(a.To);
                    }
                    int curent = piece.PiecePosition;
                }
                else
                {

                }
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
                        label1.Text = "Partidă în așteptare";
                        int a;
                        do
                        {
                            a = 2;
                            foreach (Control item in this.Controls)

                                if (item.Name == "button11")
                                {
                                    this.Controls.Remove(item);
                                    a = 1;
                                    break;
                                }

                        } while (a == 1);
                        button1.Text = "Începere partidă";
                        cazuri = 10;
                        int j = 0;
                        for (i=0;i< DatePartidaCastig.NumarColoane * 2;i++)
                        {
                            if (i >= 7 && j==0)
                                ++j;
                            if (String.Compare(pieceIdBoard[i].PieceName,"-")!=0)
                            {
                                if (DatePartidaCastig.Culoare != CuloarePiesa.Alb)
                                {
                                    imagn = ((System.Drawing.Image)(resources.GetObject(NumePiesaafisaj(NumePiesaImagine(pieceIdBoard[i].PieceName), CuloarePiesa.Alb))));
                                    pieceIdBoard[(DatePartidaCastig.NumarColoane * (DatePartidaCastig.NumarRanduri - (j + 1))) + i % 7].PieceName = NumePiesaafisaj(NumePiesaImagine(pieceIdBoard[i].PieceName), CuloarePiesa.Alb);
                                }
                                else
                                {
                                    imagn = ((System.Drawing.Image)(resources.GetObject(NumePiesaafisaj(NumePiesaImagine(pieceIdBoard[i].PieceName), CuloarePiesa.Negru))));
                                    pieceIdBoard[(DatePartidaCastig.NumarColoane * (DatePartidaCastig.NumarRanduri - (j + 1))) + i % 7].PieceName = NumePiesaafisaj(NumePiesaImagine(pieceIdBoard[i].PieceName),CuloarePiesa.Negru);
                                }
                                pieceIdBoard[(DatePartidaCastig.NumarColoane * (DatePartidaCastig.NumarRanduri - (j + 1))) + i % 7].Image = imagn;
                                pieceIdBoard[(DatePartidaCastig.NumarColoane * (DatePartidaCastig.NumarRanduri - (j + 1))) + i % 7].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                                pieceIdBoard[(DatePartidaCastig.NumarColoane * (DatePartidaCastig.NumarRanduri - (j + 1))) + i % 7].PieceValue = 10;
                            }
                        }
                        ok = 3;
                    }
                    else
                        if (ok ==3)
                    {
                        cazuri = 2;
                        button1.Hide();
                        InitiateChess();
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
        private void CreareMarcajeLaterale(int boardSizeL, int boardSizeC)
        {
            for (int i = 1; i <= boardSizeL; i++)
            {
                Label l = new Label();
                this.Controls.Add(l);
                l.AutoSize = true;
                l.Size = new Size(13, 13);
                l.Name = "panell" + (boardSizeL - i + 1);
                l.Text = (boardSizeL - i + 1).ToString();
                l.Location = new Point(25, 98 + 84 * (i - 1));
            }
            for (int i = 1; i <= boardSizeC; i++)
            {
                Label l1 = new Label();
                this.Controls.Add(l1);
                l1.AutoSize = true;
                l1.Size = new Size(13, 13);
                l1.Name = "panel1" + (boardSizeC - i + 1);
                l1.Text = Char.ToString((char)(96 + i));
                l1.Location = new Point(85 + 84 * (i - 1), boardSizeL * 84 + 74);
            }
        }
        private void InitiateChess()
        {
            chessBoard = new string[DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri];
            for (i=0;i< DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri;i++)
            {
                chessBoard[i]=String.Copy(pieceIdBoard[i].PieceName);
            }
            for (i = 0; i < DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri; i++)
            {
                switch(chessBoard[i])
                {
                    case "WP":
                        SetareValoarePiesa(CuloarePiesa.Alb, 10, i);
                        break;
                    case "WN":
                        SetareValoarePiesa(CuloarePiesa.Alb, 30, i);
                        break;
                    case "WB":
                        SetareValoarePiesa(CuloarePiesa.Alb, 30, i);
                        break;
                    case "WR":
                        SetareValoarePiesa(CuloarePiesa.Alb, 50, i);
                        break;
                    case "WK":
                        SetareValoarePiesa(CuloarePiesa.Alb, 900, i);
                        break;
                    case "WQ":
                        SetareValoarePiesa(CuloarePiesa.Alb, 90, i);
                        break;
                    case "BP":
                        SetareValoarePiesa(CuloarePiesa.Negru, 10, i);
                        break;
                    case "BN":
                        SetareValoarePiesa(CuloarePiesa.Negru, 30, i);
                        break;
                    case "BB":
                        SetareValoarePiesa(CuloarePiesa.Negru, 30, i);
                        break;
                    case "BR":
                        SetareValoarePiesa(CuloarePiesa.Negru, 50, i);
                        break;
                    case "BK":
                        SetareValoarePiesa(CuloarePiesa.Negru, 900, i);
                        break;
                    case "BQ":
                        SetareValoarePiesa(CuloarePiesa.Negru, 90, i);
                        break;
                    default:
                        pieceIdBoard[i].PiecePosition = i;
                        pieceIdBoard[i].BackColor = Color.Transparent;
                        pieceIdBoard[i].PieceValue = 0;
                        break;
                }
            }
        }

        private void SetareValoarePiesa(CuloarePiesa col,int valoare,int pozitie)
        {
            if (DatePartidaCastig.Culoare == col)
                pieceIdBoard[pozitie].PieceValue = valoare;
            else
                pieceIdBoard[pozitie].PieceValue = 0-valoare;
            pieceIdBoard[pozitie].PieceValue = pozitie;
        }
        /*private List<Mutare> GetToateMutarilePosibilePlayer()
        {
            List<Mutare> pozitii = new List<Mutare>();
            List<Mutare> pozitie = new List<Mutare>();
            if (DatePartidaCastig.Culoare == CuloarePiesa.Alb)
                for (i=0;i<=DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri;i++)
                {
                    switch(pieceIdBoard[i])
                    {
                        case "WP":
                            if ((pozitie = GetMutaripozitie())).Count!=0)
                                pozitii.AddRange(po)
                    }
                }
            return pozitii;
           
        }*/
        private List<Mutare> GetPozitiiDeplasarePiesa(string pieceName, MainGame maingame)
        {
            List<int> mutari = new List<int>();
            List<Mutare> intoarcere = new List<Mutare>();
            int k,curent;
            string Name = NumePiesaImagine(pieceName);
            for (k=0;k<DatelePieselor.Length;k++)
            {
                if (String.Compare(Name, DatelePieselor[k].NumelePiesei) == 0)
                    break;
            }
            mutari = GetMutari(DatelePieselor[k].MutarilePiesei1);
            int j,oj;

            for (oj=0;oj<DatelePieselor.Length;oj++)
            {
                if (String.Compare(DatelePieselor[oj].NumelePiesei, NumePiesaImagine(pieceName)) == 0)
                    break;
            }
            for (i = 0;i< DatePartidaCastig.NumarColoane*DatePartidaCastig.NumarRanduri;i++)
                if (String.Compare(maingame.pieceIdBoard[i].PieceName,pieceName)==0)
                {
                    if (DatelePieselor[oj].RaspunsIntrb3 == true)
                    {
                        if (DatelePieselor[oj].RaspunsIntrb2 == true)
                        {
                            if (DatelePieselor[oj].RaspunsIntrb1 == false)
                            {
                                j = 1;
                                curent = maingame.pieceIdBoard[i].PiecePosition;
                                foreach (int valoare in mutari)
                                {
                                    if (j >= DatelePieselor[oj].MutarilePiesei1.Length)

                                    {
                                        j = 1;
                                        curent = maingame.pieceIdBoard[i].PiecePosition;
                                        
                                    }
                                    
                                    if (j < DatelePieselor[oj].MutarilePiesei1.Length)
                                    {

                                        if (CheckCan(maingame, curent, valoare))
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));
                                            else
                                            {
                                                if (VerificareCuloare(maingame.pieceIdBoard[curent + valoare].PieceName) != DatePartidaCastig.Culoare)
                                                    intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));

                                            }

                                            curent = curent + valoare;
                                        }

                                        j++;

                                    }
                                    
                                }
                                
                            }
                            else
                            {
                                j = 1;
                                curent = maingame.pieceIdBoard[i].PiecePosition;
                                verific = 0;
                                foreach (int valoare in mutari)
                                {
                                    if (j >= DatelePieselor[oj].MutarilePiesei1.Length)

                                    {
                                        j = 1;
                                        curent = maingame.pieceIdBoard[i].PiecePosition;
                                        verific = 0;

                                    }

                                    if (j < DatelePieselor[oj].MutarilePiesei1.Length)
                                    {

                                        if (CheckCan(maingame, curent, valoare) && verific == 0)
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));
                                            else
                                            {
                                                if (VerificareCuloare(maingame.pieceIdBoard[curent + valoare].PieceName) != DatePartidaCastig.Culoare)
                                                    intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));

                                            }
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) != 0)
                                                verific = 1;

                                            curent = curent + valoare;
                                        }

                                        j++;

                                    }

                                }
                            }
                        }
                        else
                        {
                            if (DatelePieselor[oj].RaspunsIntrb1 == false)
                            {
                                j = 1;
                                curent = maingame.pieceIdBoard[i].PiecePosition;
                                suma=0;
                                foreach (int valoare in mutari)
                                {
                                    if (j <= DatelePieselor[oj].MutarilePiesei1.Length-1)

                                    {
                                        suma = suma + valoare;

                                    }

                                    if (j == DatelePieselor[oj].MutarilePiesei1.Length-1)
                                    {

                                        if (CheckCan(maingame, curent, suma))
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));
                                            else
                                            {
                                                if (VerificareCuloare(maingame.pieceIdBoard[curent + valoare].PieceName) != DatePartidaCastig.Culoare)
                                                    intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));

                                            }

                                            
                                        }

                                        j = 1;
                                        suma = 0;
                                        

                                    }

                                }
                            }
                            else
                            {
                                j = 1;
                                curent = maingame.pieceIdBoard[i].PiecePosition;
                                suma = 0;
                                verific = 0;
                                foreach (int valoare in mutari)
                                {
                                    if (j <= DatelePieselor[oj].MutarilePiesei1.Length - 1)

                                    {
                                        suma = suma + valoare;
                                        if (String.Compare("-", maingame.pieceIdBoard[curent + suma].PieceName) != 0)
                                            verific = 1;
                                    }

                                    if (j == DatelePieselor[oj].MutarilePiesei1.Length - 1)
                                    {

                                        if (CheckCan(maingame, curent, suma) && verific ==0)
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));
                                            else
                                            {
                                                if (VerificareCuloare(maingame.pieceIdBoard[curent + valoare].PieceName) != DatePartidaCastig.Culoare)
                                                    intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));

                                            }


                                        }

                                        j = 1;
                                        suma = 0;
                                        verific = 0;


                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        if (DatelePieselor[oj].RaspunsIntrb2 == true)
                        {
                            if (DatelePieselor[oj].RaspunsIntrb3 == true)
                            {

                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (DatelePieselor[oj].RaspunsIntrb3 == true)
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                }

            return intoarcere;
        }

        private bool CheckCan(MainGame maingame, int curent, int valoare)
        {
            switch(valoare)
            {
                case 1:
                    if ((curent + valoare) / DatePartidaCastig.NumarColoane != curent / DatePartidaCastig.NumarColoane)
                        return false;
                    else
                        return true;
                    break;
                case -1:
                    if ((curent + valoare) / DatePartidaCastig.NumarColoane != curent / DatePartidaCastig.NumarColoane || curent+valoare<0 )
                        return false;
                    else
                        return true;
                    break;
                case 8:
                    if ((curent + valoare) / DatePartidaCastig.NumarColoane - curent / DatePartidaCastig.NumarColoane > 1)
                        return false;
                    else
                        return true;
                    break;
                case -8:
                    if (curent / DatePartidaCastig.NumarColoane - (curent + valoare) / DatePartidaCastig.NumarColoane != 1 || curent + valoare < 0)
                        return false;
                    else
                        return true;
                    break;
                case 6:
                    if ((curent + valoare) / DatePartidaCastig.NumarColoane == curent / DatePartidaCastig.NumarColoane)
                        return false;
                    else
                        return true;
                    break;
                case -6:
                    if ((curent + valoare) / DatePartidaCastig.NumarColoane == curent / DatePartidaCastig.NumarColoane || curent + valoare < 0 )
                        return false;
                    else
                        return true;
                    break;
                default:
                    return false;
            }
        }

        private List<int> GetMutari(string[] mutarilePiesei)
        {
            List<int> stare = new List<int>();
            List<int> final = new List<int>();
            int numar;
            for (i=1;i<mutarilePiesei.Length;i++)
            {
                numar = 0;
                numar = numar + ((mutarilePiesei[i][1] - mutarilePiesei[i - 1][1]) * DatePartidaCastig.NumarColoane) + (mutarilePiesei[i][0]- mutarilePiesei[i-1][0]);
                if (numar == DatePartidaCastig.NumarColoane+1)
                    stare.Add(numar);
                if (numar == DatePartidaCastig.NumarColoane-1)
                    stare.Add(numar);
                if (numar == 1)
                    stare.Add(numar);
                if (numar == DatePartidaCastig.NumarColoane)
                    stare.Add(numar);
            }
            if (stare.Count > 0)
                final.AddRange(stare);
            stare = new List<int>();
            for (i = 1; i < mutarilePiesei.Length; i++)
            {
                numar = 0;
                numar = numar + ((mutarilePiesei[i][1] - mutarilePiesei[i - 1][1]) * DatePartidaCastig.NumarColoane) + (mutarilePiesei[i][0] - mutarilePiesei[i - 1][0]);
                if(numar == DatePartidaCastig.NumarColoane+1)
                    stare.Add(0-numar+2);
                if(numar == DatePartidaCastig.NumarColoane-1)
                    stare.Add(0-numar-2);
                if (numar == 1)
                    stare.Add(numar);
                if (numar == DatePartidaCastig.NumarColoane)
                    stare.Add(0-numar);
            }
            if (stare.Count > 0)
                final.AddRange(stare);
            stare = new List<int>();
            for (i = 1; i < mutarilePiesei.Length; i++)
            {
                numar = 0;
                numar = numar + ((mutarilePiesei[i][1] - mutarilePiesei[i - 1][1]) * DatePartidaCastig.NumarColoane) + (mutarilePiesei[i][0] - mutarilePiesei[i - 1][0]);
                if (numar == DatePartidaCastig.NumarColoane+1)
                    stare.Add(numar - 2);
                if (numar == DatePartidaCastig.NumarColoane-1)
                    stare.Add(numar + 2);
                if (numar == 1)
                    stare.Add(0 - numar);
                if (numar == DatePartidaCastig.NumarColoane)
                    stare.Add(numar);
            }
            if (stare.Count > 0)
                final.AddRange(stare);
            stare = new List<int>();
            for (i = 1; i < mutarilePiesei.Length; i++)
            {
                numar = 0;
                numar = numar + ((mutarilePiesei[i][1] - mutarilePiesei[i - 1][1]) * DatePartidaCastig.NumarColoane) + (mutarilePiesei[i][0] - mutarilePiesei[i - 1][0]);
                if (numar == DatePartidaCastig.NumarColoane+1)
                    stare.Add(0-numar );
                if (numar == DatePartidaCastig.NumarColoane-1)
                    stare.Add(0-numar);
                if (numar == 1)
                    stare.Add(0 - numar);
                if (numar == DatePartidaCastig.NumarColoane)
                    stare.Add(0 - numar);
            }
            if (stare.Count > 0)
                final.AddRange(stare);
            return final;
        }
        private List<Mutare> GetDeplasarePiesa(string name,MainGame m)
        {
            List<Mutare> rtr = new List<Mutare>();
            string nume = NumePiesaImagine(name);

            return rtr;
        }

        private CuloarePiesa VerificareCuloare (String name)
        {
            switch(name)
            {
                case "WP":
                    return CuloarePiesa.Alb;
                case "WB":
                    return CuloarePiesa.Alb;
                case "WK":
                    return CuloarePiesa.Alb;
                case "WQ":
                    return CuloarePiesa.Alb;
                case "WN":
                    return CuloarePiesa.Alb;
                case "WR":
                    return CuloarePiesa.Alb;
                case "BP":
                    return CuloarePiesa.Negru;
                case "BB":
                    return CuloarePiesa.Negru;
                case "BK":
                    return CuloarePiesa.Negru;
                case "BQ":
                    return CuloarePiesa.Negru;
                case "BN":
                    return CuloarePiesa.Negru;
                case "BR":
                    return CuloarePiesa.Negru;
                default:
                    return CuloarePiesa.Alb;
            }
        }
    }
}
