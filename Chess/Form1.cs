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
                if(dialogjocnou.Info.Type == TipJoc.ReguliSchimbate)
                {
                    this.Hide();
                    Global.GlobalCuloare = dialogjocnou.Info.PlayerColor;
                    Global.GlobalMarime = dialogjocnou.Info.SizeTable;
                    {
                        SelectWINCustomMode dialogWin = new SelectWINCustomMode();
                        dialogWin.ShowDialog();
                    }
                    /*SelectPropsCustomMode dialogProps = new SelectPropsCustomMode();
                    var result = dialogProps.ShowDialog();
                    if ( result == DialogResult.OK)
                    {
                        SelectWINCustomMode dialogWin = new SelectWINCustomMode();
                    }
                    */
                    
                }    
            }

            
        }
    }
}
