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
            this.SuspendLayout();
            // 
            // btn_JocNou
            // 
            this.btn_JocNou.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_JocNou.Location = new System.Drawing.Point(313, 111);
            this.btn_JocNou.Name = "btn_JocNou";
            this.btn_JocNou.Size = new System.Drawing.Size(141, 23);
            this.btn_JocNou.TabIndex = 0;
            this.btn_JocNou.Text = "Joc Nou";
            this.btn_JocNou.UseVisualStyleBackColor = true;
            this.btn_JocNou.Click += new System.EventHandler(this.btn_JocNou_Click);
            
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_JocNou);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_JocNou;
    }
}

