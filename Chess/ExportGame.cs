using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Chess
{
    public partial class ExportGame : Form
    {
        static int count =3;
        bool ok;
        DateCastigPartida date1 = SelectWINCustomMode.Info;
        DateleNouluiJoc[] date2 = SelectPropsCustomMode.Info;
        public ExportGame()
        {
            InitializeComponent();
            ok = true;
            
        }
        private void CreateLabel(Point Locate,String informatii)
        {
            System.Windows.Forms.Label label;
            label = new System.Windows.Forms.Label();
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("MS PGothic", 11.25F);
            label.ForeColor = System.Drawing.Color.White;
            label.Location = Locate;
            label.Name = "label"+count;
            count++;
            label.Size = new System.Drawing.Size(43, 15);
            label.TabIndex = 1;
            label.Text = String.Copy(informatii);
            this.panel1.Controls.Add(label);
        }
        private void ExportGame_Load(object sender, EventArgs e)
        {
            int i,j;
            StringBuilder sb,ab;
            Point Locatie = new Point(4, 77);
            for (i=0;i<date2.Length;i++)
            {
                sb = new StringBuilder();
                ab = new StringBuilder();
                for (j = 0; j < date2[i].MutarilePiesei1.Length; j++)
                    sb.Append(date2[i].MutarilePiesei1[j]+" ");
                CreateLabel(Locatie, date2[i].NumelePiesei +" : "+ sb);
                Locatie = new Point(4, Locatie.Y + 17);
                if (date2[i].MutarilePiesei2 != null)
                {
                    for (j = 0; j < date2[i].MutarilePiesei2.Length; j++)
                        ab.Append(date2[i].MutarilePiesei2[j] + " ");
                    CreateLabel(Locatie, date2[i].NumelePiesei + " : " + ab);
                    Locatie = new Point(4, Locatie.Y + 17);
                }
            }
            CreateLabel(Locatie,"Piesa care determină finalul partidei este: "+date1.NumePiesa);
            Locatie = new Point(4, Locatie.Y + 17);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ok == true)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text files (*.txt)|*.txt";
                sfd.FileName = "GameRules";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        ok = false;
                        button1.Text = "Start game";
                        string path = sfd.FileName;
                        IFormatter formatter = new BinaryFormatter();
                        Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
                        formatter.Serialize(stream, date1);
                        for (int i = 0; i < date2.Length; i++)
                            formatter.Serialize(stream, date2[i]);
                        stream.Close();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }
            else
            {
                this.Close();
                MainGame jocnou = new MainGame();
                jocnou.SetValue(2);
                jocnou.ShowDialog();
            }
        }

        
    }
}
