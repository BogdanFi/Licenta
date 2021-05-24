using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class ExportGame : Form
    {
        bool ok;
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
                    string path = sfd.FileName;
                    BinaryWriter bw = new BinaryWriter(File.Create(path));
                    bw.Write("Am reusit");
                    bw.Dispose();
                    ok = false;
                    button1.Text = "Start game";
                }
            }
            else
            {

            }
        }
    }
}
