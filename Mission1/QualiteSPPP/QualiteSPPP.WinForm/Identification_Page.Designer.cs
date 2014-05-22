﻿namespace QualiteSPPP.WinForm
{
    partial class Identification_Page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Identification_Page));
            this.textBoxMotDePasse = new System.Windows.Forms.TextBox();
            this.labelMotDePasse = new System.Windows.Forms.Label();
            this.labelIndentifiant = new System.Windows.Forms.Label();
            this.textBoxIdentifiant = new System.Windows.Forms.TextBox();
            this.pictureBoxButtonClose = new System.Windows.Forms.PictureBox();
            this.pictureBoxButtonSeConnecter = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxButtonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxButtonSeConnecter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxMotDePasse
            // 
            this.textBoxMotDePasse.Location = new System.Drawing.Point(113, 50);
            this.textBoxMotDePasse.Name = "textBoxMotDePasse";
            this.textBoxMotDePasse.PasswordChar = '●';
            this.textBoxMotDePasse.Size = new System.Drawing.Size(156, 20);
            this.textBoxMotDePasse.TabIndex = 12;
            // 
            // labelMotDePasse
            // 
            this.labelMotDePasse.AutoSize = true;
            this.labelMotDePasse.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMotDePasse.Location = new System.Drawing.Point(16, 53);
            this.labelMotDePasse.Name = "labelMotDePasse";
            this.labelMotDePasse.Size = new System.Drawing.Size(91, 13);
            this.labelMotDePasse.TabIndex = 11;
            this.labelMotDePasse.Text = "Mot de passe :";
            // 
            // labelIndentifiant
            // 
            this.labelIndentifiant.AutoSize = true;
            this.labelIndentifiant.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIndentifiant.Location = new System.Drawing.Point(33, 28);
            this.labelIndentifiant.Name = "labelIndentifiant";
            this.labelIndentifiant.Size = new System.Drawing.Size(74, 13);
            this.labelIndentifiant.TabIndex = 10;
            this.labelIndentifiant.Text = "Identifiant :";
            // 
            // textBoxIdentifiant
            // 
            this.textBoxIdentifiant.Location = new System.Drawing.Point(113, 25);
            this.textBoxIdentifiant.Name = "textBoxIdentifiant";
            this.textBoxIdentifiant.Size = new System.Drawing.Size(156, 20);
            this.textBoxIdentifiant.TabIndex = 9;
            // 
            // pictureBoxButtonClose
            // 
            this.pictureBoxButtonClose.BackgroundImage = global::QualiteSPPP.WinForm.Properties.Resources.fermer_croix_supprimer_erreurs_sortie_icone_4368_128;
            this.pictureBoxButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxButtonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxButtonClose.Location = new System.Drawing.Point(263, 4);
            this.pictureBoxButtonClose.Name = "pictureBoxButtonClose";
            this.pictureBoxButtonClose.Size = new System.Drawing.Size(15, 15);
            this.pictureBoxButtonClose.TabIndex = 15;
            this.pictureBoxButtonClose.TabStop = false;
            this.pictureBoxButtonClose.Click += new System.EventHandler(this.pictureBoxButtonClose_Click);
            // 
            // pictureBoxButtonSeConnecter
            // 
            this.pictureBoxButtonSeConnecter.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxButtonSeConnecter.BackgroundImage = global::QualiteSPPP.WinForm.Properties.Resources.Button_Login;
            this.pictureBoxButtonSeConnecter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxButtonSeConnecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxButtonSeConnecter.Location = new System.Drawing.Point(142, 92);
            this.pictureBoxButtonSeConnecter.Name = "pictureBoxButtonSeConnecter";
            this.pictureBoxButtonSeConnecter.Size = new System.Drawing.Size(135, 19);
            this.pictureBoxButtonSeConnecter.TabIndex = 13;
            this.pictureBoxButtonSeConnecter.TabStop = false;
            this.pictureBoxButtonSeConnecter.Click += new System.EventHandler(this.pictureBoxButtonSeConnecter_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.BackgroundImage = global::QualiteSPPP.WinForm.Properties.Resources.SPPP_Nom_;
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 74);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(147, 71);
            this.pictureBoxLogo.TabIndex = 14;
            this.pictureBoxLogo.TabStop = false;
            // 
            // Identification_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(282, 140);
            this.Controls.Add(this.pictureBoxButtonClose);
            this.Controls.Add(this.pictureBoxButtonSeConnecter);
            this.Controls.Add(this.textBoxMotDePasse);
            this.Controls.Add(this.labelMotDePasse);
            this.Controls.Add(this.labelIndentifiant);
            this.Controls.Add(this.textBoxIdentifiant);
            this.Controls.Add(this.pictureBoxLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(282, 140);
            this.MinimumSize = new System.Drawing.Size(282, 140);
            this.Name = "Identification_Page";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Identification";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxButtonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxButtonSeConnecter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxButtonClose;
        private System.Windows.Forms.PictureBox pictureBoxButtonSeConnecter;
        private System.Windows.Forms.TextBox textBoxMotDePasse;
        private System.Windows.Forms.Label labelMotDePasse;
        private System.Windows.Forms.Label labelIndentifiant;
        private System.Windows.Forms.TextBox textBoxIdentifiant;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}