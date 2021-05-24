namespace Chess
{
    partial class DialogJocNou
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Negru = new System.Windows.Forms.RadioButton();
            this.btn_alb = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_regulischimbate = new System.Windows.Forms.RadioButton();
            this.btn_clasic = new System.Windows.Forms.RadioButton();
            this.btn_Inapoi = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Negru);
            this.groupBox1.Controls.Add(this.btn_alb);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(75, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Culoarea jucatorului";
            // 
            // btn_Negru
            // 
            this.btn_Negru.AutoSize = true;
            this.btn_Negru.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Negru.Location = new System.Drawing.Point(6, 52);
            this.btn_Negru.Name = "btn_Negru";
            this.btn_Negru.Size = new System.Drawing.Size(66, 22);
            this.btn_Negru.TabIndex = 1;
            this.btn_Negru.Text = "Negru";
            this.btn_Negru.UseVisualStyleBackColor = true;
            // 
            // btn_alb
            // 
            this.btn_alb.AutoSize = true;
            this.btn_alb.Checked = true;
            this.btn_alb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alb.Location = new System.Drawing.Point(3, 22);
            this.btn_alb.Name = "btn_alb";
            this.btn_alb.Size = new System.Drawing.Size(46, 22);
            this.btn_alb.TabIndex = 0;
            this.btn_alb.TabStop = true;
            this.btn_alb.Text = "Alb";
            this.btn_alb.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_regulischimbate);
            this.groupBox2.Controls.Add(this.btn_clasic);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(75, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 191);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipul de joc";
            // 
            // btn_regulischimbate
            // 
            this.btn_regulischimbate.AutoSize = true;
            this.btn_regulischimbate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_regulischimbate.Location = new System.Drawing.Point(3, 52);
            this.btn_regulischimbate.Name = "btn_regulischimbate";
            this.btn_regulischimbate.Size = new System.Drawing.Size(139, 22);
            this.btn_regulischimbate.TabIndex = 1;
            this.btn_regulischimbate.Text = "Reguli schimbate";
            this.btn_regulischimbate.UseVisualStyleBackColor = true;
            // 
            // btn_clasic
            // 
            this.btn_clasic.AutoSize = true;
            this.btn_clasic.Checked = true;
            this.btn_clasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clasic.Location = new System.Drawing.Point(3, 22);
            this.btn_clasic.Name = "btn_clasic";
            this.btn_clasic.Size = new System.Drawing.Size(67, 22);
            this.btn_clasic.TabIndex = 0;
            this.btn_clasic.TabStop = true;
            this.btn_clasic.Text = "Clasic";
            this.btn_clasic.UseVisualStyleBackColor = true;
            // 
            // btn_Inapoi
            // 
            this.btn_Inapoi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Inapoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Inapoi.Location = new System.Drawing.Point(49, 393);
            this.btn_Inapoi.Name = "btn_Inapoi";
            this.btn_Inapoi.Size = new System.Drawing.Size(75, 23);
            this.btn_Inapoi.TabIndex = 2;
            this.btn_Inapoi.Text = "Inapoi";
            this.btn_Inapoi.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(188, 393);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(439, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mărimea tabelei de joc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(370, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nr rânduri";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(373, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nr coloane";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(480, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Items.Add(4);
            this.comboBox1.Items.Add(5);
            this.comboBox1.Items.Add(6);
            this.comboBox1.Items.Add(7);
            this.comboBox1.Items.Add(8);
            this.comboBox1.Items.Add(9);
            this.comboBox1.Items.Add(10);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(480, 127);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.Items.Add(4);
            this.comboBox2.Items.Add(5);
            this.comboBox2.Items.Add(6);
            this.comboBox2.Items.Add(7);
            this.comboBox2.Items.Add(8);
            this.comboBox2.Items.Add(9);
            this.comboBox2.Items.Add(10);
            // 
            // DialogJocNou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_Inapoi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DialogJocNou";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton btn_Negru;
        private System.Windows.Forms.RadioButton btn_alb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton btn_regulischimbate;
        private System.Windows.Forms.RadioButton btn_clasic;
        private System.Windows.Forms.Button btn_Inapoi;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}