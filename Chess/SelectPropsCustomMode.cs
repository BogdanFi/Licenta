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
    public partial class SelectPropsCustomMode : Form
    {
        public SelectPropsCustomMode()
        {
            InitializeComponent();
            Sidepanel.Height = button1.Height;
            Sidepanel.Top = button1.Top;
            pionCustomControl1.BringToFront();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button1.Height;
            Sidepanel.Top = button1.Top;
            pionCustomControl1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button2.Height;
            Sidepanel.Top = button2.Top;
            turaCustomControl.BringToFront();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button3.Height;
            Sidepanel.Top = button3.Top;
            calCustomControl.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button4.Height;
            Sidepanel.Top = button4.Top;
            nebunCustomControl.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button5.Height;
            Sidepanel.Top = button5.Top;
            reginaCustomControl.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button6.Height;
            Sidepanel.Top = button6.Top;
            regeCustomControl.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (pionCustomControl1.Info.Save == true)
            {
                if(turaCustomControl.Info.Save == true)
                {
                    if(calCustomControl.Info.Save == true)
                    {
                        if(nebunCustomControl.Info.Save == true)
                        {
                            if(reginaCustomControl.Info.Save == true)
                            {
                                if (regeCustomControl.Info.Save == true)
                                {
                                    MessageBox.Show("Felicitari");
                                }
                                else
                                    MessageBox.Show("Nu ați salvat încă mutările regelui");
                            }
                            else
                                MessageBox.Show("Nu ați salvat încă mutările reginei");
                        }
                        else
                            MessageBox.Show("Nu ați salvat încă mutările nebunului");
                    }
                    else
                        MessageBox.Show("Nu ați salvat încă mutările calului");
                }
                else
                    MessageBox.Show("Nu ați salvat încă mutările turei");
            }
            else
                MessageBox.Show("Nu ați salvat încă mutările pionului");
        }
    }
}
