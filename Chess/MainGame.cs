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
        public Piece[] pieceIdBoard;
        public PictureBox[] pieceBorder;
        private int value;
        private int ok = 0,i,verific=0;
        public DateCastigPartida DatePartidaCastig;
        DateleNouluiJoc[] DatelePieselor;
        Image imagn;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGame));
        public string[] chessBoard;
        private bool PrimaApasareAPiesei;
        private int PozitiaDeStartAPiesei;
        List<Mutare> pozitii;
        Mutare LastMove;
        public bool CheckMate { get; set; }
        public int WhiteInCheck { get; set; }
        public int BlackInCheck { get; set; }
        public MainGame()
        {
            InitializeComponent();
            PrimaApasareAPiesei = true;
            pozitii = new List<Mutare>();
            WhiteInCheck = -1;
            BlackInCheck = -1;
            LastMove = new Mutare();
        }
        public MainGame(MainGame m, DateCastigPartida DatePartidaCastig, DateleNouluiJoc[] DatelePieselor)
        {
            CheckMate = m.CheckMate;
            PrimaApasareAPiesei = m.PrimaApasareAPiesei;
            this.DatePartidaCastig = DatePartidaCastig;
            this.DatelePieselor = DatelePieselor;
            pieceIdBoard = new Piece[DatePartidaCastig.NumarColoane*DatePartidaCastig.NumarRanduri];
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
        public String NumePiesaafisaj (String nume,CuloarePiesa culoare)
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
                if(PrimaApasareAPiesei)
                {
                    if (String.Compare(pieceIdBoard[piece.PiecePosition].PieceName,"-")!=0)
                        if (VerificareCuloare(pieceIdBoard[piece.PiecePosition].PieceName) == DatePartidaCastig.Culoare)
                        {
                            pieceIdBoard[piece.PiecePosition].BackColor = Color.Yellow;
                            PrimaApasareAPiesei = false;
                            PozitiaDeStartAPiesei = piece.PiecePosition;
                            if (DatePartidaCastig.Culoare == CuloarePiesa.Alb)
                                pozitii = GetToateMutarilePosibileWhite(this);
                            else
                                pozitii = GetToateMutarilePosibileBlack(this);
                            Console.WriteLine(pozitii.Count);
                            foreach (Mutare a in pozitii)
                            {
                                Console.WriteLine(a.From);
                                Console.WriteLine(a.To);
                            }
                            foreach (Mutare stare in pozitii)
                            {
                                if (stare.From == PozitiaDeStartAPiesei)
                                    pieceIdBoard[stare.To].BackColor = Color.Yellow;
                            }
                        }
                    
                    
                }
                else
                {
                    Mutare move = new Mutare(PozitiaDeStartAPiesei, piece.PiecePosition);
                    if (!move.IsValidMove(pozitii))
                    {
                        SetareTablaIncolora();
                    }
                    else
                    {
                        MainGame test = new MainGame(this,DatePartidaCastig,DatelePieselor);
                        if (move.IsCheckMove(pozitii, PozitiaDeStartAPiesei, piece.PiecePosition, test, VerificareCuloare(pieceIdBoard[piece.PiecePosition].PieceName)))
                        {
                            SetareTablaIncolora();
                        }
                        else
                        {

                            UpdateTabla(move.To);
                            SetareTablaIncolora();
                            pieceIdBoard[move.From].BackColor = Color.Chocolate;
                            pieceIdBoard[move.To].BackColor = Color.Chocolate;
                            MainGame test2 = new MainGame(this, DatePartidaCastig, DatelePieselor);
                            SetareTablaIncolora();
                            if (move.OpponentInCheck(pozitii, PozitiaDeStartAPiesei, piece.PiecePosition, test2, VerificareCuloare(pieceIdBoard[piece.PiecePosition].PieceName)))
                            {
                                string msg = "Șah!";
                                DialogResult dResult;
                                dResult = MessageBox.Show(msg);
                            }
                            bool result = InitiateComputerMove();
                            /*while (!(result))
                            {
                                result = InitiateComputerMove();
                            }
                            */
                            if (CheckMate == true)
                            {
                                string msg = "Șah mat! Ai câștigat!";
                                DialogResult dResult;
                                dResult = MessageBox.Show(msg);
                                Application.Exit();
                            }
                        }
                    }
                    PrimaApasareAPiesei = true;
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
                            if (i >= DatePartidaCastig.NumarColoane && j==0)
                                ++j;
                            if (String.Compare(pieceIdBoard[i].PieceName,"-")!=0)
                            {
                                if (DatePartidaCastig.Culoare != CuloarePiesa.Alb)
                                {
                                    imagn = ((System.Drawing.Image)(resources.GetObject(NumePiesaafisaj(NumePiesaImagine(pieceIdBoard[i].PieceName), CuloarePiesa.Alb))));
                                    pieceIdBoard[(DatePartidaCastig.NumarColoane * (DatePartidaCastig.NumarRanduri - (j + 1))) + i % DatePartidaCastig.NumarColoane].PieceName = NumePiesaafisaj(NumePiesaImagine(pieceIdBoard[i].PieceName), CuloarePiesa.Alb);
                                }
                                else
                                {
                                    imagn = ((System.Drawing.Image)(resources.GetObject(NumePiesaafisaj(NumePiesaImagine(pieceIdBoard[i].PieceName), CuloarePiesa.Negru))));
                                    pieceIdBoard[(DatePartidaCastig.NumarColoane * (DatePartidaCastig.NumarRanduri - (j + 1))) + i % DatePartidaCastig.NumarColoane].PieceName = NumePiesaafisaj(NumePiesaImagine(pieceIdBoard[i].PieceName),CuloarePiesa.Negru);
                                }
                                pieceIdBoard[(DatePartidaCastig.NumarColoane * (DatePartidaCastig.NumarRanduri - (j + 1))) + i % DatePartidaCastig.NumarColoane].Image = imagn;
                                pieceIdBoard[(DatePartidaCastig.NumarColoane * (DatePartidaCastig.NumarRanduri - (j + 1))) + i % DatePartidaCastig.NumarColoane].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                                pieceIdBoard[(DatePartidaCastig.NumarColoane * (DatePartidaCastig.NumarRanduri - (j + 1))) + i % DatePartidaCastig.NumarColoane].PieceValue = 10;
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
                        SetareValoarePiesa(CuloarePiesa.Alb, 10, i,"WP");
                        break;
                    case "WN":
                        SetareValoarePiesa(CuloarePiesa.Alb, 30, i,"WN");
                        break;
                    case "WB":
                        SetareValoarePiesa(CuloarePiesa.Alb, 30, i,"WB");
                        break;
                    case "WR":
                        SetareValoarePiesa(CuloarePiesa.Alb, 50, i,"WR");
                        break;
                    case "WK":
                        SetareValoarePiesa(CuloarePiesa.Alb, 900, i,"WK");
                        break;
                    case "WQ":
                        SetareValoarePiesa(CuloarePiesa.Alb, 90, i,"WQ");
                        break;
                    case "BP":
                        SetareValoarePiesa(CuloarePiesa.Negru, 10, i,"BP");
                        break;
                    case "BN":
                        SetareValoarePiesa(CuloarePiesa.Negru, 30, i,"BN");
                        break;
                    case "BB":
                        SetareValoarePiesa(CuloarePiesa.Negru, 30, i,"BB");
                        break;
                    case "BR":
                        SetareValoarePiesa(CuloarePiesa.Negru, 50, i,"BR");
                        break;
                    case "BK":
                        SetareValoarePiesa(CuloarePiesa.Negru, 900, i,"BK");
                        break;
                    case "BQ":
                        SetareValoarePiesa(CuloarePiesa.Negru, 90, i,"BQ");
                        break;
                    default:
                        pieceIdBoard[i].PiecePosition = i;
                        pieceIdBoard[i].BackColor = Color.Transparent;
                        pieceIdBoard[i].PieceValue = 0;
                        break;
                }
            }
        }

        private void SetareValoarePiesa(CuloarePiesa col,int valoare,int pozitie,string nume)
        {
            if (DatePartidaCastig.Culoare == col)
                pieceIdBoard[pozitie].PieceValue = valoare;
            else
                pieceIdBoard[pozitie].PieceValue = 0-valoare;
            pieceIdBoard[pozitie].PieceValue = pozitie;
            pieceIdBoard[pozitie].Name = nume;
        }
        internal List<Mutare> GetToateMutarilePosibileWhite(MainGame maingame)
        {
            List<Mutare> pozitii = new List<Mutare>();
            List<Mutare> pozitie = new List<Mutare>();
            if ((pozitie = GetPozitiiDeplasarePiesa("WP", maingame)).Count != 0)
                pozitii.AddRange(pozitie);
            if ((pozitie = GetPozitiiDeplasarePiesa("WN", maingame)).Count != 0)
                pozitii.AddRange(pozitie);
            if ((pozitie = GetPozitiiDeplasarePiesa("WQ", maingame)).Count != 0)
                pozitii.AddRange(pozitie);
            if ((pozitie = GetPozitiiDeplasarePiesa("WR", maingame)).Count != 0)
                pozitii.AddRange(pozitie);
            if ((pozitie = GetPozitiiDeplasarePiesa("WB", maingame)).Count != 0)
                pozitii.AddRange(pozitie);
            if ((pozitie = GetPozitiiDeplasarePiesa("WK", maingame)).Count != 0)
                pozitii.AddRange(pozitie);
            return pozitii;
           
        }
        internal List<Mutare> GetToateMutarilePosibileBlack(MainGame maingame)
        {
            List<Mutare> pozitii = new List<Mutare>();
            List<Mutare> pozitie = new List<Mutare>();
            if ((pozitie = GetPozitiiDeplasarePiesa("BP", maingame)).Count != 0)
                pozitii.AddRange(pozitie);
            if ((pozitie = GetPozitiiDeplasarePiesa("BN", maingame)).Count != 0)
                pozitii.AddRange(pozitie);
            if ((pozitie = GetPozitiiDeplasarePiesa("BQ", maingame)).Count != 0)
                pozitii.AddRange(pozitie);
            if ((pozitie = GetPozitiiDeplasarePiesa("BR", maingame)).Count != 0)
                pozitii.AddRange(pozitie);
            if ((pozitie = GetPozitiiDeplasarePiesa("BB", maingame)).Count != 0)
                pozitii.AddRange(pozitie);
            if ((pozitie = GetPozitiiDeplasarePiesa("BK", maingame)).Count != 0)
                pozitii.AddRange(pozitie);
            return pozitii;

        }
        internal List<Mutare> GetPozitiiDeplasarePiesa(string pieceName, MainGame maingame)
        {
            List<int> mutari = new List<int>();
            List<int> capturaLista = new List<int>();
            List<Mutare> intoarcere = new List<Mutare>();
            int k, curent;
            string Name = NumePiesaImagine(pieceName);
            CuloarePiesa culoareaPiesei = VerificareCuloare(pieceName);
            for (k = 0; k < DatelePieselor.Length; k++)
            {
                if (String.Compare(Name, DatelePieselor[k].NumelePiesei) == 0)
                    break;
            }
            if (k == DatelePieselor.Length)
                return intoarcere;
            mutari = GetMutari(DatelePieselor[k].MutarilePiesei1);
            int j, oj;

            for (oj = 0; oj < DatelePieselor.Length; oj++)
            {
                if (String.Compare(DatelePieselor[oj].NumelePiesei, NumePiesaImagine(pieceName)) == 0)
                    break;
            }
            for (i = 0; i < DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri; i++)
                if (String.Compare(maingame.pieceIdBoard[i].PieceName, pieceName) == 0)
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
                                                if (VerificareCuloare(maingame.pieceIdBoard[curent + valoare].PieceName) != culoareaPiesei)
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
                                                if (VerificareCuloare(maingame.pieceIdBoard[curent + valoare].PieceName) != culoareaPiesei)
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
                                suma = 0;
                                foreach (int valoare in mutari)
                                {
                                    if (j <= DatelePieselor[oj].MutarilePiesei1.Length - 1)

                                    {
                                        suma = suma + valoare;

                                    }

                                    if (j == DatelePieselor[oj].MutarilePiesei1.Length - 1)
                                    {

                                        if (CheckCan(maingame, curent, suma))
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + suma, maingame.pieceIdBoard[i].PieceValue, false));
                                            else
                                            {
                                                if (VerificareCuloare(maingame.pieceIdBoard[curent + valoare].PieceName) != culoareaPiesei)
                                                    intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + suma, maingame.pieceIdBoard[i].PieceValue, false));

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

                                        if (CheckCan(maingame, curent, suma) && verific == 0)
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + suma].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));
                                            else
                                            {
                                                if (VerificareCuloare(maingame.pieceIdBoard[curent + suma].PieceName) != culoareaPiesei)
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
                        capturaLista = GetMutari(DatelePieselor[oj].MutarilePieseiCaptura);
                        if (DatelePieselor[oj].RaspunsIntrb2 == true)
                        {
                            if (DatelePieselor[oj].RaspunsIntrb3 == true)
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

                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) != 0)
                                                verific = 1;

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


                                            curent = curent + valoare;
                                        }

                                        j++;

                                    }

                                }


                            }
                        }
                        else
                        {
                            if (DatelePieselor[oj].RaspunsIntrb3 == true)
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

                                        if (CheckCan(maingame, curent, suma) && verific == 0)
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + suma].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));



                                        }

                                        j = 1;
                                        suma = 0;
                                        verific = 0;


                                    }

                                }
                            }
                            else
                            {
                                j = 1;
                                curent = maingame.pieceIdBoard[i].PiecePosition;
                                suma = 0;
                                foreach (int valoare in mutari)
                                {
                                    if (j <= DatelePieselor[oj].MutarilePiesei1.Length - 1)

                                    {
                                        suma = suma + valoare;

                                    }

                                    if (j == DatelePieselor[oj].MutarilePiesei1.Length - 1)
                                    {

                                        if (CheckCan(maingame, curent, suma))
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + suma, maingame.pieceIdBoard[i].PieceValue, false));



                                        }

                                        j = 1;
                                        suma = 0;


                                    }

                                }
                            }
                        }
                        curent = maingame.pieceIdBoard[i].PiecePosition;
                        foreach (int pozitie in capturaLista)
                        {
                            if (CheckCan(maingame, curent, pozitie))
                            {
                                if (VerificareCuloare(maingame.pieceIdBoard[curent + pozitie].PieceName) != culoareaPiesei)
                                    intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + pozitie, maingame.pieceIdBoard[i].PieceValue, false));
                            }
                        }
                    }
                }
            if (DatelePieselor[oj].MutarilePiesei2.Length > 1)
            { mutari = GetMutari(DatelePieselor[k].MutarilePiesei2); 
            for (i = 0; i < DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri; i++)
                if (String.Compare(maingame.pieceIdBoard[i].PieceName, pieceName) == 0)
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
                                    if (j >= DatelePieselor[oj].MutarilePiesei2.Length)

                                    {
                                        j = 1;
                                        curent = maingame.pieceIdBoard[i].PiecePosition;

                                    }

                                    if (j < DatelePieselor[oj].MutarilePiesei2.Length)
                                    {

                                        if (CheckCan(maingame, curent, valoare))
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));
                                            else
                                            {
                                                if (VerificareCuloare(maingame.pieceIdBoard[curent + valoare].PieceName) != culoareaPiesei)
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
                                    if (j >= DatelePieselor[oj].MutarilePiesei2.Length)

                                    {
                                        j = 1;
                                        curent = maingame.pieceIdBoard[i].PiecePosition;
                                        verific = 0;

                                    }

                                    if (j < DatelePieselor[oj].MutarilePiesei2.Length)
                                    {

                                        if (CheckCan(maingame, curent, valoare) && verific == 0)
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));
                                            else
                                            {
                                                if (VerificareCuloare(maingame.pieceIdBoard[curent + valoare].PieceName) != culoareaPiesei)
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
                                suma = 0;
                                foreach (int valoare in mutari)
                                {
                                    if (j <= DatelePieselor[oj].MutarilePiesei2.Length - 1)

                                    {
                                        suma = suma + valoare;

                                    }

                                    if (j == DatelePieselor[oj].MutarilePiesei2.Length - 1)
                                    {

                                        if (CheckCan(maingame, curent, suma))
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + suma, maingame.pieceIdBoard[i].PieceValue, false));
                                            else
                                            {
                                                if (VerificareCuloare(maingame.pieceIdBoard[curent + valoare].PieceName) != culoareaPiesei)
                                                    intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + suma, maingame.pieceIdBoard[i].PieceValue, false));

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
                                    if (j <= DatelePieselor[oj].MutarilePiesei2.Length - 1)

                                    {
                                        suma = suma + valoare;
                                        if (String.Compare("-", maingame.pieceIdBoard[curent + suma].PieceName) != 0)
                                            verific = 1;
                                    }

                                    if (j == DatelePieselor[oj].MutarilePiesei2.Length - 1)
                                    {

                                        if (CheckCan(maingame, curent, suma) && verific == 0)
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + suma].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));
                                            else
                                            {
                                                if (VerificareCuloare(maingame.pieceIdBoard[curent + suma].PieceName) != culoareaPiesei)
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
                        capturaLista = GetMutari(DatelePieselor[oj].MutarilePieseiCaptura);
                        if (DatelePieselor[oj].RaspunsIntrb2 == true)
                        {
                            if (DatelePieselor[oj].RaspunsIntrb3 == true)
                            {
                                j = 1;
                                curent = maingame.pieceIdBoard[i].PiecePosition;
                                verific = 0;
                                foreach (int valoare in mutari)
                                {
                                    if (j >= DatelePieselor[oj].MutarilePiesei2.Length)

                                    {
                                        j = 1;
                                        curent = maingame.pieceIdBoard[i].PiecePosition;
                                        verific = 0;

                                    }

                                    if (j < DatelePieselor[oj].MutarilePiesei2.Length)
                                    {

                                        if (CheckCan(maingame, curent, valoare) && verific == 0)
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));

                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) != 0)
                                                verific = 1;

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
                                foreach (int valoare in mutari)
                                {
                                    if (j >= DatelePieselor[oj].MutarilePiesei2.Length)

                                    {
                                        j = 1;
                                        curent = maingame.pieceIdBoard[i].PiecePosition;

                                    }

                                    if (j < DatelePieselor[oj].MutarilePiesei2.Length)
                                    {

                                        if (CheckCan(maingame, curent, valoare))
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));


                                            curent = curent + valoare;
                                        }

                                        j++;

                                    }

                                }


                            }
                        }
                        else
                        {
                            if (DatelePieselor[oj].RaspunsIntrb3 == true)
                            {
                                j = 1;
                                curent = maingame.pieceIdBoard[i].PiecePosition;
                                suma = 0;
                                verific = 0;
                                foreach (int valoare in mutari)
                                {
                                    if (j <= DatelePieselor[oj].MutarilePiesei2.Length - 1)

                                    {
                                        suma = suma + valoare;
                                        if (String.Compare("-", maingame.pieceIdBoard[curent + suma].PieceName) != 0)
                                            verific = 1;
                                    }

                                    if (j == DatelePieselor[oj].MutarilePiesei2.Length - 1)
                                    {

                                        if (CheckCan(maingame, curent, suma) && verific == 0)
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + suma].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + valoare, maingame.pieceIdBoard[i].PieceValue, false));



                                        }

                                        j = 1;
                                        suma = 0;
                                        verific = 0;


                                    }

                                }
                            }
                            else
                            {
                                j = 1;
                                curent = maingame.pieceIdBoard[i].PiecePosition;
                                suma = 0;
                                foreach (int valoare in mutari)
                                {
                                    if (j <= DatelePieselor[oj].MutarilePiesei2.Length - 1)

                                    {
                                        suma = suma + valoare;

                                    }

                                    if (j == DatelePieselor[oj].MutarilePiesei2.Length - 1)
                                    {

                                        if (CheckCan(maingame, curent, suma))
                                        {
                                            if (String.Compare("-", maingame.pieceIdBoard[curent + valoare].PieceName) == 0)
                                                intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + suma, maingame.pieceIdBoard[i].PieceValue, false));



                                        }

                                        j = 1;
                                        suma = 0;


                                    }

                                }
                            }
                        }
                        curent = maingame.pieceIdBoard[i].PiecePosition;
                        foreach (int pozitie in capturaLista)
                        {
                            if (CheckCan(maingame, curent, pozitie))
                            {
                                if (VerificareCuloare(maingame.pieceIdBoard[curent + pozitie].PieceName) != culoareaPiesei)
                                    intoarcere.Add(new Mutare(maingame.pieceIdBoard[i].PiecePosition, curent + pozitie, maingame.pieceIdBoard[i].PieceValue, false));
                            }
                        }
                    }
                }
        }
            return intoarcere;
        }

        private  bool CheckCan(MainGame maingame, int curent, int valoare)
        {
            int a = maingame.DatePartidaCastig.NumarColoane;
            if (valoare == 1)
                if ((curent + valoare) / DatePartidaCastig.NumarColoane != curent / DatePartidaCastig.NumarColoane || curent + valoare >= DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri)
                    return false;
                else
                    return true;
            if (valoare == -1)
                if ((curent + valoare) / DatePartidaCastig.NumarColoane != curent / DatePartidaCastig.NumarColoane || curent + valoare < 0)
                    return false;
                else
                    return true;
            if (valoare == a+1)
                if ((curent + valoare) / DatePartidaCastig.NumarColoane - curent / DatePartidaCastig.NumarColoane > 1 || curent + valoare >= DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri)
                    return false;
                else
                    return true;
            if (valoare == 0-a-1)
                if (curent / DatePartidaCastig.NumarColoane - (curent + valoare) / DatePartidaCastig.NumarColoane != 1 || curent + valoare < 0)
                    return false;
                else
                    return true;
            if (valoare == a-1)
                if ((curent + valoare) / DatePartidaCastig.NumarColoane == curent / DatePartidaCastig.NumarColoane || curent + valoare >= DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri)
                    return false;
                else
                    return true;
            if (valoare == 0-a+1)
                if ((curent + valoare) / DatePartidaCastig.NumarColoane == curent / DatePartidaCastig.NumarColoane || curent + valoare >= DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri)
                    return false;
                else
                    return true;
            if (valoare == a)
                if (curent + valoare >= DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri)
                    return false;
                else
                    return true;
            if (valoare == -a)
                if (curent + valoare < 0)
                    return false;
                else
                    return true;
            return false;
            /*switch (valoare)
            {
                case 1:
                    if ((curent + valoare) / DatePartidaCastig.NumarColoane != curent / DatePartidaCastig.NumarColoane || curent + valoare >= DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri)
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
                    if ((curent + valoare) / DatePartidaCastig.NumarColoane - curent / DatePartidaCastig.NumarColoane > 1 ||curent + valoare >= DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri)
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
                    if ((curent + valoare) / DatePartidaCastig.NumarColoane == curent / DatePartidaCastig.NumarColoane || curent +valoare >= DatePartidaCastig.NumarColoane* DatePartidaCastig.NumarRanduri)
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
            */
            
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
        
        private void SetareTablaIncolora()
        {
            for (int l = 0; l < DatePartidaCastig.NumarColoane*DatePartidaCastig.NumarRanduri;l++)
            {
                pieceIdBoard[l].BackColor = Color.Transparent;
            }
        }
        internal void UpdateTabla(int pozitie)
        {
            PrimaApasareAPiesei = true;
            pieceIdBoard[pozitie].Image = pieceIdBoard[PozitiaDeStartAPiesei].Image;
            pieceIdBoard[PozitiaDeStartAPiesei].Image = null;
            pieceIdBoard[pozitie].PieceName = pieceIdBoard[PozitiaDeStartAPiesei].PieceName;
            pieceIdBoard[PozitiaDeStartAPiesei].PieceName = "-";
            pieceIdBoard[pozitie].PieceValue = pieceIdBoard[PozitiaDeStartAPiesei].PieceValue;
            pieceIdBoard[PozitiaDeStartAPiesei].PieceValue = 0;
            pieceIdBoard[pozitie].SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            if (pieceIdBoard[PozitiaDeStartAPiesei].IsFirstMove == true)
            {
                pieceIdBoard[PozitiaDeStartAPiesei].IsFirstMove = false;
            }
            ResultsInCheck();
        }
        private bool ResultsInCheck()
        {
            List<Mutare> list2 = new List<Mutare>(); 
            list2 = GetToateMutarilePosibileBlack(this);
            string sfpartida = NumePiesaafisaj(DatePartidaCastig.NumePiesa, CuloarePiesa.Alb);
            // if white king position is same as black's destination position, 
            // this would result in check, return true
            for (int i = 0; i < DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri; i++)
            {
                if (String.Compare(pieceIdBoard[i].PieceName, sfpartida) == 0)
                {
                    foreach (Mutare move in list2)
                    {
                        if (pieceIdBoard[i].PiecePosition == move.To)
                        {
                            string msg = "Jucătorul alb este în șah!";
                            pieceIdBoard[pieceIdBoard[i].PiecePosition].BackColor = Color.Red;
                            pieceIdBoard[pieceIdBoard[i].PiecePosition].Refresh();
                            DialogResult result;
                            WhiteInCheck = move.From;
                            result = MessageBox.Show(msg);
                            return true;
                        }
                    }
                }
            }
            
            list2 = GetToateMutarilePosibileWhite(this);
            sfpartida = NumePiesaafisaj(DatePartidaCastig.NumePiesa, CuloarePiesa.Negru);

            for (int i = 0; i < DatePartidaCastig.NumarColoane * DatePartidaCastig.NumarRanduri; i++)
            {
                if (String.Compare(pieceIdBoard[i].PieceName, sfpartida) == 0)
                {
                    foreach (Mutare move in list2)
                    {
                        if (pieceIdBoard[i].PiecePosition == move.To)
                        {
                            string msg = "Jucătorul negru este în șah!";
                            pieceIdBoard[pieceIdBoard[i].PiecePosition].BackColor = Color.Red;
                            pieceIdBoard[pieceIdBoard[i].PiecePosition].Refresh();
                            DialogResult result;
                            BlackInCheck = move.From;
                            result = MessageBox.Show(msg);
                            return true;
                        }
                    }
                }
            }
            
            return false;
        }
        public bool InitiateComputerMove()
        {
            Mutare CeaMaiBunaMutare = new Mutare();
            List<Mutare> returnareLista = new List<Mutare>();
            List<Mutare> list = new List<Mutare>();
            MainGame m = new MainGame(this, DatePartidaCastig, DatelePieselor);
            if (DatePartidaCastig.Culoare != CuloarePiesa.Alb)
            {
                if (WhiteInCheck > 0)
                {
                    list = GetOutOfCheck(m, CuloarePiesa.Alb);
                    if (VerificareSahMat(list, m, CuloarePiesa.Alb))
                    {
                        return true;
                    }
                    if (list.Count == 0)
                    {
                        CheckMate = true;
                        return true;
                    }
                    else
                    {
                        foreach (Mutare md in list)
                        {
                            if (md.To == WhiteInCheck)
                            {
                                PozitiaDeStartAPiesei = md.From;
                                WhiteInCheck = -1;
                                LastMove.From = md.From;
                                LastMove.To = md.To;
                                UpdateTabla(md.To);
                                SetareTablaIncolora();
                                pieceIdBoard[md.From].BackColor = Color.Chocolate;
                                pieceIdBoard[md.To].BackColor = Color.Chocolate;

                                return true;
                            }
                        }
                        PozitiaDeStartAPiesei = list[0].From;
                        WhiteInCheck = -1;
                        LastMove.From = list[0].From;
                        LastMove.To = list[0].To;
                        UpdateTabla(list[0].To);
                        SetareTablaIncolora();
                        pieceIdBoard[list[0].From].BackColor = Color.Chocolate;
                        pieceIdBoard[list[0].To].BackColor = Color.Chocolate;
                    }
                    return true;
                }
            }
            else
            {
                if (BlackInCheck > 0)
                {
                    list = GetOutOfCheck(m,CuloarePiesa.Negru);
                    if (VerificareSahMat(list,m,CuloarePiesa.Negru))
                    {
                        return true;
                    }
                    if (list.Count == 0)
                    {
                        CheckMate = true;
                        return true;
                    }
                    else
                    {
                        foreach (Mutare md in list)
                        {
                            if (md.To == BlackInCheck)
                            {
                                PozitiaDeStartAPiesei = md.From;
                                BlackInCheck = -1;
                                UpdateTabla(md.To);
                                SetareTablaIncolora();
                                pieceIdBoard[md.From].BackColor = Color.Chocolate;
                                pieceIdBoard[md.To].BackColor = Color.Chocolate;

                                return true;
                            }
                        }
                        PozitiaDeStartAPiesei = list[0].From;
                        BlackInCheck = -1;
                        UpdateTabla(list[0].To);
                        SetareTablaIncolora();
                        pieceIdBoard[list[0].From].BackColor = Color.Chocolate;
                        pieceIdBoard[list[0].To].BackColor = Color.Chocolate;
                    }
                    return true;
                }
            }
            returnareLista = CeaMaiBunaMutare.EvaluareMutare(3, m);
            CuloarePiesa culoare = CuloarePiesa.Negru ;
            if (m.DatePartidaCastig.Culoare == CuloarePiesa.Negru)
                culoare = CuloarePiesa.Alb;
                if (returnareLista.Count == 1)
            {
                if (!returnareLista[0].IsCheckMove(returnareLista, returnareLista[0].From, returnareLista[0].To, m, culoare))
                {
                    if (returnareLista[0].To != LastMove.From || returnareLista[0].From != LastMove.To)
                    {
                        LastMove.From = returnareLista[0].From;
                        LastMove.To = returnareLista[0].To;
                        PozitiaDeStartAPiesei = returnareLista[0].From;
                        BlackInCheck = -1;

                        UpdateTabla(returnareLista[0].To);
                        return true;
                    }

                }
            }

            for (int i = returnareLista.Count - 1; i >= 0; i--)
            {
                if (!returnareLista[i].IsCheckMove(returnareLista, returnareLista[i].From, returnareLista[i].To, m, culoare))
                {
                    if (returnareLista[i].To != LastMove.From || returnareLista[i].From != LastMove.To)
                    {
                        LastMove.From = returnareLista[i].From;
                        LastMove.To = returnareLista[i].To;
                        PozitiaDeStartAPiesei = returnareLista[i].From;
                        BlackInCheck = -1;
                        UpdateTabla(returnareLista[i].To);
                        return true;
                    }
                }
            }
            return false;
        }

        

        private List<Mutare> GetOutOfCheck (MainGame man,CuloarePiesa color)
        {
            List<Mutare> intors = new List<Mutare>();
            if (color == CuloarePiesa.Alb)
            {
                bool atLeastOneAttack = false;
                List<Mutare> list = GetToateMutarilePosibileWhite(man);
                string sfpartida = man.NumePiesaafisaj(man.DatePartidaCastig.NumePiesa, CuloarePiesa.Alb);
                foreach (Mutare move in list)
                {

                    MainGame testStare = new MainGame(man, DatePartidaCastig, DatelePieselor);
                    move.MakeMoveLight(move.From, move.To, testStare);
                    for (int i = 0; i < testStare.DatePartidaCastig.NumarColoane * testStare.DatePartidaCastig.NumarRanduri; i++)
                    {
                        if (String.Compare(testStare.pieceIdBoard[i].PieceName, sfpartida) == 0)
                        {
                            List<Mutare> list2 = GetToateMutarilePosibileBlack(testStare);
                            foreach (Mutare move2 in list2)
                            {
                                if (testStare.pieceIdBoard[i].PiecePosition == move2.To)
                                {
                                    atLeastOneAttack = true;
                                    break;
                                }
                            }
                            if (!atLeastOneAttack)
                            {
                                intors.Add(new Mutare(move.From, move.To, man.pieceIdBoard[move.To].PieceValue, false));
                            }
                            atLeastOneAttack = false;
                        }
                    }
                }
                return intors;
            }
            else
            {
                bool atLeastOneAttack = false;
                List<Mutare> list = GetToateMutarilePosibileBlack(man);
                string sfpartida = man.NumePiesaafisaj(man.DatePartidaCastig.NumePiesa, CuloarePiesa.Negru);
                foreach (Mutare move in list)
                {

                    MainGame testStare = new MainGame(man, DatePartidaCastig, DatelePieselor);
                    move.MakeMoveLight(move.From, move.To, testStare);
                    for (int i = 0; i < testStare.DatePartidaCastig.NumarColoane * testStare.DatePartidaCastig.NumarRanduri; i++)
                    {
                        if (String.Compare(testStare.pieceIdBoard[i].PieceName, sfpartida) == 0)
                        {
                            List<Mutare> list2 = GetToateMutarilePosibileWhite(testStare);
                            foreach (Mutare move2 in list2)
                            {
                                if (testStare.pieceIdBoard[i].PiecePosition == move2.To)
                                {
                                    atLeastOneAttack = true;
                                    break;
                                }
                            }
                            if (!atLeastOneAttack)
                            {
                                intors.Add(new Mutare(move.From, move.To, man.pieceIdBoard[move.To].PieceValue, false));
                            }
                            atLeastOneAttack = false;
                        }
                    }
                }
                return intors;
            }
            
        }
        private bool VerificareSahMat(List<Mutare> list, MainGame m, CuloarePiesa col)
        {
            if (list.Count == 1)
            {
                if (list[0].IsCheckMove(list, list[0].From,list[0].To, m, col))
                {
                    CheckMate = true;
                    return true;
                }
            }
            else if (list.Count == 0)
            {
                CheckMate = true;
                return true;
            }

            return false;
        }
    }
}
