namespace ProjetRH_Test_V2
{
    partial class Accueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxAxePrincipal = new System.Windows.Forms.GroupBox();
            this.comboBoxAP_3 = new System.Windows.Forms.ComboBox();
            this.comboBoxAP_2 = new System.Windows.Forms.ComboBox();
            this.comboBoxAP_1 = new System.Windows.Forms.ComboBox();
            this.groupBoxAxesSecondaires = new System.Windows.Forms.GroupBox();
            this.buttonLancerRecherche = new System.Windows.Forms.Button();
            this.buttonAjouterCondition4 = new System.Windows.Forms.Button();
            this.textBoxAS3 = new System.Windows.Forms.TextBox();
            this.comboBoxAS3_4 = new System.Windows.Forms.ComboBox();
            this.comboBoxAS3_3 = new System.Windows.Forms.ComboBox();
            this.comboBoxAS3_2 = new System.Windows.Forms.ComboBox();
            this.comboBoxAS3_1 = new System.Windows.Forms.ComboBox();
            this.buttonAjouterCondition3 = new System.Windows.Forms.Button();
            this.textBoxAS2 = new System.Windows.Forms.TextBox();
            this.comboBoxAS2_4 = new System.Windows.Forms.ComboBox();
            this.comboBoxAS2_3 = new System.Windows.Forms.ComboBox();
            this.comboBoxAS2_2 = new System.Windows.Forms.ComboBox();
            this.comboBoxAS2_1 = new System.Windows.Forms.ComboBox();
            this.buttonAjouterCondition2 = new System.Windows.Forms.Button();
            this.textBoxAS1 = new System.Windows.Forms.TextBox();
            this.comboBoxAS1_4 = new System.Windows.Forms.ComboBox();
            this.comboBoxAS1_3 = new System.Windows.Forms.ComboBox();
            this.comboBoxAS1_2 = new System.Windows.Forms.ComboBox();
            this.comboBoxAS1_1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxAxePrincipal.SuspendLayout();
            this.groupBoxAxesSecondaires.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxAxePrincipal);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxAxesSecondaires);
            this.splitContainer1.Size = new System.Drawing.Size(984, 362);
            this.splitContainer1.SplitterDistance = 53;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxAxePrincipal
            // 
            this.groupBoxAxePrincipal.Controls.Add(this.comboBoxAP_3);
            this.groupBoxAxePrincipal.Controls.Add(this.comboBoxAP_2);
            this.groupBoxAxePrincipal.Controls.Add(this.comboBoxAP_1);
            this.groupBoxAxePrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAxePrincipal.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAxePrincipal.Name = "groupBoxAxePrincipal";
            this.groupBoxAxePrincipal.Size = new System.Drawing.Size(984, 53);
            this.groupBoxAxePrincipal.TabIndex = 0;
            this.groupBoxAxePrincipal.TabStop = false;
            this.groupBoxAxePrincipal.Text = "Orientation de la recherche";
            // 
            // comboBoxAP_3
            // 
            this.comboBoxAP_3.FormattingEnabled = true;
            this.comboBoxAP_3.Location = new System.Drawing.Point(341, 18);
            this.comboBoxAP_3.Name = "comboBoxAP_3";
            this.comboBoxAP_3.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAP_3.TabIndex = 2;
            this.comboBoxAP_3.Visible = false;
            this.comboBoxAP_3.SelectedIndexChanged += new System.EventHandler(this.comboBoxAP_3_SelectedIndexChanged);
            // 
            // comboBoxAP_2
            // 
            this.comboBoxAP_2.FormattingEnabled = true;
            this.comboBoxAP_2.Location = new System.Drawing.Point(180, 19);
            this.comboBoxAP_2.Name = "comboBoxAP_2";
            this.comboBoxAP_2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAP_2.TabIndex = 1;
            this.comboBoxAP_2.Visible = false;
            this.comboBoxAP_2.SelectedIndexChanged += new System.EventHandler(this.comboBoxAP_2_SelectedIndexChanged);
            // 
            // comboBoxAP_1
            // 
            this.comboBoxAP_1.FormattingEnabled = true;
            this.comboBoxAP_1.Items.AddRange(new object[] {
            "Personne",
            "Entretien",
            "Statistique"});
            this.comboBoxAP_1.Location = new System.Drawing.Point(24, 20);
            this.comboBoxAP_1.Name = "comboBoxAP_1";
            this.comboBoxAP_1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAP_1.TabIndex = 0;
            this.comboBoxAP_1.SelectedIndexChanged += new System.EventHandler(this.comboBoxAP1_SelectedIndexChanged);
            // 
            // groupBoxAxesSecondaires
            // 
            this.groupBoxAxesSecondaires.Controls.Add(this.buttonLancerRecherche);
            this.groupBoxAxesSecondaires.Controls.Add(this.buttonAjouterCondition4);
            this.groupBoxAxesSecondaires.Controls.Add(this.textBoxAS3);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS3_4);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS3_3);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS3_2);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS3_1);
            this.groupBoxAxesSecondaires.Controls.Add(this.buttonAjouterCondition3);
            this.groupBoxAxesSecondaires.Controls.Add(this.textBoxAS2);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS2_4);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS2_3);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS2_2);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS2_1);
            this.groupBoxAxesSecondaires.Controls.Add(this.buttonAjouterCondition2);
            this.groupBoxAxesSecondaires.Controls.Add(this.textBoxAS1);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS1_4);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS1_3);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS1_2);
            this.groupBoxAxesSecondaires.Controls.Add(this.comboBoxAS1_1);
            this.groupBoxAxesSecondaires.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAxesSecondaires.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAxesSecondaires.Name = "groupBoxAxesSecondaires";
            this.groupBoxAxesSecondaires.Size = new System.Drawing.Size(984, 305);
            this.groupBoxAxesSecondaires.TabIndex = 0;
            this.groupBoxAxesSecondaires.TabStop = false;
            this.groupBoxAxesSecondaires.Text = "Précisions de recherche";
            // 
            // buttonLancerRecherche
            // 
            this.buttonLancerRecherche.Location = new System.Drawing.Point(806, 270);
            this.buttonLancerRecherche.Name = "buttonLancerRecherche";
            this.buttonLancerRecherche.Size = new System.Drawing.Size(148, 23);
            this.buttonLancerRecherche.TabIndex = 17;
            this.buttonLancerRecherche.Text = "Lancer la recherche";
            this.buttonLancerRecherche.UseVisualStyleBackColor = true;
            this.buttonLancerRecherche.Click += new System.EventHandler(this.buttonLancerRecherche_Click);
            // 
            // buttonAjouterCondition4
            // 
            this.buttonAjouterCondition4.Location = new System.Drawing.Point(806, 109);
            this.buttonAjouterCondition4.Name = "buttonAjouterCondition4";
            this.buttonAjouterCondition4.Size = new System.Drawing.Size(148, 23);
            this.buttonAjouterCondition4.TabIndex = 16;
            this.buttonAjouterCondition4.Text = "Ajouter une condition";
            this.buttonAjouterCondition4.UseVisualStyleBackColor = true;
            this.buttonAjouterCondition4.Visible = false;
            this.buttonAjouterCondition4.Click += new System.EventHandler(this.buttonAjouterCondition4_Click);
            // 
            // textBoxAS3
            // 
            this.textBoxAS3.Location = new System.Drawing.Point(654, 113);
            this.textBoxAS3.Name = "textBoxAS3";
            this.textBoxAS3.Size = new System.Drawing.Size(123, 20);
            this.textBoxAS3.TabIndex = 15;
            this.textBoxAS3.Visible = false;
            // 
            // comboBoxAS3_4
            // 
            this.comboBoxAS3_4.FormattingEnabled = true;
            this.comboBoxAS3_4.Location = new System.Drawing.Point(496, 112);
            this.comboBoxAS3_4.Name = "comboBoxAS3_4";
            this.comboBoxAS3_4.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS3_4.TabIndex = 14;
            this.comboBoxAS3_4.Visible = false;
            this.comboBoxAS3_4.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS3_4_SelectedIndexChanged);
            // 
            // comboBoxAS3_3
            // 
            this.comboBoxAS3_3.FormattingEnabled = true;
            this.comboBoxAS3_3.Location = new System.Drawing.Point(341, 112);
            this.comboBoxAS3_3.Name = "comboBoxAS3_3";
            this.comboBoxAS3_3.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS3_3.TabIndex = 13;
            this.comboBoxAS3_3.Visible = false;
            this.comboBoxAS3_3.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS3_3_SelectedIndexChanged);
            // 
            // comboBoxAS3_2
            // 
            this.comboBoxAS3_2.FormattingEnabled = true;
            this.comboBoxAS3_2.Location = new System.Drawing.Point(180, 112);
            this.comboBoxAS3_2.Name = "comboBoxAS3_2";
            this.comboBoxAS3_2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS3_2.TabIndex = 12;
            this.comboBoxAS3_2.Visible = false;
            this.comboBoxAS3_2.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS3_2_SelectedIndexChanged);
            // 
            // comboBoxAS3_1
            // 
            this.comboBoxAS3_1.FormattingEnabled = true;
            this.comboBoxAS3_1.Items.AddRange(new object[] {
            "Personne",
            "Entretien"});
            this.comboBoxAS3_1.Location = new System.Drawing.Point(24, 113);
            this.comboBoxAS3_1.Name = "comboBoxAS3_1";
            this.comboBoxAS3_1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS3_1.TabIndex = 11;
            this.comboBoxAS3_1.Visible = false;
            this.comboBoxAS3_1.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS3_1_SelectedIndexChanged);
            // 
            // buttonAjouterCondition3
            // 
            this.buttonAjouterCondition3.Location = new System.Drawing.Point(806, 67);
            this.buttonAjouterCondition3.Name = "buttonAjouterCondition3";
            this.buttonAjouterCondition3.Size = new System.Drawing.Size(148, 23);
            this.buttonAjouterCondition3.TabIndex = 10;
            this.buttonAjouterCondition3.Text = "Ajouter une condition";
            this.buttonAjouterCondition3.UseVisualStyleBackColor = true;
            this.buttonAjouterCondition3.Visible = false;
            this.buttonAjouterCondition3.Click += new System.EventHandler(this.buttonAjouterCondition3_Click);
            // 
            // textBoxAS2
            // 
            this.textBoxAS2.Location = new System.Drawing.Point(654, 70);
            this.textBoxAS2.Name = "textBoxAS2";
            this.textBoxAS2.Size = new System.Drawing.Size(123, 20);
            this.textBoxAS2.TabIndex = 9;
            this.textBoxAS2.Visible = false;
            // 
            // comboBoxAS2_4
            // 
            this.comboBoxAS2_4.FormattingEnabled = true;
            this.comboBoxAS2_4.Location = new System.Drawing.Point(496, 68);
            this.comboBoxAS2_4.Name = "comboBoxAS2_4";
            this.comboBoxAS2_4.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS2_4.TabIndex = 8;
            this.comboBoxAS2_4.Visible = false;
            this.comboBoxAS2_4.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS2_4_SelectedIndexChanged);
            // 
            // comboBoxAS2_3
            // 
            this.comboBoxAS2_3.FormattingEnabled = true;
            this.comboBoxAS2_3.Location = new System.Drawing.Point(341, 68);
            this.comboBoxAS2_3.Name = "comboBoxAS2_3";
            this.comboBoxAS2_3.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS2_3.TabIndex = 7;
            this.comboBoxAS2_3.Visible = false;
            this.comboBoxAS2_3.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS2_3_SelectedIndexChanged);
            // 
            // comboBoxAS2_2
            // 
            this.comboBoxAS2_2.FormattingEnabled = true;
            this.comboBoxAS2_2.Location = new System.Drawing.Point(180, 69);
            this.comboBoxAS2_2.Name = "comboBoxAS2_2";
            this.comboBoxAS2_2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS2_2.TabIndex = 6;
            this.comboBoxAS2_2.Visible = false;
            this.comboBoxAS2_2.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS2_2_SelectedIndexChanged);
            // 
            // comboBoxAS2_1
            // 
            this.comboBoxAS2_1.FormattingEnabled = true;
            this.comboBoxAS2_1.Items.AddRange(new object[] {
            "Personne",
            "Entretien"});
            this.comboBoxAS2_1.Location = new System.Drawing.Point(24, 70);
            this.comboBoxAS2_1.Name = "comboBoxAS2_1";
            this.comboBoxAS2_1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS2_1.TabIndex = 5;
            this.comboBoxAS2_1.Visible = false;
            this.comboBoxAS2_1.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS2_1_SelectedIndexChanged);
            // 
            // buttonAjouterCondition2
            // 
            this.buttonAjouterCondition2.Location = new System.Drawing.Point(806, 25);
            this.buttonAjouterCondition2.Name = "buttonAjouterCondition2";
            this.buttonAjouterCondition2.Size = new System.Drawing.Size(148, 23);
            this.buttonAjouterCondition2.TabIndex = 4;
            this.buttonAjouterCondition2.Text = "Ajouter une condition";
            this.buttonAjouterCondition2.UseVisualStyleBackColor = true;
            this.buttonAjouterCondition2.Visible = false;
            this.buttonAjouterCondition2.Click += new System.EventHandler(this.buttonAjouterCondition2_Click);
            // 
            // textBoxAS1
            // 
            this.textBoxAS1.Location = new System.Drawing.Point(654, 28);
            this.textBoxAS1.Name = "textBoxAS1";
            this.textBoxAS1.Size = new System.Drawing.Size(123, 20);
            this.textBoxAS1.TabIndex = 3;
            this.textBoxAS1.Visible = false;
            // 
            // comboBoxAS1_4
            // 
            this.comboBoxAS1_4.FormattingEnabled = true;
            this.comboBoxAS1_4.Location = new System.Drawing.Point(496, 28);
            this.comboBoxAS1_4.Name = "comboBoxAS1_4";
            this.comboBoxAS1_4.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS1_4.TabIndex = 2;
            this.comboBoxAS1_4.Visible = false;
            this.comboBoxAS1_4.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS1_4_SelectedIndexChanged);
            // 
            // comboBoxAS1_3
            // 
            this.comboBoxAS1_3.FormattingEnabled = true;
            this.comboBoxAS1_3.Location = new System.Drawing.Point(341, 28);
            this.comboBoxAS1_3.Name = "comboBoxAS1_3";
            this.comboBoxAS1_3.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS1_3.TabIndex = 1;
            this.comboBoxAS1_3.Visible = false;
            this.comboBoxAS1_3.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS1_3_SelectedIndexChanged);
            // 
            // comboBoxAS1_2
            // 
            this.comboBoxAS1_2.FormattingEnabled = true;
            this.comboBoxAS1_2.Location = new System.Drawing.Point(180, 28);
            this.comboBoxAS1_2.Name = "comboBoxAS1_2";
            this.comboBoxAS1_2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS1_2.TabIndex = 0;
            this.comboBoxAS1_2.Visible = false;
            this.comboBoxAS1_2.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS1_2_SelectedIndexChanged);
            // 
            // comboBoxAS1_1
            // 
            this.comboBoxAS1_1.FormattingEnabled = true;
            this.comboBoxAS1_1.Items.AddRange(new object[] {
            "Personne",
            "Entretien"});
            this.comboBoxAS1_1.Location = new System.Drawing.Point(24, 28);
            this.comboBoxAS1_1.Name = "comboBoxAS1_1";
            this.comboBoxAS1_1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAS1_1.TabIndex = 0;
            this.comboBoxAS1_1.SelectedIndexChanged += new System.EventHandler(this.comboBoxAS1_1_SelectedIndexChanged);
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 362);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Accueil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recherche";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxAxePrincipal.ResumeLayout(false);
            this.groupBoxAxesSecondaires.ResumeLayout(false);
            this.groupBoxAxesSecondaires.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxAxePrincipal;
        private System.Windows.Forms.ComboBox comboBoxAP_2;
        private System.Windows.Forms.ComboBox comboBoxAP_1;
        private System.Windows.Forms.GroupBox groupBoxAxesSecondaires;
        private System.Windows.Forms.ComboBox comboBoxAS1_1;
        private System.Windows.Forms.ComboBox comboBoxAS1_2;
        private System.Windows.Forms.ComboBox comboBoxAS1_3;
        private System.Windows.Forms.ComboBox comboBoxAP_3;
        private System.Windows.Forms.ComboBox comboBoxAS1_4;
        private System.Windows.Forms.Button buttonAjouterCondition2;
        private System.Windows.Forms.TextBox textBoxAS1;
        private System.Windows.Forms.Button buttonAjouterCondition3;
        private System.Windows.Forms.TextBox textBoxAS2;
        private System.Windows.Forms.ComboBox comboBoxAS2_4;
        private System.Windows.Forms.ComboBox comboBoxAS2_3;
        private System.Windows.Forms.ComboBox comboBoxAS2_2;
        private System.Windows.Forms.ComboBox comboBoxAS2_1;
        private System.Windows.Forms.ComboBox comboBoxAS3_1;
        private System.Windows.Forms.Button buttonAjouterCondition4;
        private System.Windows.Forms.TextBox textBoxAS3;
        private System.Windows.Forms.ComboBox comboBoxAS3_4;
        private System.Windows.Forms.ComboBox comboBoxAS3_3;
        private System.Windows.Forms.ComboBox comboBoxAS3_2;
        private System.Windows.Forms.Button buttonLancerRecherche;
    }
}

