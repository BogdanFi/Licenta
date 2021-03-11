namespace AllPawnsMustDie
{
    partial class NewGameDialog
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
            this.groupBoxPlayerColor = new System.Windows.Forms.GroupBox();
            this.radioButtonBlack = new System.Windows.Forms.RadioButton();
            this.radioButtonWhite = new System.Windows.Forms.RadioButton();
            this.labelThinkTime = new System.Windows.Forms.Label();
            this.numericUpDownThinkTime = new System.Windows.Forms.NumericUpDown();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelFEN = new System.Windows.Forms.Label();
            this.textBoxFEN = new System.Windows.Forms.TextBox();
            this.groupBoxTypeGame = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.groupBoxPlayerColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThinkTime)).BeginInit();
            this.groupBoxTypeGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPlayerColor
            // 
            this.groupBoxPlayerColor.Controls.Add(this.radioButtonBlack);
            this.groupBoxPlayerColor.Controls.Add(this.radioButtonWhite);
            this.groupBoxPlayerColor.Location = new System.Drawing.Point(12, 12);
            this.groupBoxPlayerColor.Name = "groupBoxPlayerColor";
            this.groupBoxPlayerColor.Size = new System.Drawing.Size(181, 72);
            this.groupBoxPlayerColor.TabIndex = 0;
            this.groupBoxPlayerColor.TabStop = false;
            this.groupBoxPlayerColor.Text = "Player color";
            // 
            // radioButtonBlack
            // 
            this.radioButtonBlack.AutoSize = true;
            this.radioButtonBlack.Location = new System.Drawing.Point(7, 42);
            this.radioButtonBlack.Name = "radioButtonBlack";
            this.radioButtonBlack.Size = new System.Drawing.Size(52, 17);
            this.radioButtonBlack.TabIndex = 1;
            this.radioButtonBlack.TabStop = true;
            this.radioButtonBlack.Text = global::AllPawnsMustDie.Properties.Resources.PlayerColorSelectBlack;
            this.radioButtonBlack.UseVisualStyleBackColor = true;
            // 
            // radioButtonWhite
            // 
            this.radioButtonWhite.AutoSize = true;
            this.radioButtonWhite.Location = new System.Drawing.Point(6, 19);
            this.radioButtonWhite.Name = "radioButtonWhite";
            this.radioButtonWhite.Size = new System.Drawing.Size(53, 17);
            this.radioButtonWhite.TabIndex = 0;
            this.radioButtonWhite.TabStop = true;
            this.radioButtonWhite.Text = global::AllPawnsMustDie.Properties.Resources.PlayerColorSelectWhite;
            this.radioButtonWhite.UseVisualStyleBackColor = true;
            // 
            // labelThinkTime
            // 
            this.labelThinkTime.AutoSize = true;
            this.labelThinkTime.Location = new System.Drawing.Point(9, 99);
            this.labelThinkTime.Name = "labelThinkTime";
            this.labelThinkTime.Size = new System.Drawing.Size(121, 13);
            this.labelThinkTime.TabIndex = 1;
            this.labelThinkTime.Text = "Engine Think Time (ms):";
            // 
            // numericUpDownThinkTime
            // 
            this.numericUpDownThinkTime.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownThinkTime.Location = new System.Drawing.Point(139, 97);
            this.numericUpDownThinkTime.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDownThinkTime.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownThinkTime.Name = "numericUpDownThinkTime";
            this.numericUpDownThinkTime.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownThinkTime.TabIndex = 2;
            this.numericUpDownThinkTime.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(119, 345);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = global::AllPawnsMustDie.Properties.Resources.Ok;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(13, 345);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = global::AllPawnsMustDie.Properties.Resources.Cancel;
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // labelFEN
            // 
            this.labelFEN.AutoSize = true;
            this.labelFEN.Location = new System.Drawing.Point(10, 261);
            this.labelFEN.Name = "labelFEN";
            this.labelFEN.Size = new System.Drawing.Size(116, 13);
            this.labelFEN.TabIndex = 5;
            this.labelFEN.Text = "Starting Position (FEN):";
            // 
            // textBoxFEN
            // 
            this.textBoxFEN.Location = new System.Drawing.Point(13, 293);
            this.textBoxFEN.Name = "textBoxFEN";
            this.textBoxFEN.Size = new System.Drawing.Size(181, 20);
            this.textBoxFEN.TabIndex = 6;
            // 
            // groupBoxTypeGame
            // 
            this.groupBoxTypeGame.Controls.Add(this.radioButton5);
            this.groupBoxTypeGame.Controls.Add(this.radioButton4);
            this.groupBoxTypeGame.Controls.Add(this.radioButton3);
            this.groupBoxTypeGame.Controls.Add(this.radioButton1);
            this.groupBoxTypeGame.Controls.Add(this.radioButton2);
            this.groupBoxTypeGame.Location = new System.Drawing.Point(19, 123);
            this.groupBoxTypeGame.Name = "groupBoxTypeGame";
            this.groupBoxTypeGame.Size = new System.Drawing.Size(176, 135);
            this.groupBoxTypeGame.TabIndex = 7;
            this.groupBoxTypeGame.TabStop = false;
            this.groupBoxTypeGame.Text = "Tipul de joc";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 88);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(90, 17);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "KingOfTheHill";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 17);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "3-Check";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Clasic";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Sah 960";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 112);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(87, 17);
            this.radioButton5.TabIndex = 5;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "CustomMode";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // NewGameDialog
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(487, 423);
            this.Controls.Add(this.groupBoxTypeGame);
            this.Controls.Add(this.textBoxFEN);
            this.Controls.Add(this.labelFEN);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.numericUpDownThinkTime);
            this.Controls.Add(this.labelThinkTime);
            this.Controls.Add(this.groupBoxPlayerColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGameDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Game";
            this.groupBoxPlayerColor.ResumeLayout(false);
            this.groupBoxPlayerColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThinkTime)).EndInit();
            this.groupBoxTypeGame.ResumeLayout(false);
            this.groupBoxTypeGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPlayerColor;
        private System.Windows.Forms.RadioButton radioButtonBlack;
        private System.Windows.Forms.RadioButton radioButtonWhite;
        private System.Windows.Forms.Label labelThinkTime;
        private System.Windows.Forms.NumericUpDown numericUpDownThinkTime;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelFEN;
        private System.Windows.Forms.TextBox textBoxFEN;
        private System.Windows.Forms.GroupBox groupBoxTypeGame;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton5;
    }
}