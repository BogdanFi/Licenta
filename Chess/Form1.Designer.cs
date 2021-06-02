namespace Chess
{
    partial class Form1
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
            this.btn_JocNou = new System.Windows.Forms.Button();
            this.btn_IncarcareJoc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_JocNou
            // 
            this.btn_JocNou.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(30)))));
            this.btn_JocNou.FlatAppearance.BorderSize = 0;
            this.btn_JocNou.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_JocNou.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JocNou.ForeColor = System.Drawing.Color.White;
            this.btn_JocNou.Location = new System.Drawing.Point(313, 111);
            this.btn_JocNou.Name = "btn_JocNou";
            this.btn_JocNou.Size = new System.Drawing.Size(141, 40);
            this.btn_JocNou.TabIndex = 0;
            this.btn_JocNou.Text = "Joc nou";
            this.btn_JocNou.UseVisualStyleBackColor = false;
            this.btn_JocNou.Click += new System.EventHandler(this.btn_JocNou_Click);
            // 
            // btn_IncarcareJoc
            // 
            this.btn_IncarcareJoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(30)))));
            this.btn_IncarcareJoc.FlatAppearance.BorderSize = 0;
            this.btn_IncarcareJoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IncarcareJoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_IncarcareJoc.ForeColor = System.Drawing.Color.White;
            this.btn_IncarcareJoc.Location = new System.Drawing.Point(313, 199);
            this.btn_IncarcareJoc.Name = "btn_IncarcareJoc";
            this.btn_IncarcareJoc.Size = new System.Drawing.Size(141, 40);
            this.btn_IncarcareJoc.TabIndex = 1;
            this.btn_IncarcareJoc.Text = "Încărcare partidă";
            this.btn_IncarcareJoc.UseVisualStyleBackColor = false;
            this.btn_IncarcareJoc.Click += new System.EventHandler(this.btn_IncarcareJoc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_IncarcareJoc);
            this.Controls.Add(this.btn_JocNou);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_JocNou;
        private System.Windows.Forms.Button btn_IncarcareJoc;
    }
}

