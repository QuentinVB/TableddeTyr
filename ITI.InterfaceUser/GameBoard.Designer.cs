﻿namespace ITI.InterfaceUser
{
    partial class m_GameBoard
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
            this.m_PlayerTurn = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_buttonRetourMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_PlayerTurn
            // 
            this.m_PlayerTurn.Location = new System.Drawing.Point(743, 30);
            this.m_PlayerTurn.Name = "m_PlayerTurn";
            this.m_PlayerTurn.Size = new System.Drawing.Size(195, 22);
            this.m_PlayerTurn.TabIndex = 2;
            this.m_PlayerTurn.TabStop = false;
            this.m_PlayerTurn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(686, 633);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // m_buttonRetourMenu
            // 
            this.m_buttonRetourMenu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonRetourMenu.Location = new System.Drawing.Point(812, 587);
            this.m_buttonRetourMenu.Name = "m_buttonRetourMenu";
            this.m_buttonRetourMenu.Size = new System.Drawing.Size(159, 74);
            this.m_buttonRetourMenu.TabIndex = 3;
            this.m_buttonRetourMenu.Text = "Retour au choix des plateaux";
            this.m_buttonRetourMenu.UseVisualStyleBackColor = true;
            // 
            // m_GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 673);
            this.Controls.Add(this.m_buttonRetourMenu);
            this.Controls.Add(this.m_PlayerTurn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "m_GameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Table de Tyr";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox m_PlayerTurn;
        private System.Windows.Forms.Button m_buttonRetourMenu;
    }
}