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
        bool ok;
        DateCastigPartida date1 = SelectWINCustomMode.Info;
        DateleNouluiJoc[] date2 = SelectPropsCustomMode.Info;
        public ExportGame()
        {
            InitializeComponent();
            ok = true;
            
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

            }
        }
    }
}
