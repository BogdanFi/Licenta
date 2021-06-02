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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        

        private void btn_JocNou_Click(object sender, EventArgs e)
        {
            DialogJocNou dialogjocnou = new DialogJocNou();
            DialogResult rezultat = dialogjocnou.ShowDialog(this);
            if(rezultat == DialogResult.OK)
            {
               
                this.Hide();
                Global.GlobalCuloare = dialogjocnou.Info.PlayerColor;
                Global.GlobalMarimeLinii = dialogjocnou.Info.SizeTableL;
                Global.GlobalMarimeColoane = dialogjocnou.Info.SizeTableC;
                   
                SelectPropsCustomMode dialogProps = new SelectPropsCustomMode();
                var result = dialogProps.ShowDialog();
                if ( result == DialogResult.OK)
                {
                    SelectWINCustomMode dialogWin = new SelectWINCustomMode();
                    var res = dialogWin.ShowDialog();
                    if (res ==DialogResult.OK)
                    {
                        ExportGame dialogFinal = new ExportGame();
                        dialogFinal.ShowDialog();
                    }
                }
                    

                
            }

            
        }

        private void btn_IncarcareJoc_Click(object sender, EventArgs e)
        {
            DateCastigPartida date1;
            DateleNouluiJoc[] date2 = new DateleNouluiJoc[10];
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text files (*.txt)|*.txt";
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    string path = openFile.FileName;
                    Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    IFormatter formatter = new BinaryFormatter();
                    date1 = (DateCastigPartida)formatter.Deserialize(stream);

                    int i = 0;
                    while (stream.Position != stream.Length)
                    {
                        date2[i] = (DateleNouluiJoc)formatter.Deserialize(stream);
                        i++;
                    }
                    stream.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }
    }
}
