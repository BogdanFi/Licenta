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
    public partial class SelectWINCustomMode : Form
    {
        private string[] piese = { "Pionul", "Tura", "Calul", "Nebunul", "Regina", "Regele" };
        public SelectWINCustomMode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            executa_Chestionar(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            executa_Chestionar(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            executa_Chestionar(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            executa_Chestionar(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            executa_Chestionar(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            executa_Chestionar(5);
        }

        private void executa_Chestionar(int i)
        {
            label1.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();

            GroupBox groupBox1 = new GroupBox();
            // 
            // radioButton2
            // 
            RadioButton radioButton2 = new RadioButton();
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Font = new System.Drawing.Font("Verdana", 11.25F);
            radioButton2.Location = new System.Drawing.Point(7, 56);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new System.Drawing.Size(47, 22);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "No";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            RadioButton radioButton1 = new RadioButton();
            radioButton1.AutoSize = true;
            radioButton1.Font = new System.Drawing.Font("Verdana", 11.25F);
            radioButton1.Location = new System.Drawing.Point(7, 27);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new System.Drawing.Size(51, 22);
            radioButton1.TabIndex = 0;
            radioButton1.Text = "Yes";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.Click += new System.EventHandler(radioButton1_Click);

            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox1.Location = new System.Drawing.Point(650, 65);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(650, 100);
            groupBox1.TabStop = false;
            groupBox1.Text = "Doriți ca partida să se termine când " + piese[i] + " este într-o poziție de șah?";

            this.Controls.Add(groupBox1);

            GroupBox groupBox2 = new GroupBox();
            // 
            // radioButton2
            // 
            RadioButton radioButton3 = new RadioButton();
            radioButton3.AutoSize = true;
            radioButton3.Checked = true;
            radioButton3.Font = new System.Drawing.Font("Verdana", 11.25F);
            radioButton3.Location = new System.Drawing.Point(7, 66);
            radioButton3.Name = "radioButton2";
            radioButton3.Size = new System.Drawing.Size(47, 22);
            radioButton3.TabIndex = 1;
            radioButton3.TabStop = true;
            radioButton3.Text = "No";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            RadioButton radioButton4 = new RadioButton();
            radioButton4.AutoSize = true;
            radioButton4.Font = new System.Drawing.Font("Verdana", 11.25F);
            radioButton4.Location = new System.Drawing.Point(7, 37);
            radioButton4.Name = "radioButton1";
            radioButton4.Size = new System.Drawing.Size(51, 22);
            radioButton4.TabIndex = 0;
            radioButton4.Text = "Yes";
            radioButton4.UseVisualStyleBackColor = true;

            groupBox2.Controls.Add(radioButton3);
            groupBox2.Controls.Add(radioButton4);
            groupBox2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            groupBox2.Location = new System.Drawing.Point(650, 195);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(650, 100);
            groupBox2.TabStop = false;
            groupBox2.Text = "Doriți ca partida să se termine când " + piese[i] + " ajunge pe o anumită poziție de pe tabla de șah?";

            this.Controls.Add(groupBox2);
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
