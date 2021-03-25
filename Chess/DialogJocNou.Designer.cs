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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton7);
            this.groupBox3.Controls.Add(this.radioButton6);
            this.groupBox3.Controls.Add(this.radioButton5);
            this.groupBox3.Controls.Add(this.radioButton4);
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox3.Location = new System.Drawing.Point(366, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 236);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "Marimea Tab";
            this.groupBox3.Text = "Mărimea tablei de joc";
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.radioButton7.Location = new System.Drawing.Point(7, 200);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(65, 22);
            this.radioButton7.TabIndex = 6;
            this.radioButton7.Text = "10x10";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.radioButton6.Location = new System.Drawing.Point(7, 170);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(49, 22);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.Text = "9x9";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.radioButton5.Location = new System.Drawing.Point(7, 144);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(49, 22);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "8x8";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.radioButton4.Location = new System.Drawing.Point(7, 113);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(49, 22);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "7x7";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.radioButton3.Location = new System.Drawing.Point(7, 85);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(49, 22);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "6x6";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.radioButton2.Location = new System.Drawing.Point(7, 56);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(49, 22);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "5x5";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.radioButton1.Location = new System.Drawing.Point(7, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(49, 22);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "4x4";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // DialogJocNou
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}