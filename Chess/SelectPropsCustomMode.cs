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
        private int count =6;
        List<Button> Controale= new List<Button>();
        private static DateleNouluiJoc[] DatePiesa;

        public static DateleNouluiJoc [] Info { get { return DatePiesa; } }
        public SelectPropsCustomMode()
        {
            InitializeComponent();
            Sidepanel.Height = button1.Height;
            Sidepanel.Top = button1.Top;
            pionCustomControl1.BringToFront();
            button8.Visible = true;
            
            Controale.Add(button1);
            Controale.Add(button2);
            Controale.Add(button3);
            Controale.Add(button4);
            Controale.Add(button5);
            Controale.Add(button6);

        }
        private UserControl GetUserInterface(Button buton)
        {
            if (buton == button1)
            {
                return pionCustomControl1;
            }
            if (buton == button2)
            {
                return turaCustomControl;
            }
            if (buton == button3)
            {
                return calCustomControl;
            }
            if (buton == button4)
            {
                return nebunCustomControl;
            }
            if (buton == button5)
            {
                return reginaCustomControl;
            }
            if (buton == button6)
            {
                return regeCustomControl;
            }
            return pionCustomControl1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button1.Height;
            Sidepanel.Top = button1.Top;
            pionCustomControl1.BringToFront();
            if (Controale.Contains(button1))
                {
                    button8.Top = button1.Top;
                    button8.Visible = true;
                    button9.Visible = false;
                }
            else
                {
                    button8.Visible = false;
                    button9.Visible = true;
                    button9.Top = button1.Top;
                    
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button2.Height;
            Sidepanel.Top = button2.Top;
            turaCustomControl.BringToFront();
            if (Controale.Contains(button2))
            {
                button8.Top = button2.Top;
                button8.Visible = true;
                button9.Visible = false;
            }
            else
            {
                button8.Visible = false;
                button9.Visible = true;
                button9.Top = button2.Top;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button3.Height;
            Sidepanel.Top = button3.Top;
            calCustomControl.BringToFront();
            if (Controale.Contains(button3))
            {
                button8.Top = button3.Top;
                button8.Visible = true;
                button9.Visible = false;
            }
            else
            {
                button8.Visible = false;
                button9.Visible = true;
                button9.Top = button3.Top;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button4.Height;
            Sidepanel.Top = button4.Top;
            nebunCustomControl.BringToFront();
            if (Controale.Contains(button4))
            {
                button8.Top = button4.Top;
                button8.Visible = true;
                button9.Visible = false;
            }
            else
            {
                button8.Visible = false;
                button9.Visible = true;
                button9.Top = button4.Top;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button5.Height;
            Sidepanel.Top = button5.Top;
            reginaCustomControl.BringToFront();
            if (Controale.Contains(button5))
            {
                button8.Top = button5.Top;
                button8.Visible = true;
                button9.Visible = false;
            }
            else
            {
                button8.Visible = false;
                button9.Visible = true;
                button9.Top = button5.Top;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button6.Height;
            Sidepanel.Top = button6.Top;
            regeCustomControl.BringToFront();
            if (Controale.Contains(button6))
            {
                button8.Top = button6.Top;
                button8.Visible = true;
                button9.Visible = false;
            }
            else
            {
                button8.Visible = false;
                button9.Visible = true;
                button9.Top = button6.Top;

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int ok = 0,i=0;
            foreach (Button buton in Controale)
            {
                if (buton == button1)
                {
                    if(pionCustomControl1.Info.Save == false)
                    { 
                        MessageBox.Show("Nu ați salvat încă mutările pionului");
                        ok = 1;
                        break; 
                    }
                }
                if (buton == button2)
                {
                    if (turaCustomControl.Info.Save == false)
                    {
                        MessageBox.Show("Nu ați salvat încă mutările turei");
                        ok = 1;
                        break;
                    }
                }
                if (buton == button3)
                {
                    if (calCustomControl.Info.Save == false)
                    {
                        MessageBox.Show("Nu ați salvat încă mutările calului");
                        ok = 1;
                        break;
                    }
                }
                if (buton == button4)
                {
                    if (nebunCustomControl.Info.Save == false)
                    {
                        MessageBox.Show("Nu ați salvat încă mutările nebunului");
                        ok = 1;
                        break; 
                    }
                }
                if (buton == button5)
                {
                    if (reginaCustomControl.Info.Save == false)
                    {
                        MessageBox.Show("Nu ați salvat încă mutările reginei");
                        ok = 1;
                        break;
                    }
                }
                if (buton == button6)
                {
                    if (regeCustomControl.Info.Save == false)
                    {
                        MessageBox.Show("Nu ați salvat încă mutările regelui");
                        ok = 1;
                        break;
                    }
                }
            }
            if(ok ==0)
            {
                DatePiesa = new DateleNouluiJoc[Controale.Count];
                foreach (Button buton in Controale)
                {
                    if (buton == button1)
                    {
                        DatePiesa[i] = pionCustomControl1.Info;
                        i++;
                    }
                    if (buton == button2)
                    {
                        DatePiesa[i] = turaCustomControl.Info;
                        i++;
                    }
                    if (buton == button3)
                    {
                        DatePiesa[i] = calCustomControl.Info;
                        i++;
                    }
                    if (buton == button4)
                    {
                        DatePiesa[i] = nebunCustomControl.Info;
                        i++;
                    }
                    if (buton == button5)
                    {
                        DatePiesa[i] = reginaCustomControl.Info;
                        i++;
                    }
                    if (buton == button6)
                    {
                        DatePiesa[i] = regeCustomControl.Info;
                        i++;
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        
        private void button8_Click(object sender, EventArgs e)
        {
            if (Controale.Count > 2)
            {
                foreach (Button buton in Controale)
                {
                    if (buton.Top == button8.Top)
                    {
                        DialogResult dialogResult = MessageBox.Show(String.Format("Sunteți sigur că doriți să eliminați:{0} ?", buton.Text), "Atenție", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            buton.Font = new System.Drawing.Font("MS PGothic", 11.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            buton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(84)))), ((int)(((byte)(95)))));
                            button9.Top = buton.Top;
                            button9.Visible = true;
                            button8.Visible = false;
                            Controale.Remove(buton);
                        }
                        break;
                    }
                }
            }
            else
                MessageBox.Show("Trebuie să aveți măcar 2 piese pe tabla de joc.");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button1.Top == button9.Top)
            {
                DialogResult dialogResult = MessageBox.Show("Sunteți sigur că doriți să reintroduceți Pionul?", "Atenție", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    button1.Font = new System.Drawing.Font("MS PGothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
                    button8.Top = button1.Top;
                    button8.Visible = true;
                    button9.Visible = false;
                    Controale.Add(button1);
                    return;
                }
            }
            if (button2.Top == button9.Top)
            {
                DialogResult dialogResult = MessageBox.Show("Sunteți sigur că doriți să reintroduceți Tura?", "Atenție", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    button2.Font = new System.Drawing.Font("MS PGothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
                    button8.Top = button2.Top;
                    button8.Visible = true;
                    button9.Visible = false;
                    Controale.Add(button2);
                    return;
                }
                
            }
            if (button3.Top == button9.Top)
            {
                DialogResult dialogResult = MessageBox.Show("Sunteți sigur că doriți să reintroduceți Calul?", "Atenție", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    button3.Font = new System.Drawing.Font("MS PGothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
                    button8.Top = button3.Top;
                    button8.Visible = true;
                    button9.Visible = false;
                    Controale.Add(button3);
                    return;
                }

            }
            if (button4.Top == button9.Top)
            {
                DialogResult dialogResult = MessageBox.Show("Sunteți sigur că doriți să reintroduceți Nebunul?", "Atenție", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    button4.Font = new System.Drawing.Font("MS PGothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
                    button8.Top = button4.Top;
                    button8.Visible = true;
                    button9.Visible = false;
                    Controale.Add(button4);
                    return;
                }

            }
            if (button5.Top == button9.Top)
            {
                DialogResult dialogResult = MessageBox.Show("Sunteți sigur că doriți să reintroduceți Regina?", "Atenție", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    button5.Font = new System.Drawing.Font("MS PGothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
                    button8.Top = button5.Top;
                    button8.Visible = true;
                    button9.Visible = false;
                    Controale.Add(button5);
                    return;
                }

            }
            if (button6.Top == button9.Top)
            {
                DialogResult dialogResult = MessageBox.Show("Sunteți sigur că doriți să reintroduceți Regele?", "Atenție", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    button6.Font = new System.Drawing.Font("MS PGothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
                    button8.Top = button6.Top;
                    button8.Visible = true;
                    button9.Visible = false;
                    Controale.Add(button6);
                    return;
                }

            }
        }
    }
}
